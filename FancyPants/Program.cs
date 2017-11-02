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

            Console.CursorSize = 10;
            Console.WindowWidth = 150;
            Console.WindowHeight = 35;

            string str = @"

██████╗ ███████╗███████╗████████╗██╗███╗   ██╗██╗   ██╗    ██████╗ 
██╔══██╗██╔════╝██╔════╝╚══██╔══╝██║████╗  ██║╚██╗ ██╔╝    ╚════██╗
██║  ██║█████╗  ███████╗   ██║   ██║██╔██╗ ██║ ╚████╔╝      █████╔╝
██║  ██║██╔══╝  ╚════██║   ██║   ██║██║╚██╗██║  ╚██╔╝      ██╔═══╝ 
██████╔╝███████╗███████║   ██║   ██║██║ ╚████║   ██║       ███████╗
╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝╚═╝  ╚═══╝   ╚═╝       ╚══════╝
                                                                   
";
            string gun = @"         `..`                        `..`         
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
            for(int i = 0; i < 1; i++)
            {
                Console.Write(gun);
            }
            
            Console.WriteLine(str);
            Console.Write("\n");

            Game game = new Game();
            game.Start();
            game.Loop();
            game.End();
        }

    }
}
