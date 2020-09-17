using System;
using System.Collections.Generic;

namespace TextersLab
{
    public class Game
    {
        #region List Declaration and Game Conditions
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
        #endregion

        #region Gameplay
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
        #endregion

        #region Keywords
        static void GetInput(string input) // Determine which command to use
        { // TODO: Learn regex or XML
            string[] words = input.Split(' ');
            if (words.Length > 1)
            {
                switch (words[0])
                {
                    case "look":
                    case "check":
                    case "examine":
                        Look(words);
                        break;
                    case "go":
                        GoParse(words);
                        break;
                    case "take":
                    case "get":
                    case "grab":
                        Take(words[1]);
                        break;
                    default:
                        Console.WriteLine("What?");
                        break;
                }
            }
            else // Player enters one word only
            {
                string[] defaultWords = { "foo", "bar" };
                switch (words[0])
                {
                    case "inventory":
                    case "inv":
                        DoInv();
                        break;
                    case "look":
                        Look();
                        break;
                    /* case "take":
                        Take(defaultWords); */
                    default:
                        GoParse(words); // Player enters "N" or "North" only
                        break;
                }
            }
        }
        #endregion

        #region Item Commands
        static void DoInv()
        {
            Special("You're carrying:", "yellow");
            Inv();
        }
        static void Inv(int room = 0) // Player inventory = Room 0
        {
            bool itemHere = false;
            for (int i = 0;  i < itemPairs.Count; i++)
            {
                if (itemPairs[i].location == room) // Check if item is in the immediate area
                {
                    Console.WriteLine("A " + itemPairs[i].name);
                    itemHere = true;
                }
            }
            if (!itemHere) // No items in room/inventory
            {
                if (room > 0)
                {
                    Console.WriteLine("There's nothing else of interest here.");
                }
                else
                {
                    Console.WriteLine("Nothing!");
                }
            }
        }
        public static void Look() // If there's no look target, examine room
        {
            string[] lookDefault = {"room"};
            Look(lookDefault);
        }
        public static void Look(string[] target) // Look at target
        { // TODO: Take into account "Room" AND "Item" both being typed?
            bool itemHere = false;
            for (int i = 0; i < target.Length; i++)
            {
                switch (target[i])
                {   // "Look at room" "Look around" etc.
                    case "room": case "area": case "around":
                        itemHere = true;
                        Inv(player.location);
                        break;
                    default: // Check if the player typed an existing item name
                        for (int j = 0; j < itemPairs.Count; j++)
                        {
                            for (int k = 0; k < target.Length; k++)
                            {
                                if (itemPairs[j].name == target[k] && !itemHere)
                                {
                                    if (itemPairs[j].location == player.location || itemPairs[j].location == 0)
                                    {
                                        itemHere = true;
                                        Console.WriteLine("It's " + itemPairs[j].desc);
                                        // If multiple items are typed, it will give the earliest occuring item according to the dictionary.
                                    }
                                    break;
                                }
                            }
                        }
                        break;
                } 
            } // Check if the player typed gibberish
            if (!itemHere)
            {
                Console.WriteLine("Don't see anything like that here.");
            }
        }
        static void Take(string item) // TODO: Have this method search through input array (ex. "Take THE crowbar"). Get rid of exception handling.
        {
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
                    Special($"Took the {itemName}.", "yellow");
                }
            }
            catch
            {
                Console.WriteLine("Don't see that here.");
            }
        }
        #endregion

        #region Navigation Commands
        static void Go(int dirs) // Moving from room to room
        {
            int newLocation = roomPairs[player.location].directions[dirs];
            if (newLocation == NOWHERE)
            {
                Console.WriteLine("You can't go that way.");
            }
            else
            {
                player.location = newLocation;
                GoLook();
            }
        }
        static void GoLook() // Give room description upon entering
        {
            int location = player.location;
            Console.WriteLine($"Location: {roomPairs[location].desc}");
        }
        static void GoParse(string[] dirs) // Look for directions in player's input
        { 
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
        #endregion

        #region List of All Items and Rooms
        // TODO: Make a method so that I don't have to type .Add to dictionaries every time...

        public static void Items(Dictionary<int, Thing> itemPairs)
        {
            // LIST OF ITEMS
            Thing item1 = new Thing("crowbar", "a bent metal stick", 2, true);
            Thing item2 = new Thing("crate", "a large wooden box", 1, false);

            // Items by NUMBER
            itemPairs.Add(0, item1);
            itemPairs.Add(1, item2);

            // Items by NAME
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
        #endregion

        #region Visuals
        static void Screen(int selection) // Logo and other art
        {
            switch (selection) {
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
                default:
                    Console.Title = "Placeholder Title";
                    break;
            }
        }
        static void Special(string prompt, string color = "cyan") // Write a given string with colors Red/Blue/Yellow/Cyan (Default)
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
        #endregion
    }
}
