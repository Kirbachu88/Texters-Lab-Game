using System;

namespace TextersLab
{
    class CmdInv
    {
        public static void PrintInv(int room = 0) // Player inventory = Room 0
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
    }
}
