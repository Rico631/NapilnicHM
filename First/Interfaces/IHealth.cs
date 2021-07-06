using System;

namespace First
{
    public interface IHealth
    {
        event Action OnDeath;
        void Damage(int count);
        void Heal(int count);

        bool IsAlive();
    }
}