using System;
using System.Collections.Generic;
using FancyPants.Interfaces;
using FancyPants.Items;

namespace FancyPants.GameLogic
{
    public class Player
    {
        public int Health { get; set; } = 10;

        public List<IItem> Bag { get; set; } = new List<IItem>
        {
            new Item {Damage = 2, Description = "Two fists", Name = "fists"}
        };

        public int Xp { get; set; }

        public void DealDamage(int x)
        {
            Health -= x;
            if (Health <= 0)
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
            Game.Commands.Quit();
        }
    }
}