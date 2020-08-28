using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAdventure.models
{
    public class Relic : Item
    {
        public string Description { get; private set; }

        public Relic(string name, string descript) : base(name)
        {
            this.Description = descript;
        }
    }
}
