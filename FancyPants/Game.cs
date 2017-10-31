using System;

namespace FancyPants
{
    public class Game
    {
        private string _name;
        private string _house;
        private string _street;
        private Room[][] _rooms;
        public string Level { get; private set; }
        private (int x, int y) _position = (0, 0);
        private (int x, int y) _goalPos = (2, 2);
        private int _gridSize = 10;

        private DateTime _time;

        public enum Direction { Up, Down, Left, Right };

        public Game()
        {
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
            Console.WriteLine("Wat is je house?");
            _house = Console.ReadLine();
            Console.WriteLine("Wat is je street");
            _street = Console.ReadLine();
            Console.WriteLine("Wat is je level");
            Level = Console.ReadLine();

            Console.WriteLine($"Welcome {_name}");
            Console.WriteLine($"Naam:{_name}, House: {_house}, Street: {_street}, Level: {Level}");

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

        public void ProcessInput()
        {
            (int x, int y) dir = (0, 0);
            bool getInput = true;
            while (getInput)
            {
                Console.WriteLine("Enter a direction to move: Up | Down | Left | Right");
                string move = Console.ReadLine();
                move = move.ToLower();
                switch (move)
                {
                    case "up":
                        dir = (0, 1);
                        getInput = false;
                        break;
                    case "down":
                        dir = (0, -1);
                        getInput = false;
                        break;
                    case "left":
                        dir = (-1, 0);
                        getInput = false;
                        break;
                    case "right":
                        dir = (1, 0);
                        getInput = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid move");
                        break;
                }
            }

            if (_position.x + dir.x <= _gridSize - 1 && _position.x + dir.x >= 0)
                _position.x += dir.x;
            if (_position.y + dir.y <= _gridSize - 1 && _position.y + dir.y >= 0)
                _position.y += dir.y;
        }

        public void End()
        {
            DateTime currentTime = DateTime.Now;

            TimeSpan timeSpent = currentTime - _time;

            Console.WriteLine($"Naam:{_name}, House: {_house}, Street: {_street}, Level: {Level}");
            Console.WriteLine($"Time: {timeSpent.TotalSeconds} seconds");

            Console.ReadLine();
        }
    }
}