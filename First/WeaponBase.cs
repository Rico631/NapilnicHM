using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public abstract class WeaponBase : IWeapon
    {
        public abstract bool CanShoot();

        public abstract void Fire(IDamageable player);
    }
}
