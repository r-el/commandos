namespace Commandos.Interfaces
{
    public interface IWeapon
    {
        string Name { get; }
        string Manufacturer { get; }
        int Bullets { get; }
        
        void Shoot();
    }
}
