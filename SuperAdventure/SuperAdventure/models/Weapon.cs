using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAdventure.models
{
    public class Weapon : Item
    {
        public int Damage { get; private set; }
        public int Health { get; set; }

        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
            Health = 100;
        }
    }
}
