using Xunit;
using Commandos;
using Commandos.Enums;

namespace Commandos.Tests
{
    /// <summary>
    /// Integration tests for simplified Game class.
    /// Tests the three factory connections.
    /// </summary>
    public class GameIntegrationTests
    {
        private readonly Game _game;

        public GameIntegrationTests()
        {
            _game = new Game();
        }

        [Fact]
        public void CreateCommando_ShouldReturnValidCommando()
        {
            // Act
            var commando = _game.CreateCommando(CommandoType.Regular, "John", "Alpha");

            // Assert
            Assert.NotNull(commando);
            Assert.Equal("Alpha", commando.CodeName);
        }

        [Fact]
        public void CreateEnemy_ShouldReturnValidEnemy()
        {
            // Act
            var enemy = _game.CreateEnemy(EnemyType.Zombie, "Hans");

            // Assert
            Assert.NotNull(enemy);
            Assert.Equal("Hans", enemy.Name);
            Assert.Equal(EnemyType.Zombie, enemy.Type);
        }

        [Fact]
        public void CreateWeapon_ShouldReturnValidWeapon()
        {
            // Act
            var weapon = _game.CreateWeapon(WeaponType.Rifle);

            // Assert
            Assert.NotNull(weapon);
            Assert.Equal(WeaponType.Rifle, weapon.Type);
        }

        [Fact]
        public void CreateWeapon_WithCustomName_ShouldUseCustomName()
        {
            // Act
            var weapon = _game.CreateWeapon(WeaponType.Pistol, "Custom Gun");

            // Assert
            Assert.NotNull(weapon);
            Assert.Equal("Custom Gun", weapon.Name);
            Assert.Equal(WeaponType.Pistol, weapon.Type);
        }

        [Fact]
        public void CreateMultipleEntities_ShouldWorkCorrectly()
        {
            // Act
            var commando1 = _game.CreateCommando(CommandoType.Air, "Sky", "Eagle");
            var commando2 = _game.CreateCommando(CommandoType.Sea, "Water", "Shark");
            var enemy1 = _game.CreateEnemy(EnemyType.Robot, "Terminator");
            var enemy2 = _game.CreateEnemy(EnemyType.Dragon, "Smaug");
            var weapon1 = _game.CreateWeapon(WeaponType.Sniper);
            var weapon2 = _game.CreateWeapon(WeaponType.Grenade, "Boom Stick");

            // Assert
            Assert.NotNull(commando1);
            Assert.NotNull(commando2);
            Assert.NotNull(enemy1);
            Assert.NotNull(enemy2);
            Assert.NotNull(weapon1);
            Assert.NotNull(weapon2);
            
            Assert.Equal("Eagle", commando1.CodeName);
            Assert.Equal("Shark", commando2.CodeName);
            Assert.Equal("Terminator", enemy1.Name);
            Assert.Equal("Smaug", enemy2.Name);
            Assert.Equal("Boom Stick", weapon2.Name);
        }
    }
}
