using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAdventure.models
{
    public class RoomGenerator
    {
        public LinkedList<Room> rooms { get; private set; }

        public RoomGenerator()
        {
            rooms = new LinkedList<Room>();
            rooms.AddFirst(new Room("Home", "This is where you reside!"));
            GenerateRooms();
        }

        private void GenerateRooms()
        {
            var roomList = new List<Room>()
            {
                new Room("Dark Cave", "There are bats lining the ceiling!"),
                new Room("Cemetary", "Who knew the dead were so scary!"),
                new Room("Grocery Store", "Who would fight here?!"),
                new Room("Mountain Top Peak", "It's so refreshing up here!")
            };

            var rand = new Random();
            int ctr = rand.Next(0, 3);

            for (int i = 0; i <= 4; i++)
            {
                rooms.AddLast(roomList[ctr]);
            }

        }
    }
}
