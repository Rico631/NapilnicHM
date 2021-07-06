using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public class ShootableWeapon : ShootableWeaponBase
    {
        public ShootableWeapon(int damage, int bullets) : base(damage, bullets)
        {
        }

        protected override event Action ReloadAction = () => { Console.WriteLine("Reload"); };
    }
}
