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

        public virtual event Action OnDiedEvent;
        public virtual event Action OnDieingEvent;

        public int CurrentHealth() => _health;

        public void Damage(int damage)
        {
            if (!_isDead)
            {
                if (_health - AffectDamage(damage) < 0)
                {
                    _health = 0;
                    _isDead = true;
                    OnDieingEvent?.Invoke();
                    Death();
                    OnDiedEvent?.Invoke();
                    
                }
                else
                    _health -= AffectDamage(damage);
            }
        }

        public void Heal(int heal)
        {
            if (_health + heal > _maxHealth)
                _health = _maxHealth;
            else
                _health += heal;
        }

        public bool IsAlive() => _health > 0;

        protected virtual int AffectDamage(int damage)
        {
            return damage;
        }
        protected abstract void Death();
    }
}
