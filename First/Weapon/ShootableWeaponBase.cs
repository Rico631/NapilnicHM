using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public abstract class ShootableWeaponBase : IShootableWeapon
    {
        public int Damage { get; private set; }

        public ShootableWeaponBase(int damage)
        {
            if (damage < 0)
                throw new ArgumentException("Value cannot be less then 0", nameof(damage));

            Damage = damage;
        }
        public abstract bool CanShoot();
        public void GiveDamage(IPlayer player)
        {
            if (CanShoot())
            {
                player.TakeDamage(AffectDamage(Damage));
                AfterGiveDamage();
            }
        }
        protected virtual void AfterGiveDamage() { }
        protected virtual int AffectDamage(int damage) => damage;
    }
}
