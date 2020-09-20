using System;
using System.Collections.Generic;

namespace TextersLab
{
    public class Verb
    {
        public static Dictionary<string, Action<string[]>> verbPairs = new Dictionary<string, Action<string[]>>();
        public string word;

        public Verb(string word, Action<string[]> action)
        {
            this.word = word;
            verbPairs.Add(word, action);
        } // Friendship ended with switch case now dictionary and action are my best friends

        public static void ParseInput(string input)
        {
            string[] splitWords = SplitInput(input);
            GetFunction(splitWords[0]);
            CallFunction(splitWords[0], splitWords);
        }

        static string[] SplitInput(string input)
        {
            string[] words = input.Split(' ');
            return words;
        }

        static Action<string[]> GetFunction(string key)
        {
            if (verbPairs.ContainsKey(key))
            {
                return verbPairs[key];
            }
            else
            {
                return null;
            }
        }

        static void CallFunction(string key, string[] words)
        {
            verbPairs[key](words);
        }

        /* public static void SwitchInput(string input) // Determine which command to use
        { // TODO: Learn regex or XML
          // Feature envy? 
          // Make this return an int and get all these Game.methods(); outta here
          // Make the method unpack the arguments?
            string[] words = input.Split(' ');
            if (words.Length > 1)
            {
                switch (words[0])
                {
                    case "look":
                    case "check":
                    case "examine":
                        Game.Look(words);
                        break;
                    case "go":
                        Game.GoParse(words);
                        break;
                    case "take":
                    case "get":
                    case "grab":
                        Game.Take(words);
                        break;
                    case "use":
                        Game.Use(words);
                        break;
                    default:
                        Console.WriteLine("What?");
                        break;
                }
            }
            else // Valid one-word commands
            {
                switch (words[0])
                {
                    case "inventory":
                    case "inv":
                        Game.DoInv();
                        break;
                    case "look":
                        Game.Look();
                        break;
                    default:
                        Game.GoParse(words); // Player enters "N" or "North" only
                        break;
                }
            }
        } */
    }
}
