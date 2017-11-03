using System;
using System.Collections.Generic;
using FancyPants.GameLogic;
using FancyPants.Interfaces;
using FancyPants.Items;

namespace FancyPants.Monsters
{
    public class Minatour : IMonster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<IItem> DropTable { get; set; }
        public string Description { get; set; }

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
            if (Health <= 0)
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

            Game.CurrentGame.CurrentRoom.ItemList.Add(new Key {Name = "roomkey", Damage = 1});
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The vex drops a key onto the ground.");
            Console.ForegroundColor = ConsoleColor.White;

            Game.CurrentGame.CurrentRoom.MonsterList.Remove(this);
        }
    }
}