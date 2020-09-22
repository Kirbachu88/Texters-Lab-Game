using System;
using System.Collections.Generic;

namespace TextersLab
{
    class CmdUse
    {
        public static void GetItems(string[] input)
        {
            GetEffectID("crowbar", "crate");
        }

        private static void GetEffectID(string item1, string item2)
        {
            int effectID = Combo.ValidCombos.IndexOf(Tuple.Create(item1, item2));
            ActivateEffect(effectID);
        }

        private static void ActivateEffect(int effectID)
        {
            Console.WriteLine(Combo.comboPairs.GetValueOrDefault(effectID));
        }
    }
}
