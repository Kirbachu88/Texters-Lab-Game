using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Threading;

namespace TextersLab
{
    public class Game
    {
        public static Player player = new Player(1); // Player in starting room
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
            Console.ReadLine();
            Console.Clear();

            return playerName;
        }

        public static void PlayGame()
        {
            do
            {
                string input = Console.ReadLine();
                GetInput(input);
                DoCommand(input);
            } while (!winGame);
        }

        // LIST OF THINGS
        public static Thing item1 = new Thing("crowbar", "a bent metal stick", 2, true, Thing.itemCount);

        // LIST OF ROOMS
        public static Room inv = new Room("player inv", "", 
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
        public static Room room1 = new Room("Entrance", 
            "some place", 
            new int[] { 2, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
        public static Room room2 = new Room("Not Entrance", 
            "some other place", 
            new int[] { -1, -1, -1, -1, 1, -1, -1, -1, -1, -1 });

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

        static void Inv(Room room, int location)
        {

        }
        static void Look(Room room)
        {
            Console.WriteLine(room.name);
        }

        static void Go(Room room, int dirs) // Moving from room to room
        {
            int newLocation = 0;

            for (int d = dirs; d != -1; d = newLocation)
            {
                newLocation = room.directions[dirs];
                if (newLocation == -1)
                {
                    Console.WriteLine("You can't go that way.");
                }
                else
                {
                    player.location = room.directions[dirs];
                    Look(room);
                    break;
                }
            }
        }
        static void goNorth(Room room, int dirs)
        {
            dirs = 0; // Hmm...
            Go(room, dirs);
        }
        static void goSouth(Room room, int dirs)
        {
            dirs = 5; // Hmm...
            Go(room, dirs);
        }

        static void DoInv(Room room, int[] item)
        {
            Inv(room, 0);
        }
        static void Take(Thing item)
        {
            int i = 0;
            string itemName;
            int itemLocation;
            bool itemTake;

            for (i = item.itemID; i >= 0; i++)
            {
                itemName = item.name;
                itemLocation = item.location;
                itemTake = item.cantake;

                if (player.location != itemLocation)
                {
                    Console.WriteLine("Don't see anything like that here");
                    continue;
                }
                if (!itemTake)
                {
                    Console.WriteLine("Can't carry that");
                    continue;
                }
                item.location = 0;
                Console.WriteLine("Taken.");
            }
        }

        static void GetInput(string input)
        { // Learn regex
            // string command;
            // Console.WriteLine("\n");
            string[] words = input.Split(' ');
            switch (words[0])
            {
                case "go":
                    GoParse(words[1]);
                    break;
                default:
                    Console.WriteLine("What?");
                    break;
            }
        }
        static void DoCommand(string command)
        {
            
        }

        static void GoParse(string dirs)
        {
            switch (dirs)
            { // Going to very responsibly figure this out later
                case "north":
                    Go(room1, 0);
                    break;
                case "south":
                    Go(room2, 4);
                    break;
                default:
                    Console.WriteLine("Where are you going?");
                    break;
            }
        }
    }
}
