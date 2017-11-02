using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.InteropServices.WindowsRuntime;
using FancyPants.GameLogic;

namespace FancyPants
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Fancy Game";
            Console.WriteLine("_____________________________________-");

            Game game = new Game();
            game.Start();
            game.Loop();
            game.End();
        }

    }
}
