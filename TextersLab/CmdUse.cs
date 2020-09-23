using System;
using System.Collections.Generic;

namespace TextersLab
{
    class CmdUse
    {
        public static void GetItems(string[] input)
        {
            Item[] itemsInInput = new Item[2];
            for (int i = 0; i < 1; i++)
            {
                foreach (var word in input)
                {
                    if (Item.itemNames.ContainsKey(word))
                    {
                        itemsInInput[i++] = Item.itemNames.GetValueOrDefault(word);
                    }
                }
            }

            if (itemsInInput[0] != null && itemsInInput[1] != null)
            {
                CheckItemLocation(itemsInInput[0], itemsInInput[1]);
            }
            else
            {
                Console.WriteLine("What are you doing?");
            }
            
            // The realization hits me that I can make an array of Items
        }

        private static void CheckItemLocation(Item item1, Item item2)
        {
            bool itemHere1 = item1.location == Game.player.location || item1.location == 0;
            bool itemHere2 = item2.location == Game.player.location || item2.location == 0;

            if (itemHere1 && itemHere2)
            {
                GetEffectID(item1.name, item2.name);
            }
            else
            {
                Console.WriteLine("What are you doing?");
            }
        }

        private static void GetEffectID(string item1, string item2)
        {
            int effectID = Combo.ValidCombos.IndexOf(Tuple.Create(item1, item2));
            ActivateEffect(effectID);
        }

        private static void ActivateEffect(int effectID)
        {
            Combo currentEffect = Combo.comboPairs.GetValueOrDefault(effectID);

            if (currentEffect != null)
            {
                if (!currentEffect.effectActivated)
                {
                    Console.WriteLine(currentEffect.effectDesc);
                    currentEffect.effectActivated = true;

                    switch (currentEffect.effectName)
                    { // Trying to think of a better way to do this
                        case "unbox":
                            Item.GetItemByName("key").location = 1;
                            Item.GetItemByName("crate").desc = "It's been pried open.";
                            break;
                        case "unlock":
                            Room.GetRoomByName("Hallway").directions[0] = 3;
                            Item.GetItemByName("door").desc = "It's open now!";
                            break;
                        default:
                            Console.WriteLine("What?");
                            break;
                      // I'd really like one for if you try to use the crowbar on random things, without having to do each one individually
                    }
                }
                else
                {
                    Console.WriteLine("Already did that!");
                }
                
            }
            else
            {
                Console.WriteLine("That won't do any good.");
            }
        }
    }
}
