﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TextersLab
{
    public class Game
    {
        public static string playerName = "";
        public static bool winGame = false;

        public static string StartGame() // Introduce game and get player's name
        {
            Screen(0);

            Console.WriteLine("Welcome! Your mission today is to get to your lab.\nIt would be dangerous to leave it unattended.\nYou find yourself in an unknown series of rooms,\nwith quite a journey ahead.\n\nPress ENTER to continue...");
            Console.ReadLine();

            Console.WriteLine("Let's get to know more about you.");
            Prompt("What is your name?");
            playerName = Console.ReadLine();

            while (playerName.Length > 30 || playerName.Length == 0)
            {
                Console.WriteLine("Uh, you go by a nickname?");
                playerName = Console.ReadLine();
            }

            Console.WriteLine($"Good luck, {playerName}!\n");

            return playerName;
        }

        public static void PlayGame()
        {
            Console.Clear();

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"ALL WORK AND NO PLAY MAKES {playerName.ToUpper()} A DULL PLAYER");
            }

            Thing item1 = new Thing("crowbar", "a staple tool that can do anything but staple", 1, true);
            Special("You pick up a crowbar and examine it.", "yellow");
            Console.WriteLine($"It's {item1.desc}.");

            winGame = true;
        }

        static void Screen(int selection) // Logo and other art
        {
            if (selection == 0)
            {
                Console.Title = "Texter's Lab";
                Console.ForegroundColor = ConsoleColor.Blue;
                string logo = @"
  _____         _            _       _          _      
 |_   _|____  _| |_ ___ _ __( )___  | |    __ _| |__   
   | |/ _ \ \/ / __/ _ \ '__|// __| | |   / _` | '_ \  
   | |  __/>  <| ||  __/ |    \__ \ | |__| (_| | |_) | 
   |_|\___/_/\_\\__\___|_|    |___/ |_____\__,_|_.__/  
                                                       ";
                Console.WriteLine(logo);
                Console.ResetColor();
            }
            else
            {
                Console.Title = "Placeholder Title";
            }

        }

        static void Prompt(string prompt) // Colors the text every time we ask for player input
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(prompt);
            Console.ResetColor();
        }

        static void Special(string prompt, string color) // Extra prompt options with red/blue/yellow text
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (color == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (color == "yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(prompt);
            Console.ResetColor();
        }

    }
}
