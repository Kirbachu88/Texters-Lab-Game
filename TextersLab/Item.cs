using System;
using System.Collections.Generic;

namespace TextersLab
{
    public class Item
    {
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
        } // sort of understanding this.now not really

        public int getItemCount()
        {
            return itemCount;
        }
    }
}
