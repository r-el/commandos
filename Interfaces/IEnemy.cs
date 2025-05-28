using Commandos.Enums;

namespace Commandos.Interfaces
{
    public interface IEnemy
    {
        Guid Id { get; set; }
        string Name { get; set; }
        EnemyType Type { get; set; }
        int Health { get; set; }
        bool IsAlive { get; set; }
        string Shout { get; set; }
    }
}