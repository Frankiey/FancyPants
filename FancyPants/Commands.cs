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
                if (args[1] == "monster" && args[2] == "with")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (args[3] == "fist" || args[3] == "fists")
                        Console.WriteLine($"You deal one damage against the {args[1]}.");
                    if (args[3] == "sword")
                        Console.WriteLine($"You deal 3 damage against the {args[1]}.");

                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }

            Console.WriteLine("Failed to hit something.");

            // als een van de argumenten monster bevat 
            // arg[0] hit
            // arg[1] Het monster  --- overeenkomend met de monsterlist uit de room
            // arg[2] with
            // arg[3] weapon  --- Het wapen dat de speler bij zich heeft, in de room ligt en wilt gebruiken.
        }


        public void LookAround()
        {
            // todo get description of room and print it to the console.
            string str =
                "You see a sword on the ground. All doors are locked. There is a big Unknown monster in the room that stares through your soul.";
            Console.WriteLine(str);
        }

        public void GetKey()
        {
            string str = "You found a Key!!!";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;

            CurrGame.CurrentRoom.Actions.Add("north", () => Game.CurrentGame.Move(EDirection.North));
            CurrGame.CurrentRoom.Actions.Add("west", () => Game.CurrentGame.Move(EDirection.West));
            CurrGame.CurrentRoom.Actions.Add("south", () => Game.CurrentGame.Move(EDirection.South));
            CurrGame.CurrentRoom.Actions.Add("east", () => Game.CurrentGame.Move(EDirection.East));

            CurrGame.CurrentRoom.Actions.Remove("get key");
        }

        /// <summary>
        /// get or pick something from the room.
        /// </summary>
        /// <param name="args"></param>
        public void Get(string[] args)
        {
            if(args == null)
                return;
            // todo get all items in the room and map arg[1] to action
            if (args[1] == "key")
            {
                string str = "You found a Key!!!";

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(str);
                Console.ForegroundColor = ConsoleColor.White;

                CurrGame.CurrentRoom.Actions.Add("north", () => Game.CurrentGame.Move(EDirection.North));
                CurrGame.CurrentRoom.Actions.Add("west", () => Game.CurrentGame.Move(EDirection.West));
                CurrGame.CurrentRoom.Actions.Add("south", () => Game.CurrentGame.Move(EDirection.South));
                CurrGame.CurrentRoom.Actions.Add("east", () => Game.CurrentGame.Move(EDirection.East));
            }
            else
            {
                Console.WriteLine("Cant get that item.");
            }
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
