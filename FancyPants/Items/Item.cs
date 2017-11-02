using System;
using FancyPants.Interfaces;

namespace FancyPants.Items
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }

        public void Get()
        {
            Console.WriteLine($"{Name} added to Bag");
        }
    }
}