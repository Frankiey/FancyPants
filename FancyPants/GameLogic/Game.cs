using System;
using System.Collections.Generic;
using FancyPants.Enums;

namespace FancyPants.GameLogic
{
    /// <summary>
    ///     Class responsible for all the game logic.
    /// </summary>
    public class Game
    {
        public static Game CurrentGame;
        public static Commands Commands = new Commands();
        private readonly int _gridSize = 10;
        private readonly Room[][] _rooms;
        private (int x, int y) _goalPos = (2, 2);

        private string _name;
        private (int x, int y) _position = (0, 0);

        private DateTime _time;

        public string[] CurrentArgs;
        public Room CurrentRoom;

        public Game()
        {
            CurrentGame = this;
            Commands.CurrGame = this;
            Player = new Player();

            // Make the rooms jagged array.
            _rooms = RoomsFactory.MakeRooms(_gridSize);
        }

        public string Level { get; private set; }

        public Player Player { get; }

        /// <summary>
        ///     Start the game.
        /// </summary>
        public void Start()
        {
            GetName();

            // Set the current time.
            _time = DateTime.Now;

            CurrentRoom = _rooms[_position.x][_position.y];
        }

        /// <summary>
        ///     Get the name of the player by asking for it in the console.
        /// </summary>
        private void GetName()
        {
            while (true)
            {
                Console.WriteLine("Wat is je naam?");
                _name = Console.ReadLine();
                if (string.IsNullOrEmpty(_name))
                    Console.WriteLine("Please give a valid name...");
                else
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome {_name}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        ///     Perform the game loop.
        /// </summary>
        public void Loop()
        {
            while (true)
            {
                bool done = CheckGoalState(_position);
                if (done)
                    return;
                //DisplayCurrentPos(_position);
                ProcessInput();
            }
        }

        /// <summary>
        ///     Check if the goalstate has been reached.
        /// </summary>
        /// <param name="pos">The current position of the player.</param>
        /// <returns>True if the goal has been reached.</returns>
        public bool CheckGoalState((int x, int y) pos)
        {
            (int x, int y) goal = (2, 2);

            if (goal.x == pos.x && goal.y == pos.y)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("WE HAVE A WINNER!!!");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Display the current position on the grid with ascii art.
        /// </summary>
        /// <param name="pos">The position on the grid of the player.</param>
        public void DisplayCurrentPos((int x, int y) pos)
        {
            Console.WriteLine($"Current room is X: {pos.x}, Y: {pos.y}");

            for (int y = _gridSize - 1; y >= 0; y--)
            {
                for (int x = 0; x < _gridSize; x++)
                    if (pos.x == x && pos.y == y)
                        Console.Write("@ ");
                    else if (_goalPos.x == x && _goalPos.y == y)
                        Console.Write("X ");
                    else
                        Console.Write(". ");
                Console.Write("\n");
            }
        }

        /// <summary>
        ///     Move the player in the right direction across the grid.
        /// </summary>
        /// <param name="direction"></param>
        public void Move(EDirection direction)
        {
            (int x, int y) dir = (0, 0);
            switch (direction)
            {
                case EDirection.North:
                    dir = (0, 1);
                    break;
                case EDirection.South:
                    dir = (0, -1);
                    break;
                case EDirection.West:
                    dir = (-1, 0);
                    break;
                case EDirection.East:
                    dir = (1, 0);
                    break;
            }

            // Check if out of bounds, if not add the corresponding direction to the coordinates,
            if (_position.x + dir.x <= _gridSize - 1 && _position.x + dir.x >= 0)
                _position.x += dir.x;
            if (_position.y + dir.y <= _gridSize - 1 && _position.y + dir.y >= 0)
                _position.y += dir.y;

            // Set the current room to the new room.
            CurrentRoom = _rooms[_position.x][_position.y];
        }

        /// <summary>
        ///     Process the players input.
        /// </summary>
        public void ProcessInput()
        {
            while (true)
            {
                Console.Write("Options: ");
                // Print options
                Room room = _rooms[_position.x][_position.y];
                foreach (KeyValuePair<string, Action> act in room.Actions)
                {
                    Console.Write("| ");
                    Console.Write(act.Key + " ");
                }
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(">");

                string move = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.White;

                move = move?.ToLower();

                string[] args = move?.Split(' ');
                CurrentArgs = args;

                if (args == null) continue;

                switch (args[0])
                {
                    case "help":
                        Commands.Help();
                        continue;
                    case "quit":
                        Commands.Quit();
                        continue;
                }

                // Get the corresponding action from the room actions dictionary.
                if (_rooms[_position.x][_position.y].Actions.TryGetValue(args[0], out Action action))
                {
                    action();
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is not a valid move");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        ///     End the game when it has been finished.
        /// </summary>
        public void End()
        {
            DateTime currentTime = DateTime.Now;

            TimeSpan timeSpent = currentTime - _time;

            Console.WriteLine($"Naam:{_name}");
            Console.WriteLine($"Time: {timeSpent.TotalSeconds} seconds");

            Console.ReadLine();
        }
    }
}