namespace First
{
    public interface IShootable
    {

        void Fire(IDamageable player);
        bool CanShoot();
    }
}