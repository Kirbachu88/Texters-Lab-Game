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
            this.itemID = itemCount++;
            itemNames.Add(this.name, this);
            itemPairs.Add(this.itemID, this);
        }

        public static int getItemCount()
        {
            return itemCount;
        }

        public static void ItemList()
        {
            // LIST OF ITEMS
            _ = new Item("crowbar", "a bent metal stick", 2, true);
            _ = new Item("crate", "a large wooden box", 1, false);
            _ = new Item("chest", "a large metal box", NOWHERE, false);
            _ = new Item("key", "a small metal pick", 2, true);
        }
    }
}
