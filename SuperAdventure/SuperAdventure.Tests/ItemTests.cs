using System;
using Xunit;
using SuperAdventure.models;

namespace SuperAdventure.Tests
{
    public class ItemTests
    {
        public Weapon weapon = new Weapon("Sword", 1);

        [Fact]
        public void WeaponToHealthTest()
        {
            var player = new Player("Zeus");
            player.GrabItem(weapon);

            var enemy = new Player("Tom");

            enemy.LoseHealth(player.DealDamage());

            Assert.Equal(99, enemy.Health);
            Assert.Equal(95, player.GetWeaponHealth());
        }

        [Fact]
        public void WeaponBreakTest()
        {
            var player = new Player("Zeus");
            player.GrabItem(weapon);

            var enemy = new Player("Tom");

            for (int i = 0; i > 19; i++)
            {
                enemy.LoseHealth(player.DealDamage());
            }
            Assert.Equal(80, enemy.Health);

        }
    }
}
