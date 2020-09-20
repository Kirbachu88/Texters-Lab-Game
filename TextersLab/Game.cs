using System;
using System.Collections.Generic;

namespace TextersLab
{
    public class Game
    {
        #region Locations, Directions, and Game Conditions
        const int NOWHERE = -1;
        const string DIRSLIST =
            "n ne e se s sw w nw up down" +
            "north northeast east southeast south southwest west northwest";

        static Player player = new Player(1); // Player in starting room
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

            Items();
            Rooms();
            Verbs();
            Special("Type in commands and hit ENTER to continue."); // TODO: Make a HELP command
            return playerName;
        }
        public static void PlayGame()
        {
            do
            {
                Console.Write(">");
                string input = Console.ReadLine().ToLower();
                Verb.ReadInput(input);
                Console.WriteLine();
            } while (!winGame);
        }
        #endregion

        #region Item Commands
        public static void DoInv()
        {
            Special("You're carrying:", "yellow");
            Inv();
        }
        static void Inv(int room = 0) // Player inventory = Room 0
        {
            if (room != 0)
            {
                Console.WriteLine(Room.roomPairs[room].desc);
            }
            bool itemHere = false;
            for (int i = 0;  i < Item.itemPairs.Count; i++)
            {
                if (Item.itemPairs[i].location == room) // Check if item is in the immediate area
                {
                    Console.WriteLine("A " + Item.itemPairs[i].name);
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
                        for (int j = 0; j < Item.itemPairs.Count; j++)
                        {
                            for (int k = 0; k < target.Length; k++)
                            {
                                if (Item.itemPairs[j].name == target[k] && !itemHere)
                                {
                                    if (Item.itemPairs[j].location == player.location || Item.itemPairs[j].location == 0)
                                    {
                                        itemHere = true;
                                        Console.WriteLine("It's " + Item.itemPairs[j].desc);
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
        public static void Take(string[] words)
        { // TODO: Try foreach
            bool itemHere = false;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < Item.itemNames.Count; j++)
                {
                    if (Item.itemPairs[j].name == words[i])
                    {
                        itemHere = true;
                        Item item = Item.itemNames[words[i]];
                        string itemName = item.name;
                        int itemLocation = item.location;
                        bool itemTake = item.cantake;

                        if (player.location != itemLocation)
                        {
                            Console.WriteLine("Don't see that here.");
                            break;
                        }
                        else if (!itemTake)
                        {
                            Console.WriteLine("Can't carry that!");
                            break;
                        }
                        else
                        {
                            item.location = 0;
                            Special($"Took the {itemName}.", "yellow");
                            break;
                        }
                    }
                }
            }
            if (!itemHere)
            {
                Console.WriteLine("Don't see that here.");
            }
        }
        public static void Use(string[] input)
        {
            // Use x on y
        }
        #endregion

        #region Navigation Commands
        public static void GoParse(string[] dirs) // Look for directions in player's input
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
        static void Go(int dirs) // Moving from room to room
        {
            int newLocation = Room.roomPairs[player.location].directions[dirs];
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
            Console.WriteLine($"Location: {Room.roomPairs[location].name}");
        }
        #endregion

        #region List of Items/Rooms/Verbs
        public static void Items()
        {
            // LIST OF ITEMS
            _ = new Item("crowbar", "a bent metal stick", 2, true);
            _ = new Item("crate", "a large wooden box", 1, false);
            _ = new Item("chest", "a large metal box", NOWHERE, false);
            _ = new Item("key", "a small metal pick", 2, true);
        }

        public static void Rooms()
        {
            // LIST OF ROOMS { N NE E SE S SW W NW U D }
            Room inv = new Room("player inv", "",
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            Room entrance1 = new Room("Entrance", "This room is quite lacking in accomdations.",
            new int[] {  2, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            Room hallway2 = new Room("Hallway", "There are some loose items strewn about.",
            new int[] { -1, -1, -1, -1,  1, -1, -1, -1, -1, -1 });
            Room lockedRoom3 = new Room("Kitchen", "It's eerily clean.", 
            new int[] { -1, -1, -1, -1,  2, -1, -1, -1, -1, -1 });
        }

        public static void Verbs()
        {
            _ = new Verb("look", Look);
            _ = new Verb("check", Look);
            _ = new Verb("examine", Look);
            _ = new Verb("take", Take);
            _ = new Verb("go", GoParse);
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
