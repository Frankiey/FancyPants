using System;
using System.Collections.Generic;


namespace FancyPants
{
    public class Room
    {
        private string _name;
        public Game CurrGame { get; set; }
        public List<IMonster> MonsterList { get; set; }
        public List<IItem> ItemList { get; set; }

        public Dictionary<string, Action> Actions = new Dictionary<string, Action>()
        {
            //{"north", () => Game.CurrentGame.Move(EDirection.North) },
            //{"east", () => Game.CurrentGame.Move(EDirection.East) },
            //{"south",() => Game.CurrentGame.Move(EDirection.South) },
            //{"west",() => Game.CurrentGame.Move(EDirection.West) },
            //{"kill monster", () => Game.CurrentGame.KillMonster()},
            //{"look around", () => Game.CurrentGame.LookAround()},
            //{"hit", () => Game.CurrentGame.Hit(Game.CurrentGame.CurrentArgs)}
            {"kill", () => Game.Commands.KillMonster()},
            {"look", () => Game.Commands.LookAround()},
            {"hit", () => Game.Commands.Hit(Game.CurrentGame.CurrentArgs)}
        };

        // List of actions and results
        public Room(string name = "")
        {
            _name = name;
        }

        public void DoSomething()
        {

        }
    }

    public interface IMonster
    {
        string Name { get; set; }
        int Health { get; set; }
        List<IItem> DropTable { get; set; }
    }

    public class Minatour : IMonster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<IItem> DropTable { get; set; }

        public Minatour()
        {
            // Minatour spawned.
        }
    }

    public interface IItem
    {
        string Name { get; set; }
    }

    public class Player
    {
        public int Health { get; set; }
        public List<IItem> Bag { get; set; }

    }

}