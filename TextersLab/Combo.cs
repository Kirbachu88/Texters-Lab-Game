using System;
using System.Collections.Generic;

namespace TextersLab
{
    class Combo
    {
        public static List<Tuple<string, string>> ValidCombos = new List<Tuple<string, string>>();
        public static Dictionary<int, Combo> comboPairs = new Dictionary<int, Combo>();

        public string item1;
        public string item2;
        public string effectName;
        public string effectDesc;
        public bool effectActivated = false;
        public int effectID;
        public static int effectCount;

        public Combo(string item1, string item2, string effectName, string effectDesc)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.effectName = effectName;
            this.effectDesc = effectDesc;
            effectID = effectCount++;
            ValidCombos.Add(new Tuple<string, string>(item1, item2));
            comboPairs.Add(effectID, this);
        }

        public static void ComboList()
        {
            _ = new Combo("crowbar", "crate", "unbox", "You pry open the crate.\nInside the crate was a key.");
            _ = new Combo("key", "door", "unlock", "The lock clicks with the turn of the key.");
        }
    }
}
