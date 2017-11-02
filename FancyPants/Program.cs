using System;
using FancyPants.GameLogic;

namespace FancyPants
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Fancy Game";

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
            Game game = new Game();
            game.Start();
            game.Loop();
            game.End();
        }
    }
}