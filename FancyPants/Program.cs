using System;
using System.Threading.Tasks;
using FancyPants.GameLogic;

namespace FancyPants
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Destiny 2";

            Console.CursorSize = 10;
            Console.WindowWidth = 150;
            Console.WindowHeight = 35;

            Console.Clear();

            string str = @"

██████╗ ███████╗███████╗████████╗██╗███╗   ██╗██╗   ██╗    ██████╗ 
██╔══██╗██╔════╝██╔════╝╚══██╔══╝██║████╗  ██║╚██╗ ██╔╝    ╚════██╗
██║  ██║█████╗  ███████╗   ██║   ██║██╔██╗ ██║ ╚████╔╝      █████╔╝
██║  ██║██╔══╝  ╚════██║   ██║   ██║██║╚██╗██║  ╚██╔╝      ██╔═══╝ 
██████╔╝███████╗███████║   ██║   ██║██║ ╚████║   ██║       ███████╗
╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝╚═╝  ╚═══╝   ╚═╝       ╚══════╝
                                                                   
";
            string logo = @"         `..`                        `..`         
      /hNMMMMmy/`                `:smMMMMNh/      
    `dMMMMMMMMMMMh-   `:++:`   .hNMMMMMMMMMMd.    
    hMMMMMMMMMMMMM/  sMMMMMMs  :MMMMMMMMMMMMMd    
    NMMMMMMMMMMMMM/ /MMMMMMMM/ :MMMMMMMMMMMMMN    
    oMMMMMMMMMMMMM/ +MMMMMMMM+ :MMMMMMMMMMMMMs    
     /mMMMMMMMMMMM/ +MMMMMMMM+ :MMMMMMMMMMMm+     
       -sNMMMMMMMM/ +MMMMMMMM+ :MMMMMMMMNs:       
          /dMMMMMM/ /MMMMMMMM+ /MMMMMMd/          
            :mMMMMh `dMMMMMMm` yMMMMm:            
              sMMMMy` /shhs/ `yMMMMs`             
               /MMMMNy+:..-+yNMMMM+               
                +MMMMMMMMMMMMMMMMo                
                 hMMMMMMMMMMMMMMd                 
                 -MMMMMMMMMMMMMM:                 
                  mMMMMMMMMMMMMN                  
                  yMMMMMMMMMMMMh                  
                  +MMMMMMMMMMMMo                  
                  `dMMMMMMMMMMd`                  
                    +mMMMMMMmo                    
                      .://:.                      
                                               
 ";
            Console.Write(logo);

            Console.WriteLine(str);
            Console.Write("\n");

            for (int i = 0; i < 100; i++)
            {
                int rest = i % 3;
                if (rest == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if(rest == 1)
                    Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.Write(logo);

                Console.WriteLine(str);
                Console.Write("\n");

                Task.Delay(100).Wait();

            }
            Game game = new Game();
            game.Start();
            game.Loop();
            game.End();
        }
    }
}