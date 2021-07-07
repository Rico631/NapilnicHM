using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using First;

namespace First.Tests
{
    [TestFixture()]
    public class IntegrationTests
    {
        [Test()]
        public void Bot_Shooting_Five_Times_In_Player()
        {
            var playerHealth = new PlayerHealth(100);
            IPlayer player = new Player(playerHealth);

            var weapon = new ShootableWeapon(10, 5);
            var bot = new Bot(weapon);

            
            for(int i = 0; i <= 5; i++)
            {
                bot.OnSeePlayer(player);
            }

            Assert.AreEqual(50, player.GetCurrentHealth());
            Assert.IsTrue(player.IsAlive());
            Assert.AreEqual(0, weapon.Bullets);
            Assert.IsFalse(weapon.CanShoot());
        }

        [Test()]
        public void Bot_Shooting_Six_Times_In_Player()
        {
            var playerHealth = new PlayerHealth(100);
            IPlayer player = new Player(playerHealth);

            var weapon = new ShootableWeapon(10, 5);
            var bot = new Bot(weapon);


            for (int i = 0; i <= 6; i++)
            {
                bot.OnSeePlayer(player);
            }

            Assert.AreEqual(50, player.GetCurrentHealth());
            Assert.IsTrue(player.IsAlive());
            Assert.AreEqual(0, weapon.Bullets);
            Assert.IsFalse(weapon.CanShoot());
        }
        [Test()]
        public void Bot_Shooting_In_Player()
        {
            var playerHealth = new PlayerHealth(100);
            IPlayer player = new Player(playerHealth);

            var weapon = new ShootableWeapon(150, 5);
            var bot = new Bot(weapon);


            for (int i = 0; i < 3; i++)
            {
                bot.OnSeePlayer(player);
            }

            Assert.AreEqual(0, player.GetCurrentHealth());
            Assert.IsFalse(player.IsAlive());
            Assert.AreEqual(2, weapon.Bullets);
            Assert.IsTrue(weapon.CanShoot());
        }
    }
}
