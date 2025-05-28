using Commandos.Interfaces;
namespace Commandos.Entities.Enemies
{
    public class Enemy(string name) : IEnemy
    {
        public string Name { get; set; } = name;
        public int Health { get; set; } = 100;
        public bool IsAlive { get; set; } = true;
        public string Shout { get; set; } = "I'm Enemy!!!";

        public override string ToString()
        {
            return $"Enemy Name: {Name}, Health: {Health}, IsAlive: {IsAlive}, Shout: {Shout}";
        }
    }
}