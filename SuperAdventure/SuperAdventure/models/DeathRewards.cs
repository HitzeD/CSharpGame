using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAdventure.models
{
    internal class DeathRewards
    {
        public int Gold { get; set; }
        public int Exp { get; set; }


        public DeathRewards()
        {
            var rand = new Random();
            this.Gold = rand.Next(20, 100);
            this.Exp = rand.Next(10, 30);
        }
    }
}
