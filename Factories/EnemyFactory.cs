using Commandos.Entities.Enemies;
using Commandos.Enums;

namespace Commandos.Factories
{
    public class EnemyFactory
    /// <summary>
    /// Factory class responsible for creating, managing, and removing enemy instances.
    /// Maintains an internal collection of all created enemies.
    /// </summary>
    /// <remarks>
    /// This factory uses the Factory Pattern to create different types of enemies
    /// with predefined characteristics based on the enemy type.
    /// </remarks>
    {
        private readonly List<Enemy> enemies = [];

        /// <summary>
        /// Creates a new enemy instance based on the specified enemy type and name.
        /// </summary>
        /// <param name="name">The name to assign to the created enemy.</param>
        /// <param name="enemyType">The type of enemy to create (Zombie, Robot, Ghost, or Dragon).</param>
        /// <returns>A new Enemy instance with the specified type, name, and appropriate sound effect.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid enemy type is provided.</exception>
        /// <remarks>
        /// The created enemy is automatically added to the internal enemies collection.
        /// Each enemy type has a predefined sound effect:
        /// - Zombie: "Brrrains..."
        /// - Robot: "Beep Boop!"
        /// - Ghost: "Boo!"
        /// - Dragon: "Roar!"
        /// </remarks>
        public Enemy CreateEnemy(EnemyType enemyType, string name)
        {
            Enemy enemy = enemyType switch
            {
                EnemyType.Zombie => new Enemy(name, enemyType, "Brrrains..."),
                EnemyType.Robot => new Enemy(name, enemyType, "Beep Boop!"),
                EnemyType.Ghost => new Enemy(name, enemyType, "Boo!"),
                EnemyType.Dragon => new Enemy(name, enemyType, "Roar!"),
                _ => throw new ArgumentException("Invalid enemy type"),
            };
            enemies.Add(enemy);
            return enemy;
        }
        
        /// <summary>
        /// Retrieves a read-only view of all enemies currently managed by the factory.
        /// </summary>
        /// <returns>A read-only list containing all enemy instances.</returns>
        /// <remarks>
        /// Returns a read-only wrapper around the internal collection to prevent external modification
        /// while avoiding the overhead of creating a copy.
        /// </remarks>
        public IReadOnlyList<Enemy> GetEnemies()
        {
            return enemies.AsReadOnly();
        }

        /// <summary>
        /// Removes an enemy from the factory's collection by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the enemy to remove.</param>
        /// <returns>True if the enemy was found and removed; false if no enemy with the specified ID exists.</returns>
        /// <remarks>
        /// This method performs a linear search through the enemies collection to find
        /// the enemy with the matching ID. The operation is O(n) where n is the number of enemies.
        /// </remarks>
        public bool RemoveEnemy(Guid id)
        {
            var enemy = enemies.FirstOrDefault(e => e.Id == id);
            if (enemy == null)
                return false; // Enemy not found

            enemies.Remove(enemy);
            return true;
        }

        /// <summary>
        /// Removes a specific enemy instance from the factory's collection.
        /// </summary>
        /// <param name="enemy">The enemy instance to remove.</param>
        /// <returns>True if the enemy was found and removed; false if the enemy is not in the collection.</returns>
        /// <remarks>
        /// This method removes the enemy by reference comparison. The operation is O(n) where n is the number of enemies.
        /// If the enemy parameter is null, the method returns false.
        /// </remarks>
        public bool RemoveEnemy(Enemy enemy)
        {
            if (enemy == null)
                return false;

            return enemies.Remove(enemy);
        }
    }
}