using System;

namespace First
{
    public interface IHealth
    {
        event Action OnDiedEvent;

        int CurrentHealth();
        void Damage(int count);
        void Heal(int count);

        bool IsAlive();
    }
}