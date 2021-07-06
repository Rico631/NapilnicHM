using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public abstract class ShootableWeaponBase : IShootableWeapon
    {
        private static readonly string st_Str_Exception_LT = "Value cannot be less then 0";
        private static readonly string st_Str_Exception_CannotShoot = "Not Enought bullets";

        private readonly int _damage;
        private int _bullets;


        public ShootableWeaponBase(int damage, int bullets)
        {
            List<Exception> exceptions = new List<Exception>();

            if (_damage < 0)
                exceptions.Add(new ArgumentException(st_Str_Exception_LT, nameof(damage)));
            if (_damage < 0)
                exceptions.Add(new ArgumentException(st_Str_Exception_LT, nameof(damage)));
            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);

            _damage = damage;
            _bullets = bullets;
        }

        protected virtual event Action ReloadAction;

        protected virtual void SetAmmo(int count)
        {
            _bullets += count;
        }

        public bool AmmoIsEmpty() => _bullets == 0;

        public void Fire(IDamageable obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (AmmoIsEmpty())
            {
                ReloadAction?.Invoke();
            }

            obj.TakeDamage(_damage);
            _bullets -= 1;
        }
    }
}
