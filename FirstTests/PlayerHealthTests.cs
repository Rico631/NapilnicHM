using NUnit.Framework;
using First;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Tests
{
    [TestFixture()]
    public class PlayerHealthTests
    {
        [Test()]
        public void Cannot_Set_Health_Gt_MaxHealth()
        {
            Assert.Catch<ArgumentException>(() => new PlayerHealth(100, 50));
        }

        [Test()]
        public void Damage()
        {
            var health = new PlayerHealth(100);
            health.Damage(99);
            Assert.AreEqual(1, health.CurrentHealth());
            
            health.Damage(99);
            Assert.AreEqual(0, health.CurrentHealth());
            Assert.IsFalse(health.IsAlive());

            health.Damage(99);
            Assert.AreEqual(0, health.CurrentHealth());
            Assert.IsFalse(health.IsAlive());
        }

        [Test()]
        public void Heal()
        {
            var health = new PlayerHealth(100);
            health.Damage(99);
            health.Heal(200);
            Assert.AreEqual(100, health.CurrentHealth());
        }

        [Test()]
        public void Heal2()
        {
            var health = new PlayerHealth(100,200);
            health.Heal(500);
            Assert.AreEqual(200, health.CurrentHealth());
        }
    }
}