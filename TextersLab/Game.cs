using System;
using System.Linq;

namespace TextersLab
{
    public class Game
    {
        #region Game Conditions
        public static Person player = new Person(1); // Player in starting room
        public static string playerName = "";
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

            VFX.Special("Type in commands and hit ENTER to continue."); 
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
            } while (!winGame);
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
            CmdInv.PrintInv();
        }
        public static void Look(string[] input)
        {
            if (input.Length == 1)
            {
                CmdLook.LookRoom();
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
            if (input.Length < 3)
            {
                Console.WriteLine("Use what?");
            }
            else
            {
                CmdUse.GetItems(input);
            }
        }

        public static void FailItem()
        {
            Console.WriteLine("Don't see that here...");
        }
        #endregion
    }
}
