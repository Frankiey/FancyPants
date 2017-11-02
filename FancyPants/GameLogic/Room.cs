using System;
using System.Collections.Generic;
using FancyPants.Interfaces;
using FancyPants.Items;
using FancyPants.Monsters;

namespace FancyPants.GameLogic
{
    public class Room
    {
        private string _description;
        private string _name;

        public Dictionary<string, Action> Actions = new Dictionary<string, Action>
        {
            {"look", () => Game.Commands.LookAround()},
            {"hit", () => Game.Commands.Hit(Game.CurrentGame.CurrentArgs)},
            {"get", () => Game.Commands.Get(Game.CurrentGame.CurrentArgs)},
            {"bag", () => Game.Commands.Bag()}
        };

        public List<IItem> ItemList = new List<IItem>
        {
            new Sword()
        };

        public List<IMonster> MonsterList = new List<IMonster>
        {
            new Minatour
            {
                Name = "vex",
                Health = 5,
                Description = "There is an evil Vex minatour fuming with void energy",
                DropTable = new List<IItem>
                {
                    new Key()
                }
            }
        };

        // List of actions and results
        public Room(string name = "")
        {
            _name = name;
        }

        public Game CurrGame { get; set; }
    }
}