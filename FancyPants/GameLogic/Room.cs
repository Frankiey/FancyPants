using System;
using System.Collections.Generic;
using FancyPants.Interfaces;

namespace FancyPants.GameLogic
{
    public class Room
    {
        private string _name;

        // List of actions and results
        public Room(string name = "")
        {
            _name = name;
        }

        public Dictionary<string, Action> Actions { get; set; }

        public List<IItem> ItemList { get; set; }

        public List<IMonster> MonsterList { get; set; }

        public Game CurrGame { get; set; }
    }
}