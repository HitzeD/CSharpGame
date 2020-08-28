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
                new Room("Mountain Top Peak", "It's so refreshing up here!"),
                new Room("Fire Nation", "Oww HOT HOT HOT!"),
                new Room("Air Temple", "I've been watching too much Avatar!"),
                new Room("Water Temple", "Who would fight here?!"),
                new Room("Dark Valley", "It's so refreshing up here!")
            };

            foreach (var room in roomList)
            {
                rooms.AddLast(room);
            }

        }

    }
}
