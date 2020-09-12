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
        public static Dictionary<int, Room> roomPairs = new Dictionary<int, Room>();

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
            Rooms(roomPairs);

            do
            {
                string input = Console.ReadLine().ToLower();
                GetInput(input);
                DoCommand(input);
            } while (!winGame);
        }

        // LIST OF THINGS
        public static Thing item1 = new Thing("crowbar", "a bent metal stick", 2, true, Thing.itemCount);

        public static void Rooms(Dictionary<int, Room> roomPairs)
        {
            Room inv = new Room("player inv", "",
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            Room room1 = new Room("Entrance","some place",
            new int[] { 2, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            Room room2 = new Room("Not Entrance",
            "some other place",
            new int[] { -1, -1, -1, -1, 1, -1, -1, -1, -1, -1 });

            roomPairs.Add(0, inv);
            roomPairs.Add(1, room1);
            roomPairs.Add(2, room2);
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

        static void Inv(Room room, int location)
        {

        }
        public static void Look(Dictionary<int, Room> roomPairs)
        {
            int location = player.location;
            Console.WriteLine(roomPairs[location].desc);
        }

        static void Go(int dirs) // Moving from room to room
        {
            int newLocation = 0; // TODO: Big brain how to get the new location number so we can't go to -1 rooms

            for (int d = dirs; d != -1; d = newLocation)
            {
                newLocation = dirs;
                if (newLocation == -1)
                {
                    Console.WriteLine("You can't go that way.");
                }
                else
                {
                    player.location = roomPairs[player.location].directions[dirs];
                    Look(roomPairs);
                    break;
                }
            }
        }
        static void goNorth()
        {
            int dirs = 0; // Hmm...
            Go(dirs);
        }
        static void goSouth()
        {
            int dirs = 4; // Hmm...
            Go(dirs);
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
                    goNorth();
                    break;
                case "south":
                    goSouth();
                    break;
                default:
                    Console.WriteLine("Where are you going?");
                    break;
            }
        }
    }
}
