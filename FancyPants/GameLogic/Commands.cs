using System;
using System.Linq;
using FancyPants.Interfaces;

namespace FancyPants.GameLogic
{
    /// <summary>
    ///     All the commands available in the game.
    /// </summary>
    public class Commands
    {
        public Game CurrGame { get; set; }

        /// <summary>
        ///     Hit a monster or item with another item.
        /// </summary>
        /// <param name="args">The arguments passed by the console.</param>
        public void Hit(string[] args = null)
        {
            // arg[0] hit
            // arg[1] Het monster  --- overeenkomend met de monsterlist uit de room
            // arg[2] with
            // arg[3] weapon  --- Het wapen dat de speler bij zich heeft, in de room ligt en wilt gebruiken.

            if (args == null)
            {
                Console.WriteLine("You hit nothing");
                return;
            }
            if (args.Length == 4)
            {
                // Get the current room
                Room room = Game.CurrentGame.CurrentRoom;
                IMonster monster;
                try
                {
                    monster = room.MonsterList.First(x => x.Name == args[1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Can't hit that");
                    return;
                }

                if (monster == null)
                {
                    Console.WriteLine("Can't hit that");
                    return;
                }
                if (args[2] != "with")
                {
                    Console.WriteLine("Can't find the hit target");
                    return;
                }
                IItem item = CurrGame.Player.Bag.FirstOrDefault(x => x.Name == args[3]);

                if (item == default(IItem))
                {
                    Console.WriteLine("Can't find that item");
                    return;
                }
                // Hit the monster with the Items damage.
                monster.DealDamage(item.Damage);
                // Monster attacks you.
                monster.Attack();
                return;
            }

            Console.WriteLine("Failed to hit something.");
        }

        /// <summary>
        ///     Look into the players bag and prints all items to the console.
        /// </summary>
        public void Bag()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("The following items are in your Bag:");
            foreach (IItem item in CurrGame.Player.Bag)
                Console.Write($"| {item.Name} ");
            Console.Write("| \n");
        }

        /// <summary>
        ///     Look around the room and see what items and monsters are in the room.
        /// </summary>
        public void LookAround()
        {
            // todo get description of room and print it to the console.

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("The following is in the room");
            Console.WriteLine("Monsters:");
            foreach (IMonster monster in CurrGame.CurrentRoom.MonsterList)
                Console.Write($"| {monster.Name} ");
            Console.Write("| \n");

            Console.WriteLine("Items:");
            foreach (IItem item in CurrGame.CurrentRoom.ItemList)
                Console.Write($"| {item.Name} ");
            Console.Write("| \n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        ///     Get or pick something from the room.
        /// </summary>
        /// <param name="args"></param>
        public void Get(string[] args)
        {
            if (args.Length < 2)
                Console.WriteLine("Can't get that, type 'get *item here*'");

            IItem item;
            try
            {
                // Try to get the first item that matches the given item name.
                item = CurrGame.CurrentRoom.ItemList.First(x => x.Name == args[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cant get that item.");
                return;
            }

            item.Get();
        }

        public void Help()
        {
            string bump = @"      .--.___.----.___.--._
     /|  |   |    |   |  | `--.
    /                          `.
   |       |        |           |
   |       |        |      |     |
   |  `    |  `     |    ` |     |
   |    `  |      ` |      |   ` |
  '|  `    | ` ` `  |  ` ` |  `  |
  ||`   `  |     `  |   `  |`   `|
  ||  `    |  `     | `    |  `  |
  ||    `  |   ` `  |    ` | `  `|
  || `     | `      | ` `  |  `  |
  ||  ___  |  ____  |  __  |  _  |
  | \_____/ \______/ \____/ \___/
  |     `----._
  |    /       \
  |         .--.\
  |        '    \
  `.      |  _.-'
     `.|__.-";

            Console.WriteLine(bump);
            Console.WriteLine("This is what you can do: NOTHING");
        }

        public void Quit()
        {
            Environment.Exit(0);
        }
    }
}