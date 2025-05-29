using Commandos.Interfaces;
using Commandos.Enums;

namespace Commandos.Entities
{
    public class Weapon(string name, string manufacturer, int bullets, WeaponType type) : IWeapon
    {
        public string Name { get; private set; } = name;
        public string Manufacturer { get; private set; } = manufacturer;
        public int Bullets { get; private set; } = bullets;
        public WeaponType Type { get; private set; } = type;

        public void Shoot()
        {
            if (Bullets > 0)
            {
                Bullets--;
                Console.WriteLine($"{Name} fired! Bullets left: {Bullets}");
            }
            else
            {
                Console.WriteLine($"{Name} is out of bullets!");
            }
        }

        public override string ToString()
        {
            return $"Weapon [Type: {Type}] - Name: {Name}, Manufacturer: {Manufacturer}, Bullets: {Bullets}";
        }
    }
}
