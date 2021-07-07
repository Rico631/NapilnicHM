using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public class Bot
    {
        private readonly IWeapon _weapon;

        public Bot(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(IPlayer player)
        {
            _weapon.GiveDamage(player);
        }
    }
}
