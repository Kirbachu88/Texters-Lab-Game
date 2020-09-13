using System;
using System.Collections.Generic;

namespace TextersLab
{
    public class Game
    {
        const int NOWHERE = -1;
        const string DIRSLIST =
            "n ne e se s sw w nw up down" +
            "north northeast east southeast south southwest west northwest";
        static Dictionary<string, Thing> itemNames = new Dictionary<string, Thing>();
        static Dictionary<int, Thing> itemPairs = new Dictionary<int, Thing>();
        static Dictionary<int, Room> roomPairs = new Dictionary<int, Room>();
        public static Player player = new Player(1); // Player in starting room
        public static string playerName = "";
        public static bool winGame = false;

        public static string StartGame() // Introduce game and get player's name
        {
            Screen(0);

            Console.WriteLine("Welcome! Your mission today is to get to your lab.\nIt would be dangerous to leave it unattended.\nYou find yourself in an unknown series of rooms,\nwith quite a journey ahead.\n\nPress ENTER to continue...");
            Console.ReadLine();

            Console.WriteLine("Let's get to know more about you.");
            Special("What is your name?");
            playerName = Console.ReadLine();

            while (playerName.Length > 30 || playerName.Length == 0)
            {
                Console.WriteLine("Uh, you go by a nickname?");
                playerName = Console.ReadLine();
            }

            Console.WriteLine($"Good luck, {playerName}!\n");
            Console.ReadLine();
            Console.Clear();

            Items(itemPairs);
            Rooms(roomPairs);
            Special("Type in commands and hit ENTER to continue."); // TODO: Make a HELP command
            return playerName;
        }
        public static void PlayGame()
        {
            do
            {
                Console.Write(">");
                string input = Console.ReadLine().ToLower();
                GetInput(input);
                Console.WriteLine();
            } while (!winGame);
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
        static void Special(string prompt, string color = "cyan") // Color text (cyan default) with extra prompt options with red/blue/yellow text
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
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            Console.WriteLine(prompt);
            Console.ResetColor();
        }

        static void Inv(int area = -1)
        {
            // Give list of player's inventory OR items in room
        }
        public static void Look() // No target, look at room and items within
        {
            int location = player.location;
            Console.WriteLine(roomPairs[location].desc);
        }
        public static void Look(string[] target) // Look at target
        {
            if (target[1] == "inventory" || target[1] == "inv")
            {
                Inv();
            }
            Console.WriteLine("It's pitch-black, you use echolocation to find things.");
        }

        static void Go(int dirs) // Moving from room to room
        {
            int newLocation = roomPairs[player.location].directions[dirs];
            if (newLocation == -1)
            {
                Console.WriteLine("You can't go that way.");
            }
            else
            {
                player.location = newLocation;
                Look();
            }
        }

        static void DoInv()
        {
            Inv(); // TODO: More big brain
        }
        static void Take(string item)
        { // TOFIX: Player entering item name that does not exist
            try
            {
                Thing target = itemNames[item];
                string itemName = target.name;
                int itemLocation = target.location;
                bool itemTake = target.cantake;

                if (player.location != itemLocation)
                {
                    Console.WriteLine("Don't see that here.");
                }
                else if (!itemTake)
                {
                    Console.WriteLine("Can't carry that!");
                }
                else
                {
                    target.location = 0;
                    Special($"Took the {itemName}.");
                }
            }
            catch
            {
                Console.WriteLine("Don't see that here.");
            }
        }

        static void GetInput(string input)
        { // TODO: Learn regex or XML
            string[] words = input.Split(' ');
            if (words.Length > 1)
            {
                switch (words[0])
                {
                    case "look":
                        Look(words);
                        break;
                    case "go":
                        GoParse(words);
                        break;
                    case "take": case "get":
                        Take(words[1]);
                        break;
                    default:
                        Console.WriteLine("What?");
                        break;
                }
            }
            else // Player enters one word only
            {
                switch (words[0])
                {
                    case "inventory": case "inv":
                        Inv();
                        break;
                    case "look":
                        Look();
                        break;
                    default:
                        GoParse(words); // Player enters "N" or "North" only
                        break;
                }
            }
        }
        static void GoParse(string[] dirs)
        { // Look for directions in player's input
            string parsedDirs = "";
            for (int i = 0; i < dirs.Length ; i++)
            {
                if (DIRSLIST.Contains(dirs[i]))
                {
                    parsedDirs = dirs[i];
                }
            }
            switch (parsedDirs)
            {
                case "n": case "north":
                    Go(0);
                    break;
                case "ne": case "northeast":
                    Go(1);
                    break;
                case "e": case "east":
                    Go(2);
                    break;
                case "se": case "southeast":
                    Go(3);
                    break;
                case "s": case "south":
                    Go(4);
                    break;
                case "sw": case "southwest":
                    Go(5);
                    break;
                case "w": case "west":
                    Go(6);
                    break;
                case "nw": case "northwest":
                    Go(7);
                    break;
                case "up":
                    Go(8);
                    break;
                case "down":
                    Go(9);
                    break;
                default:
                    Console.WriteLine("What?");
                    break;
            }
        }
        public static void Items(Dictionary<int, Thing> itemPairs)
        {
            // LIST OF DIRECTIONS
            Thing dir0 = new Thing("north",     "", NOWHERE, false);
            Thing dir1 = new Thing("northeast", "", NOWHERE, false);
            Thing dir2 = new Thing("east",      "", NOWHERE, false);
            Thing dir3 = new Thing("southeast", "", NOWHERE, false);
            Thing dir4 = new Thing("south",     "", NOWHERE, false);
            Thing dir5 = new Thing("southwest", "", NOWHERE, false);
            Thing dir6 = new Thing("west",      "", NOWHERE, false);
            Thing dir7 = new Thing("northwest", "", NOWHERE, false);
            Thing dir8 = new Thing("up",        "", NOWHERE, false);
            Thing dir9 = new Thing("down",      "", NOWHERE, false);

            // LIST OF ITEMS
            Thing item1 = new Thing("crowbar", "a bent metal stick", 2, true);
            Thing item2 = new Thing("crate", "a large wooden box", 1, false);

            itemPairs.Add(0, dir0);
            itemPairs.Add(1, dir1);
            itemPairs.Add(2, dir2);
            itemPairs.Add(3, dir3);
            itemPairs.Add(4, dir4);
            itemPairs.Add(5, dir5);
            itemPairs.Add(6, dir6);
            itemPairs.Add(7, dir7);
            itemPairs.Add(8, dir8);
            itemPairs.Add(9, dir9);

            // Items by number
            itemPairs.Add(10, item1);
            itemPairs.Add(11, item2);

            // Items by name
            itemNames.Add("crowbar", item1);
            itemNames.Add("crate", item2);
        }
        public static void Rooms(Dictionary<int, Room> roomPairs)
        {
            // LIST OF ROOMS
            Room inv = new Room("player inv", "",
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            Room room1 = new Room("Entrance", "some place",
            new int[] { 2, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            Room room2 = new Room("Not Entrance",
            "some other place",
            new int[] { -1, -1, -1, -1, 1, -1, -1, -1, -1, -1 });

            roomPairs.Add(0, inv);
            roomPairs.Add(1, room1);
            roomPairs.Add(2, room2);
        }
    }
}
