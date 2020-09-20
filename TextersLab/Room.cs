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
        public static void RoomList()
        {
            // LIST OF ROOMS { N NE E SE S SW W NW U D }
            Room inv = new Room("player inv", "",
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            Room entrance1 = new Room("Entrance", "This room is quite lacking in accomdations.",
            new int[] { 2, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            Room hallway2 = new Room("Hallway", "Full of clutter, loose items strewn about.",
            new int[] { -1, -1, -1, -1, 1, -1, -1, -1, -1, -1 });
            Room lockedRoom3 = new Room("Kitchen", "It's eerily clean.",
            new int[] { -1, -1, -1, -1, 2, -1, -1, -1, -1, -1 });
        }
    }
}
