using System;

namespace First
{
    public abstract class HealthBase : IHealth
    {
        private readonly int _maxHealth;
        private int _health;
        private bool _isDead;
        public HealthBase(int health, int? maxHealth = null)
        {
            _health = health;
            if (maxHealth == null)
                _maxHealth = health;
            else
            {
                if (maxHealth < health)
                    throw new ArgumentException("Cannot be less then health", nameof(maxHealth));
                if(maxHealth < 0)
                    throw new ArgumentException("Cannot be less then 0", nameof(maxHealth));
                
                _maxHealth = (int)maxHealth;
            }

            _isDead = false;
        }

        public virtual event Action OnDeath;

        public virtual void Damage(int count)
        {
            if (!_isDead)
            {
                if (_health - count < 0)
                {
                    _health = 0;
                    _isDead = true;
                    OnDeath?.Invoke();
                }
                else
                    _health -= count;
            }
        }

        public virtual void Heal(int count)
        {
            if (_health + count > _maxHealth)
                _health = _maxHealth;
            else
                _health += count;
        }

        public virtual bool IsAlive() => _health > 0;
    }
}
