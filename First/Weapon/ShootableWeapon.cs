using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public class ShootableWeapon : ShootableWeaponBase
    {
        public int Bullets { get; private set; }
        public ShootableWeapon(int damage, int bullets) : base(damage)
        {
            Bullets = bullets;
        }

        public override bool CanShoot() => Bullets > 0;

        protected override void AfterGiveDamage()
        {
            Bullets -= 1;
        }
    }
}
