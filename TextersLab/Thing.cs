using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TextersLab
{
    public class Thing
    {
        public string name;
        public string desc;
        public int location;
        public bool cantake;
        public int itemID;
        public static int itemCount;

        public Thing(string name, string desc, int location, bool cantake)
        {
            this.name = name;
            this.desc = desc;
            this.location = location;
            this.cantake = cantake;
            this.itemID = itemCount++;
        } // sort of understanding this.now not really

        public int getItemCount()
        {
            return itemCount;
        }
    }
    public class Room
    {
        public const int NDIRS = 10; // N NE E SE S SW W NW UP DOWN
        public string name;
        public string desc;
        public int[] directions = new int[NDIRS];

        public Room(string name, string desc, int[] directions)
        {
            this.name = name;
            this.desc = desc;
            this.directions = directions;
        }
    }

    public class Player
    {
        public int location;

        public Player(int location)
        {
            this.location = location;
        }
    }

    public class Verb
    {
        public string word;
        // Not sure what to do here :\

        public Verb(string word)
        {
            this.word = word;
            // :\
        }
    }
}
