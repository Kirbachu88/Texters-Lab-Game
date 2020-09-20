using System;

namespace TextersLab
{
    class CmdTake : Game
    {
        public static string GetTarget(string[] input)
        {
            string target = "";
            for(int i = 0; i < input.Length; i++)
            { // Honestly an unintended consequence is the ability to take at mulitple items at once
                foreach (var item in Item.itemNames)
                {
                    if (Item.itemNames.ContainsKey(input[i]))
                    {
                        CheckItem(Item.itemNames[input[i]]);
                        target = "item";
                        break;
                    }
                }
            }
            return target;
        }
        static void CheckItem(Item item)
        {
            if (player.location != item.location)
            {
                FailItem();
            }
            else if (!item.cantake)
            {
                Console.WriteLine("Can't carry that!");
            }
            else
            {
                item.location = 0;
                Special($"Took the {item.name}.", "yellow");
            }
        }
    }
}
