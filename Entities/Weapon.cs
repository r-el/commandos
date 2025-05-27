using Commandos.Interfaces;

namespace Commandos.Entities
{
    public class Weapon(string name, string manufacturer, int bullets) : IWeapon
    {
        public string Name { get; private set; } = name;
        public string Manufacturer { get; private set; } = manufacturer;
        public int Bullets { get; private set; } = bullets;

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
    }
}
