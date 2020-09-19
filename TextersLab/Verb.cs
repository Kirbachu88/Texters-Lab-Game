using System;

namespace TextersLab
{
    public class Verb
    {
        public static void GetInput(string input) // Determine which command to use
        { // TODO: Learn regex or XML
          // Feature envy? 
          // Make this return an int and get all these Game.methods(); outta here
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
        }
        /* public string word;
        // Not sure what to do here :\

        public Verb(string word)
        {
            this.word = word;
            // :\
        } */
    }
}
