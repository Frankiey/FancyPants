using System;
using FancyPants.Enums;

namespace FancyPants.GameLogic
{
    public class Game
    {
        public static Game CurrentGame;
        public Room CurrentRoom;
        public static Commands Commands = new Commands();

        public string[] CurrentArgs;

        private string _name;
        private Room[][] _rooms;
        public string Level { get; private set; }
        private (int x, int y) _position = (0, 0);
        private (int x, int y) _goalPos = (2, 2);
        private int _gridSize = 10;

        public Player Player { get; }

        private DateTime _time;

        public Game()
        {
            CurrentGame = this;
            Commands.CurrGame = this;
            Player = new Player();
            Console.CursorSize = 10;
            Console.WindowWidth = 150;
            Console.WindowHeight = 35;
            // Init the Rooms jagged array.
            _rooms = new Room[_gridSize][];
            for (int x = 0; x < _gridSize; x++)
            {
                _rooms[x] = new Room[_gridSize];
                for (int y = 0; y < _gridSize; y++)
                    _rooms[x][y] = new Room();
            }
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Wat is je naam?");
                _name = Console.ReadLine();
                if (string.IsNullOrEmpty(_name))
                {
                    Console.WriteLine("Please give a valid name...");
                    // todo make loop until correct name is given
                }
                else
                {
                    break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome {_name}");
            Console.ForegroundColor = ConsoleColor.White;

            _time = DateTime.Now;

            CurrentRoom = _rooms[_position.x][_position.y];
        }

        public void Loop()
        {
            while (true)
            {
                bool done = CheckGoalState(_position);
                if (done)
                    return;
                DisplayCurrentPos(_position);
                ProcessInput();
            }
        }

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

        public void DisplayCurrentPos((int x, int y) pos)
        {
            Console.WriteLine($"Current room is X: {pos.x}, Y: {pos.y}");

            for (int y = _gridSize - 1; y >= 0; y--)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    if (pos.x == x && pos.y == y)
                        Console.Write("@ ");
                    else if (_goalPos.x == x && _goalPos.y == y)
                        Console.Write("X ");
                    else
                        Console.Write(". ");
                }
                Console.Write("\n");
            }
        }

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

            if (_position.x + dir.x <= _gridSize - 1 && _position.x + dir.x >= 0)
                _position.x += dir.x;
            if (_position.y + dir.y <= _gridSize - 1 && _position.y + dir.y >= 0)
                _position.y += dir.y;

            CurrentRoom = _rooms[_position.x][_position.y];
        }

        public void ProcessInput()
        {
            bool getInput = true;

            while (true)
            {
                Console.Write("Options: ");
                // Print options
                Room room = _rooms[_position.x][_position.y];
                foreach (var act in room.Actions)
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

                if (args != null)
                {
                    switch (args[0])
                    {
                        case "help":
                            Help();
                            continue;
                        case "quit":
                            Quit();
                            continue;
                    }

                    // Get the corresponding action from the room actions dictionary.
                    if (_rooms[_position.x][_position.y].Actions.TryGetValue(args[0], out var action))
                    {
                        action();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This is not a valid move");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }

        private void Help()
        {
            Console.WriteLine("This is what you can do: NOTHING");
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

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