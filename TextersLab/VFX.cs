using System;

namespace TextersLab
{
    public class VFX
    {
        public static void Screen(int selection) // Logo and other art
        {
            switch (selection)
            {
                case 0:
                    Console.Title = "Texter's Lab";
                    Special(@"
  _____         _            _       _          _      
 |_   _|____  _| |_ ___ _ __( )___  | |    __ _| |__   
   | |/ _ \ \/ / __/ _ \ '__|// __| | |   / _` | '_ \  
   | |  __/>  <| ||  __/ |    \__ \ | |__| (_| | |_) | 
   |_|\___/_/\_\\__\___|_|    |___/ |_____\__,_|_.__/  
                                                       ", "blue");
                    break;
                case 10:
                    Console.Title = "The End";
                    Special("Congratulations! You beat the demo!");
                    break;
                default:
                    Console.Title = "Placeholder Title";
                    break;
            }
        }

        public static void Special(string prompt, string color = "cyan") // Write a given string with colors Red/Blue/Yellow/Cyan (Default)
        {
            switch (color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
            Console.WriteLine(prompt);
            Console.ResetColor();
        }
    }
}
