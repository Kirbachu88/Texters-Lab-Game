using System.Collections.Generic;

namespace TextersLab
{
    public class Item
    {
        const int NOWHERE = -1;
        public static Dictionary<string, Item> itemNames = new Dictionary<string, Item>();
        public static Dictionary<int, Item> itemPairs = new Dictionary<int, Item>();

        public string name;
        public string desc;
        public int location;
        public bool cantake;
        public int itemID;
        public static int itemCount;

        public Item(string name, string desc, int location, bool cantake)
        {
            this.name = name;
            this.desc = desc;
            this.location = location;
            this.cantake = cantake;
            itemID = itemCount++;
            itemNames.Add(name, this);
            itemPairs.Add(itemID, this);
        }

        public static int getItemCount()
        {
            return itemCount;
        }

        public static void ItemList()
        {
            // LIST OF ITEMS
            _ = new Item("crowbar", "A bent metal stick", 2, true);
            _ = new Item("crate", "It's a large sealed wooden box", 1, false);
            _ = new Item("key", "A small metal pick, but only for one lock.", NOWHERE, true);
            _ = new Item("door", "Seems to be locked.", 2, false);
        }
    }
}
