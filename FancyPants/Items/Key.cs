using System;
using FancyPants.Enums;
using FancyPants.GameLogic;
using FancyPants.Interfaces;

namespace FancyPants.Items
{
    public class Key : IItem
    {
        public string Name { get; set; } = "roomkey";
        public string Description { get; set; } = "A shiney key";
        public int Damage { get; set; } = 1;

        public void Get()
        {
            Game.CurrentGame.Player.Bag.Add(this);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"A {Name} was added to your bag");
            Console.ForegroundColor = ConsoleColor.White;

            Game currentGame = Game.CurrentGame;
            currentGame.CurrentRoom.Actions.Add("north", () => Game.CurrentGame.Move(EDirection.North));
            currentGame.CurrentRoom.Actions.Add("west", () => Game.CurrentGame.Move(EDirection.West));
            currentGame.CurrentRoom.Actions.Add("south", () => Game.CurrentGame.Move(EDirection.South));
            currentGame.CurrentRoom.Actions.Add("east", () => Game.CurrentGame.Move(EDirection.East));

            Game.CurrentGame.CurrentRoom.ItemList.Remove(this);
        }
    }
}