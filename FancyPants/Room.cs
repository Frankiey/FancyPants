using System;
using System.Collections.Generic;


namespace FancyPants
{
    public class Room
    {
        private string _name;
        public Game CurrGame { get; set; }

        public Dictionary<string, Action> Actions = new Dictionary<string, Action>()
        {
            {"north", () => Game.CurrentGame.Move(EDirection.North) },
            {"east", () => Game.CurrentGame.Move(EDirection.East) },
            {"south",() => Game.CurrentGame.Move(EDirection.South) },
            {"west",() => Game.CurrentGame.Move(EDirection.West) }
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
}