namespace Commandos.Interfaces
{
    public interface IEnemy
    {
        string Name { get; set; }
        int Health { get; set; }
        bool IsAlive { get; set; }
        string Shout { get; set; }
    }
}