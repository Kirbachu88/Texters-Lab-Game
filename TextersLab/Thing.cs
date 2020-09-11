using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TextersLab
{
    class Thing
    {
        public string name;
        public string desc;
        public int location;
        public bool cantake;
        public int itemID;
        public static int itemCount;

        public Thing(string name, string desc, int location, bool cantake, int itemID)
        {
            this.name = name;
            this.desc = desc;
            this.location = location;
            this.cantake = cantake;
            this.itemID = itemID++;
            itemCount++;
        } // sort of understanding this.now not really

        public int getItemCount()
        {
            return itemCount;
        }
    }
    class Room
    {
        public const int NDIRS = 10;
        public const int NOWHERE = -1;

        public string name;
        public string desc;
        public int[] directions = new int[10];

        public Room(string name, string desc, int[] directions)
        {
            this.name = name;
            this.desc = desc;
            this.directions = directions;
        }
    }

    class Player
    {
        public int location;

        public Player(int location)
        {
            this.location = location;
        }
    }

    class Verb
    {
        public string word;
        // Not sure what to do here :\

        public Verb(string word)
        {
            this.word = word;
        }
    }

    // LIST OF THINGS

    // LIST OF ROOMS

    // PLAYER STARTING LOCATION
    
}
