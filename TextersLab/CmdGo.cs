using System;

namespace TextersLab
{
    class CmdGo
    {
        const int NOWHERE = -1;

        public static void GetDirection(string direction)
        {
            if (direction == "")
            {
                Console.WriteLine("What?");
            }
            else
            {
                MovePlayer(Direction.dirPairs[direction]);
            }
        }

        static void MovePlayer(int dirs) // Moving from room to room
        {
            int newLocation = Room.roomPairs[Game.player.location].directions[dirs];
            if (newLocation == NOWHERE)
            {
                Console.WriteLine("You can't go that way.");
            }
            else
            {
                Game.player.location = newLocation;
                GoLook();
            }
        }
        static void GoLook() // Give room description upon entering
        {
            int location = Game.player.location;
            Console.WriteLine($"Location: {Room.roomPairs[location].name}");
        }
    }
}
