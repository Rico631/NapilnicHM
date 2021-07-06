namespace First
{
    public interface IShootableWeapon
    {

        void Fire(IDamageable player);
        bool AmmoIsEmpty();


    }
}