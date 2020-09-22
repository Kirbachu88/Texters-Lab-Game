using System;
using System.Linq;

namespace TextersLab
{
    class CmdLook
    {
        public static void LookRoom()
        {
            CmdInv.PrintInv(Game.player.location);
        }
        public static string GetTarget(string[] input)
        {
            string[] area = { "room", "around", "area" };
            string[] inv = { "inventory", "inv" };
            string target = "";

            for (int i = 0; i < input.Length; i++)
            { // Honestly an unintended consequence is the ability to look at mulitple items at once
                foreach (var item in Item.itemNames)
                {
                    if (Item.itemNames.ContainsKey(input[i]))
                    {
                        target = input[i];
                        PrintDesc(target);
                        break;
                    }
                    else if (area.Contains(input[i]))
                    {
                        LookRoom();
                        target = "room";
                        break;
                    }
                    else if (inv.Contains(input[i]))
                    {
                        Game.Inv(input);
                        target = "inv";
                        break;
                    }
                }
            }
            return target;
        }
        private static void PrintDesc(string target)
        {
            int itemLocation = Item.itemNames[target].location;
            if (itemLocation == Game.player.location || itemLocation == 0)
            {
                Console.WriteLine(Item.itemNames[target].desc);
            }
            else
            {
                Game.FailItem();
            }
        }
    }
}
