using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace TextersLab
{
    class Thing
    {
        public string name;
        public string desc;
        public int location;
        public bool cantake;

        public Thing(string aName, string aDesc, int aLocation, bool aCantake)
        {
            name = aName;
            desc = aDesc;
            location = aLocation;
            cantake = aCantake;
        }
    }
    class Room
    {
        public string name;
        public string desc;
        public int[] directions = new int[10];

        public Room(string aName, string aDesc, int[] aDirections)
        {
            name = aName;
            desc = aDesc;
            directions = aDirections;
        }
    }

    class Player
    {
        public int location;
    }
}
