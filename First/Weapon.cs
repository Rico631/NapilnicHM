using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public class Weapon : WeaponBase
    {
        private static readonly string st_Str_Exception_LT = "Value cannot be less then 0";
        private static readonly string st_Str_Exception_CannotShoot = "Not Enought bullets";

        private readonly int _damage;
        private int _bullets;


        public Weapon(int damage, int bullets)
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

        public override bool CanShoot() => _bullets > 0;

        public override void Fire(IDamageable obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (!CanShoot())
                throw new Exception(st_Str_Exception_CannotShoot);

            obj.TakeDamage(_damage);
            _bullets -= 1;
        }
    }
}
