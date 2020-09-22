using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace TextersLab
{
    class Combo
    {
        public static List<Tuple<string, string>> ValidCombos = new List<Tuple<string, string>>();
        public static Dictionary<int, string> comboPairs = new Dictionary<int, string>();

        public string item1;
        public string item2;
        public string effectDesc;
        public int effectID;
        public static int effectCount;

        public Combo(string item1, string item2, string effectDesc)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.effectDesc = effectDesc;
            effectID = effectCount++;
            ValidCombos.Add(new Tuple<string, string>(item1, item2));
            comboPairs.Add(effectID, effectDesc);
        }

        public static void ComboList()
        {
            _ = new Combo("crowbar", "crate", "You pry open the crate.\nInside the crate was a key.");
            _ = new Combo("key", "door", "The lock clicks with the turn of the key.");
        }
    }
}
