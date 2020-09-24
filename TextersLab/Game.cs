using System;
using System.Linq;

namespace TextersLab
{
    public class Game
    {
        #region Game Conditions
        public static Person player = new Person(1); // Player in starting room
        public static string playerName = "";
        public const int INVENTORY = 0;
        public static bool winGame = false;
        #endregion

        public static void Initialize()
        {
            Console.SetWindowSize(55, 25);
            Combo.ComboList();
            Item.ItemList();
            Room.RoomList();
            Verb.VerbList();
            Direction.DirsList();

            StartGame();
        }

        #region Gameplay
        private static void StartGame() // Introduce game and get player's name
        {
            VFX.Screen(0);

            Console.WriteLine("Welcome! Your mission today is to get to your lab.\nIt would be dangerous to leave it unattended.\nYou find yourself in an unknown series of rooms,\nwith quite a journey ahead.\n\nPress ENTER to continue...");
            Console.ReadLine();

            Console.WriteLine("Let's get to know more about you.");
            VFX.Special("What is your name?");
            playerName = Console.ReadLine();

            while (playerName.Length > 30 || playerName.Length == 0)
            {
                Console.WriteLine("Uh, you go by a nickname?");
                playerName = Console.ReadLine();
            }

            Console.WriteLine($"Good luck, {playerName}!\n");
            Console.ReadLine();
            Console.Clear();

            VFX.Special("Type in commands and hit ENTER to continue.\nType HELP for a list of basic commands."); 
            PlayGame();
        }
        private static void PlayGame()
        {
            do
            {
                Console.Write(">");
                string input = Console.ReadLine().ToLower();
                Verb.ReadInput(input);
                Console.WriteLine();
                if (player.location == 3)
                {
                    winGame = true;
                }
            } while (!winGame);

            EndGame();
        }

        private static void EndGame()
        {
            VFX.Screen(10);
            Console.ReadLine();
        }
        #endregion

        #region Commands
        public static void Go(string[] dirs)
        {
            string direction = "";
            for (int i = 0; i < dirs.Length; i++)
            {
                if (Direction.validDirs.Contains(dirs[i]))
                {
                    direction = dirs[i];
                    break;
                }
            }
            CmdGo.GetDirection(direction);
        }
        public static void Inv(string[] input)
        {
            VFX.Special("You're carrying:", "yellow");
            CmdLook.PrintItems();
        }
        public static void Look(string[] input)
        {
            if (input.Length == 1)
            {
                CmdLook.PrintItems(Game.player.location);
            }
            else
            {
                string target = CmdLook.GetTarget(input);
                if (target == "")
                {
                    FailItem();
                }
            }
        }
        public static void Take(string[] input)
        {
            if (input.Length == 1)
            {
                Console.WriteLine("Take what?");
            }
            else
            {
                string target = CmdTake.GetTarget(input);
                if (target == "")
                {
                    FailItem();
                }
            }
        }
        public static void Use(string[] input)
        {
            if (input.Length < 2)
            {
                Console.WriteLine("Use what?");
            }
            else if (input.Length < 3)
            {
                Console.WriteLine("What do you want to use it on?");
            }
            else
            {
                CmdUse.GetItems(input);
            }
        }

        public static void Help(string[] input)
        { // Adding more detailed help dialogue when the player says "Help take?"
            if (input.Length == 2)
            {
                switch (input[1])
                {
                    case "go":
                        Console.WriteLine("\"Go North\"\n" +
                            "May travel N, NE, E, SE, S, SW, W, NW, Up, Down\n" +
                            "Writing \"Go\" is not necessary.");
                        break;
                    case "look":
                        Console.WriteLine("\"Look at [item/room/inventory]\"\n" +
                            "May write \"Look\" with no other words to look at room.");
                        break;
                    case "take": case "grab": case "get":
                        Console.WriteLine("\"Take [item]\"\n" +
                            "Note: some items are not able to be picked up.");
                        break;
                    case "inv": case "inventory":
                        Console.WriteLine("\"Inv\" or \"Inventory\"\n" +
                            "Lists out every time you have in your possesion.");
                        break;
                    case "use":
                        Console.WriteLine("\"Use [item] on [some other item]\"\n" +
                            "Certain items may be used on others for some effect.");
                        break;
                    case "help":
                        Console.WriteLine("\"Help\" will give a list of basic commands.\n" +
                            "\"Help [command]\" gives more info on specific commands.");
                        break;
                    case "me": case "stuck": case "hint":
                        VFX.Special("Words echoed in your head...\n" + playerName + "!\nRemember to take anything useful\nand use those useful things!", "blue");
                        break;
                    default:
                        VFX.Special("Basic commands:\nGo, Look, Take, Inv, Use");
                        Console.WriteLine("Type \"Help [command]\" for further information.");
                        break;
                }
            }
            else
            {
                VFX.Special("Basic commands:\nGo, Look, Take, Inv, Use");
                Console.WriteLine("Type \"Help [command]\" for further information.");
            }
        }

        public static void FailItem()
        {
            Console.WriteLine("Don't see that here...");
        }
        #endregion
    }
}
