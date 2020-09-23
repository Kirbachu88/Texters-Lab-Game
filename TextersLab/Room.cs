using System.Collections.Generic;

namespace TextersLab
{
    public class Room
    {
        public static Dictionary<int, Room> roomPairs = new Dictionary<int, Room>();
        public static Dictionary<string, Room> roomNames = new Dictionary<string, Room>();

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
            roomID = roomCount++;
            roomPairs.Add(roomID, this);
            roomNames.Add(name, this);
        }

        public int getRoomCount()
        {
            return roomCount;
        }

        public static Room GetRoomByName(string roomName)
        {
            Room room = roomNames.GetValueOrDefault(roomName);
            return room;
        }
        public static void RoomList()
        {
            // LIST OF ROOMS { N NE E SE S SW W NW U D }
            _ = new Room("player inventory", "",
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            _ = new Room("Entrance", "This room is quite lacking in accomdations.",
            new int[] { 2, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
            _ = new Room("Hallway", "Full of clutter, loose items strewn about.",
            new int[] { -1, -1, -1, -1, 1, -1, -1, -1, -1, -1 });
            _ = new Room("Kitchen", "It's eerily clean.",
            new int[] { -1, -1, -1, -1, 2, -1, -1, -1, -1, -1 });
        }
    }
}
