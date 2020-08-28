using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAdventure.models
{
    internal class DeathRewards
    {
        public int Gold { get; set; }
        public int Exp { get; set; }


        public DeathRewards(int gold, int exp)
        {
            this.Gold = gold;
            this.Exp = exp;
        }
    }
}
