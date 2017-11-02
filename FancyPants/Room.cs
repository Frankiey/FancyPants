using System;
using System.Collections.Generic;
using System.Security.Claims;


namespace FancyPants
{
    public class Room
    {
        private string _name;
        public Game CurrGame { get; set; }

        public List<IMonster> MonsterList = new List<IMonster>()
        {
            new Minatour()
            {
                Name = "vex",
                Health = 5,
                Description = "There is an evil Vex minatour fuming with void energy",
                DropTable = new List<IItem>()
                {
                    new Key()
                }
            }
        };

        public List<IItem> ItemList = new List<IItem>()
        {
            new Sword()
        };

        public Dictionary<string, Action> Actions = new Dictionary<string, Action>()
        {
            {"look", () => Game.Commands.LookAround()},
            {"hit", () => Game.Commands.Hit(Game.CurrentGame.CurrentArgs)},
            {"get", ()=> Game.Commands.Get(Game.CurrentGame.CurrentArgs) },
            {"bag", () =>  Game.Commands.Bag()}
        };

        // List of actions and results
        public Room(string name = "")
        {
            _name = name;
        }
    }

    public interface IMonster
    {
        string Name { get; set; }
        int Health { get; set; }
        List<IItem> DropTable { get; set; }
        void Attack();
        string Description { get; set; }

        void Die();
        void DealDamage(int damage);
    }

    public class Minatour : IMonster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<IItem> DropTable { get; set; }
        public string Description { get; set; }

        public Minatour()
        {
            // Minatour spawned.
        }

        public void Attack()
        {
            Random random = new Random();
            int damage = random.Next(0, 3);
            Game.CurrentGame.Player.DealDamage(damage);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The {Name} deals {damage} damage");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DealDamage(int damage)
        {
            Health -= damage;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You hit the {Name} for {damage} damage.");
            Console.ForegroundColor = ConsoleColor.White;
            if(Health <= 0)
                Die();
        }

        public void Die()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string killConf = @" _   _______ _      _       _____ _____ _   _ ______ ______________  ___ ___________ 
| | / /_   _| |    | |     /  __ \  _  | \ | ||  ___|_   _| ___ \  \/  ||  ___|  _  \
| |/ /  | | | |    | |     | /  \/ | | |  \| || |_    | | | |_/ / .  . || |__ | | | |
|    \  | | | |    | |     | |   | | | | . ` ||  _|   | | |    /| |\/| ||  __|| | | |
| |\  \_| |_| |____| |____ | \__/\ \_/ / |\  || |    _| |_| |\ \| |  | || |___| |/ / 
\_| \_/\___/\_____/\_____/  \____/\___/\_| \_/\_|    \___/\_| \_\_|  |_/\____/|___/  
                                                                                     
                                                                                     ";
            Console.WriteLine(killConf);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The {Name} Minatour dies horrendously and vanishes into the ground.");
            Console.ForegroundColor = ConsoleColor.White;

            Game.CurrentGame.Player.AddXp(10);

            Game.CurrentGame.CurrentRoom.ItemList.Add(new Key(){Name = "universalkey", Damage = 1});
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The vex drops a key onto the ground.");
            Console.ForegroundColor = ConsoleColor.White;

            Game.CurrentGame.CurrentRoom.MonsterList.Remove(this);
        }

    }

    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        int Damage { get; set; }

        void Get();
    }

    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }

        public void Get()
        {
           Console.WriteLine($"{Name} added to Bag");
        }
    }

    public class Key :IItem
    {
        public string Name { get; set; } = "universalkey";
        public string Description { get; set; } = "A shiney key";
        public int Damage { get; set; } = 1;

        public void Get()
        {
            Game.CurrentGame.Player.Bag.Add(this);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"A {Name} was added to your bag");
            Console.ForegroundColor = ConsoleColor.White;

            var currentGame = Game.CurrentGame;
            currentGame.CurrentRoom.Actions.Add("north", () => Game.CurrentGame.Move(EDirection.North));
            currentGame.CurrentRoom.Actions.Add("west", () => Game.CurrentGame.Move(EDirection.West));
            currentGame.CurrentRoom.Actions.Add("south", () => Game.CurrentGame.Move(EDirection.South));
            currentGame.CurrentRoom.Actions.Add("east", () => Game.CurrentGame.Move(EDirection.East));

            Game.CurrentGame.CurrentRoom.ItemList.Remove(this);
        }
    }

    public class Sword : IItem
    {
        public string Name { get; set; } = "quickfang";
        public string Description { get; set; } = "My smile is full of blades.";
        public int Damage { get; set; } = 3;

        public void Get()
        {
            Game.CurrentGame.Player.Bag.Add(this);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"A purple {Name} was added to your bag");
            Console.ForegroundColor = ConsoleColor.White;

            Game.CurrentGame.CurrentRoom.ItemList.Remove(this);
        }
    }

    public class Player
    {
        public int Health { get; set; } = 10;

        public List<IItem> Bag { get; set; } = new List<IItem>()
        {
            new Item() {Damage = 2, Description = "Two fists", Name = "fists"}
        };
        public int Xp { get; set; } = 0;

        public void DealDamage(int x)
        {
            Health -= x;
            if(Health <= 0)
                Die();
        }

        public void AddXp(int xp)
        {
            Xp += xp;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You earned {xp} xp. Now a total of {Xp} xp ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void AddToBag(IItem item)
        {
            Bag.Add(item);
        }

        public void Die()
        {
            string str =
                @" .----------------.  .----------------.  .----------------.   .----------------.  .----------------.  .----------------.  .----------------. 
| .--------------. || .--------------. || .--------------. | | .--------------. || .--------------. || .--------------. || .--------------. |
| |  ____  ____  | || |     ____     | || | _____  _____ | | | |  ________    | || |     _____    | || |  _________   | || |  ________    | |
| | |_  _||_  _| | || |   .'    `.   | || ||_   _||_   _|| | | | |_   ___ `.  | || |    |_   _|   | || | |_   ___  |  | || | |_   ___ `.  | |
| |   \ \  / /   | || |  /  .--.  \  | || |  | |    | |  | | | |   | |   `. \ | || |      | |     | || |   | |_  \_|  | || |   | |   `. \ | |
| |    \ \/ /    | || |  | |    | |  | || |  | '    ' |  | | | |   | |    | | | || |      | |     | || |   |  _|  _   | || |   | |    | | | |
| |    _|  |_    | || |  \  `--'  /  | || |   \ `--' /   | | | |  _| |___.' / | || |     _| |_    | || |  _| |___/ |  | || |  _| |___.' / | |
| |   |______|   | || |   `.____.'   | || |    `.__.'    | | | | |________.'  | || |    |_____|   | || | |_________|  | || | |________.'  | |
| |              | || |              | || |              | | | |              | || |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' | | '--------------' || '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------'   '----------------'  '----------------'  '----------------'  '----------------' ";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
            Game.CurrentGame.Quit();
        }
    }

}