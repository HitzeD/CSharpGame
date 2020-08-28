using System;
using Xunit;
using SuperAdventure.models;


namespace SuperAdventure.Tests
{
    public class PersonTests
    {
        private Player player = new Player("Zerku");

        [Fact]
        public void PlayerWeaponTest()
        {
            var w1 = new Weapon("Sword", 100);

            player.GrabItem(w1);
            Assert.Equal(w1, player.GetWeapon());
        }

        [Fact]
        public void PlayerRelicTest()
        {
            var rel1 = new Relic("thing 1", "idk");
            var rel2 = new Relic("thing 2", "idk");
            var rel3 = new Relic("thing 3", "idk");

            player.GrabItem(rel1);
            player.GrabItem(rel2);
            player.GrabItem(rel3);

            Assert.Equal(rel2, player.Relics[1]);

        }
    }
}
