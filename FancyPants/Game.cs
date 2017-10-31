using System;

namespace FancyPants
{
    public class Game
    {
        public static Game CurrentGame;

        private string _name;
        private Room[][] _rooms;
        public string Level { get; private set; }
        private (int x, int y) _position = (0, 0);
        private (int x, int y) _goalPos = (2, 2);
        private int _gridSize = 10;

        private DateTime _time;

       

        public Game()
        {
            CurrentGame = this;
            Console.CursorSize = 20;
            Console.WindowWidth = 150;
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
          //  Console.WriteLine($"Naam:{_name}, House: {_house}, Street: {_street}, Level: {Level}");

            _time = DateTime.Now;
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
                Console.WriteLine("WE HAVE A WINNER!!!");
                return true;
            }
            return false;
        }

        public void DisplayCurrentPos((int x, int y) pos)
        {
            Console.WriteLine($"Current position is X: {pos.x}, Y: {pos.y}");

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


        }

        public void ProcessInput()
        {
            bool getInput = true;

            while (true)
            {
                Console.WriteLine("Enter a direction to move: North | West | South | East");

                string move = Console.ReadLine();
                move = move.ToLower();

                // Get the corresponding action from the room actions dictionary.
                if (_rooms[_position.x][_position.y].Actions.TryGetValue(move, out var action))
                {
                    action();
                    break;
                }
                else
                {

                }

            }
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