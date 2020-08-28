﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAdventure.models
{
    public class Room
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Item> items { get; set; }


        public Room(string name, string descript)
        {
            Name = name;
            Description = descript;
            addItems();
        }

        private void addItems()
        {

            // This initializes a few items to populate the room

            var list = new List<Item>() { 
                new Weapon("Stick", 5), 
                new Weapon("Sword", 15),
                new Relic("HearthStone", "A stone of life!"),
                new Weapon("Master Sword", 20), 
                new Relic("Stick of Jealousness", "Makes all people Jealous"),
                new Relic("Toilet Paper", "Just a waste of Space"),
                new Weapon("Pipe Wrench", 8),
                new Relic("Drangon Heart", "Gives strength to those in need"),
                new Relic("Shirt of Greatness", "It looks plain cool"),
                new Weapon("BFG", 100)
            };

            // Random is used to create a loop of 'random' amount of times

            var rand = new Random();
            int ctr = rand.Next(0, 4);

            // Random is used to pick a few random items from the list

            for (int i = 0; i <= ctr; i++)
            {
                items.Add(items[rand.Next(0, 9)]);
            }
            
        }
    }
}