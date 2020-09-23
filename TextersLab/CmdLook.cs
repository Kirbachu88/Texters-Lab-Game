using System;
using System.Linq;

namespace TextersLab
{
    class CmdLook
    {
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
                        PrintItems(Game.player.location);
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

        public static void PrintItems(int room = Game.INVENTORY)
        {
            if (room != 0)
            {
                Console.WriteLine(Room.roomPairs[room].desc);
            }
            bool itemHere = false;
            for (int i = 0; i < Item.itemPairs.Count; i++)
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

        private static void PrintDesc(string target)
        {
            int itemLocation = Item.itemNames[target].location;
            if (itemLocation == Game.player.location || itemLocation == Game.INVENTORY)
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
