using Commandos.Entities;
using Commandos.Entities.Commandos;
using Commandos.Entities.Enemies;
using Commandos.Enums;
using Commandos.Factories;

namespace Commandos
{
    /// <summary>
    /// Simplest possible game class that connects the three factories.
    /// </summary>
    public class Game
    {
        // The three factories
        private readonly CommandoFactory _commandoFactory = new();
        private readonly EnemyFactory _enemyFactory = new();
        private readonly WeaponFactory _weaponFactory = new();

        /// <summary>
        /// Creates a commando.
        /// </summary>
        public Commando CreateCommando(CommandoType type, string name, string codeName)
        {
            return _commandoFactory.CreateCommando(type, name, codeName);
        }

        /// <summary>
        /// Creates an enemy.
        /// </summary>
        public Enemy CreateEnemy(EnemyType type, string name)
        {
            return _enemyFactory.CreateEnemy(type, name);
        }

        /// <summary>
        /// Creates a weapon.
        /// </summary>
        public Weapon CreateWeapon(WeaponType type, string? name = null)
        {
            return _weaponFactory.CreateWeapon(type, name);
        }
    }
}
