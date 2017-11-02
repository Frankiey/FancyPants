using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyPants
{
    public class Commands
    {
        public Game CurrGame { get; set; }

        public void KillMonster(string[] args = null)
        {
            string str = "Monster has been killed!!! +2 xp";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            CurrGame.CurrentRoom.Actions.Remove("kill");
            CurrGame.CurrentRoom.Actions.Add("get", () => Game.Commands.Get(Game.CurrentGame.CurrentArgs));
        }

        public void Hit(string[] args = null)
        {
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
                catch (Exception e)
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
                // Hit the monster with the Itemss damage.
                monster.DealDamage(item.Damage);
                // Monster attacks you.
                monster.Attack();
                return;
            }

            Console.WriteLine("Failed to hit something.");

            // als een van de argumenten monster bevat 
            // arg[0] hit
            // arg[1] Het monster  --- overeenkomend met de monsterlist uit de room
            // arg[2] with
            // arg[3] weapon  --- Het wapen dat de speler bij zich heeft, in de room ligt en wilt gebruiken.
        }

        public void Bag()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("The following items are in your Bag:");
            foreach (var item in CurrGame.Player.Bag)
            {
                Console.Write($"| {item.Name} ");
            }
            Console.Write("| \n");
        }

        public void LookAround()
        {
            // todo get description of room and print it to the console.

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("The following is in the room");
            Console.WriteLine("Monsters:");
            foreach (var monster in CurrGame.CurrentRoom.MonsterList)
            {
                Console.Write($"| {monster.Name} ");
            }
            Console.Write("| \n");

            Console.WriteLine("Items:");
            foreach (var item in CurrGame.CurrentRoom.ItemList)
            {
                Console.Write($"| {item.Name} ");
            }
            Console.Write("| \n");

            Console.ForegroundColor = ConsoleColor.White;
            // string str =
            //    "You see a sword on the ground. All doors are locked. There is a big Unknown monster in the room that stares through your soul.";
            // Console.WriteLine(str);
        }

        /// <summary>
        /// get or pick something from the room.
        /// </summary>
        /// <param name="args"></param>
        public void Get(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Can't get that, type 'get *item here*'");
            };

            IItem item = CurrGame.CurrentRoom.ItemList.First(x => x.Name == args[1]);
            if(item == null)
            {
                Console.WriteLine("Cant get that item.");
                return;
            }
            else
            {
                item.Get();
            }
            // todo get all items in the room and map arg[1] to action
        }

        private void Help()
        {
            Console.WriteLine("This is what you can do: NOTHING");
        }

        private void Quit()
        {
            Environment.Exit(0);
        }
    }
}
