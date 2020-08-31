using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SuperAdventure.models
{
    public abstract class Person
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        public Person(string name)
        {
            Name = name;
            Health = 100;
        }

        public void LoseHealth(int damage)
        {
            if (damage > this.Health)
            {
                this.Health = 0;
                
                if (this.GetType() == typeof(Player))
                {
                    MessageBox.Show("You have died, please start over.", "OOps!");
                    Application.Current.MainWindow.Show();
                }
            }
            else
            {
                this.Health -= damage;
            }
        }

        //private DeathRewards DeathScene()
        //{
        //    var rand = new Random();
        //    var rewards = new DeathRewards(rand.Next(15, 100), rand.Next(5, 20));

        //    return rewards;
        //}
    }
}
