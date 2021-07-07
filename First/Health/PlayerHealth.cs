using System;

namespace First
{
    public class PlayerHealth : HealthBase
    {
        public PlayerHealth(int health, int? maxHealth = null) : base(health, maxHealth)
        {
        }

        protected override void Death()
        {
            Console.WriteLine("I'm Dead");
        }
    }
}
