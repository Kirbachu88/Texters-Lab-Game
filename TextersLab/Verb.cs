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

        public static void ReadInput(string input)
        {
            string[] splitWords = SplitInput(input);
            // GetFunction(splitWords[0]);
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
    }
}
