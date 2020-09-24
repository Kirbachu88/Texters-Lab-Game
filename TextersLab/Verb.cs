using System;
using System.Collections.Generic;

namespace TextersLab
{
    public class Verb : Game
    {
        public static Dictionary<string, Action<string[]>> verbPairs = new Dictionary<string, Action<string[]>>();
        public string word;

        public Verb(string word, Action<string[]> action)
        {
            this.word = word;
            verbPairs.Add(word, action);
        } // Friendship ended with switch case now dictionary and action are my best friends

        public static void ReadInput(string input)
        {
            string[] splitWords = SplitInput(input);
            CallFunction(splitWords[0], splitWords);
        }

        static string[] SplitInput(string input)
        {
            string[] words = input.Split(' ');
            return words;
        }

        static void CallFunction(string methodName, string[] words)
        {
            if (verbPairs.ContainsKey(methodName))
            {
                verbPairs[methodName](words);
            }
            else
            {
                verbPairs["go"](words);
                // Attempt travel by default
                // Move simply with "N" or "North" etc.
            }
        }

        public static void VerbList()
        { // Positives, much cleaner, negatives, every method needs to have string[] parameters now
            _ = new Verb("go", Go);
            _ = new Verb("inventory", Inv);
            _ = new Verb("inv", Inv);
            _ = new Verb("look", Look);
            _ = new Verb("check", Look);
            _ = new Verb("examine", Look);
            _ = new Verb("take", Take);
            _ = new Verb("grab", Take);
            _ = new Verb("get", Take);
            _ = new Verb("use", Use);
            _ = new Verb("help", Help);
        }
    }
}
