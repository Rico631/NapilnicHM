using System;

namespace First
{
    public class PlayerHealth : HealthBase
    {
        public PlayerHealth(int health, int? maxHealth = null) : base(health, maxHealth)
        {
        }

        public override event Action OnDeath = () => Console.WriteLine("I'm Dead");
    }
}
