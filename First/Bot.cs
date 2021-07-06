using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public class Bot
    {
        private readonly IShootableWeapon _weapon;

        public Bot(IShootableWeapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(IDamageable damageable)
        {
            _weapon.Fire(damageable);
        }
    }
}
