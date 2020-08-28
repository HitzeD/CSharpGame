using System;
using System.Collections.Generic;

namespace SuperAdventure.models
{
    public class Enemy : Person
    {
        private Weapon Weapon;


        public Enemy(string name) : base(name)
        {
            GenerateWeapon();
        }

        private void GenerateWeapon()
        {
            var list = new List<Weapon>()
            {
                new Weapon("Stick", 5),
                new Weapon("Sword", 15),
                new Weapon("Pipe Wrench", 8)
            };

            var rand = new Random();
            int ctr = rand.Next(0, 2);

            this.Weapon = list[ctr];
        }

        public int DealDamage()
        {
            return Weapon.Damage;
        }
    }
}