using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAdventure.models
{
    public class Player : Person
    {
        private Weapon Weapon;
        public List<Relic> Relics { get; private set; }
        public int Gold { get; private set; }
        public int Exp { get; private set; }
        public int PlayerLevel { get; private set; }



        public Player(string name) : base(name)
        {
            Weapon = new Weapon("Fist", 3);
            Relics = new List<Relic>();
            Gold = 0;
            Exp = 0;
        }

        public Weapon GetWeapon()
        {
            return this.Weapon;
        }

        public void GrabItem(Item item)
        {
            if (item.GetType() == typeof(Weapon))
            {
                this.Weapon = (Weapon)item;
            }
            else if (item.GetType() == typeof(Relic))
            {
                Relics.Add((Relic)item);
            }
        }

        public int DealDamage()
        {
            if (Weapon.Health - 2 > 0)
            {
                Weapon.HealthLoss(2);
            }
            else
            {
                Weapon = null;
            }

            if (Weapon == null)
            {
                Weapon = new Weapon("Fist", 3);
                return Weapon.Damage;
            }
            else
            {
                return Weapon.Damage;
            }
        }

        public int GetWeaponHealth()
        {
            return Weapon.Health;
        }

        public void GetGold(int gold)
        {
            Gold += gold;
        }

        public void GainExp(int exp)
        {
            if ((exp + Exp) > 100)
            {
                PlayerLevel++;
                this.Exp = (Exp + exp) - 100;
            }
            else
            {
                this.Exp += exp;
            }
        }

    }
}
