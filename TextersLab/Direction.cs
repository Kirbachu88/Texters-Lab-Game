using System.Collections.Generic;

namespace TextersLab
{
    class Direction
    {
        public static string[] validDirs = {
            "n", "ne", "e", "se", "s", "sw", "w", "nw", "up", "down",
            "north", "northeast", "east", "southeast", "south", "southwest", "west", "northwest" };
        public static Dictionary<string, int> dirPairs = new Dictionary<string, int>();

        string dirsName;
        int dirsValue;

        public Direction(string dirsName, int dirsValue)
        {
            this.dirsName = dirsName;
            this.dirsValue = dirsValue;
            dirPairs.Add(dirsName, dirsValue);
        }

        public static void DirsList()
        {
            _ = new Direction("n",  0);
            _ = new Direction("ne", 1);
            _ = new Direction("e",  2);
            _ = new Direction("se", 3);
            _ = new Direction("s",  4);
            _ = new Direction("sw", 5);
            _ = new Direction("w",  6);
            _ = new Direction("nw", 7);
            _ = new Direction("u",  8);
            _ = new Direction("d",  9);

            _ = new Direction("north",      0);
            _ = new Direction("northeast",  1);
            _ = new Direction("east",       2);
            _ = new Direction("southeast",  3);
            _ = new Direction("south",      4);
            _ = new Direction("southwest",  5);
            _ = new Direction("west",       6);
            _ = new Direction("northwest",  7);
            _ = new Direction("up",         8);
            _ = new Direction("down",       9);
        }
    }
}
