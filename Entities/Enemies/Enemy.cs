using Commandos.Enums;
using Commandos.Interfaces;
namespace Commandos.Entities.Enemies
{
    public class Enemy(string name) : IEnemy
    {
        // Fields and properties
        private int _health = 100;
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = name;
        public EnemyType Type { get; set; }
        public int Health 
        { 
            get => _health;
            set => _health = Math.Max(0, value); // Health cannot be negative
        }
        public bool IsAlive { get; set; } = true;
        public string Shout { get; set; } = "I'm Enemy!!!";

        // Constructor with type
        public Enemy(string name, EnemyType type) : this(name)
        {
            Type = type;
        }
        // Constructor with type and shout
        public Enemy(string name, EnemyType type, string shout) : this(name, type)
        {
            Shout = shout ?? "I'm Enemy!!!";
        }

        public override string ToString()
        {
            return $"Enemy [ID: {Id}] - Name: {Name}, Type: {Type}, Health: {Health}, Status: {(IsAlive ? "Alive" : "Dead")}, Shout: \"{Shout}\"";
        }
    }
}