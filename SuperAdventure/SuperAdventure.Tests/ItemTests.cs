using System;
using Xunit;
using SuperAdventure.models;

namespace SuperAdventure.Tests
{
    public class ItemTests
    {
        public Weapon weapon = new Weapon("Sword", 80);

        [Fact]
        public void WeaponToHealthTest()
        {
            var player = new Player("Zeus");
            player.GrabItem(weapon);

            var enemy = new Player("Tom");

            enemy.LoseHealth(player.DealDamage());

            Assert.Equal(20, enemy.Health);
            Assert.Equal(95, player.GetWeaponHealth());
        }
    }
}
