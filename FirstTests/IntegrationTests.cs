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
        public Player Player { get; set; }
        public Bot Bot { get; set; }

        [SetUp]
        public void Setup()
        {
            var playerHealth = new PlayerHealth(100);
            Player = new Player(playerHealth);

            var weapon = new Weapon(10, 5);
            Bot = new Bot(weapon);
        }

        [Test()]
        public void RR()
        {


            
            


        }
    }
}
