using System;
using FancyPants.GameLogic;
using FancyPants.Interfaces;

namespace FancyPants.Items
{
    public class Sword : IItem
    {
        public string Name { get; set; } = "quickfang";
        public string Description { get; set; } = "My smile is full of blades.";
        public int Damage { get; set; } = 3;

        public void Get()
        {
            Game.CurrentGame.Player.Bag.Add(this);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"A purple {Name} was added to your bag");
            Console.ForegroundColor = ConsoleColor.White;

            Game.CurrentGame.CurrentRoom.ItemList.Remove(this);
        }
    }
}