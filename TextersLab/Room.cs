using System.Collections.Generic;

namespace TextersLab
{
    public class Room
    {
        public static Dictionary<int, Room> roomPairs = new Dictionary<int, Room>();

        public const int NDIRS = 10; // N NE E SE S SW W NW UP DOWN
        public string name;
        public string desc;
        public int roomID;
        public static int roomCount;
        public int[] directions = new int[NDIRS];

        public Room(string name, string desc, int[] directions)
        {
            this.name = name;
            this.desc = desc;
            this.directions = directions;
            this.roomID = roomCount++;
            roomPairs.Add(this.roomID, this);
        }

        public int getRoomCount()
        {
            return roomCount;
        }
    }
}
