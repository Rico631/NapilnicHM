using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public class Player : IPlayer
    {
        private readonly IHealth _health;

        public Player(IHealth health)
        {
            _health = health;
        }

        public void TakeDamage(int damage)
        {
            _health.Damage(damage);
        }

        public bool IsAlive() => _health.IsAlive();

        public int GetCurrentHealth() => _health.CurrentHealth();
    }
}
