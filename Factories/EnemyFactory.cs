using Commandos.Entities.Enemies;

namespace Commandos.Factories
{
    public class EnemyFactory
    {
        public static Enemy CreateEnemy(string name)
        {
            return new Enemy(name);
        }
    }
}