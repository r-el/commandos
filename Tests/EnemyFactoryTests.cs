using Xunit;
using Commandos.Factories;
using Commandos.Enums;
using Commandos.Entities.Enemies;

namespace Commandos.Tests
{
    /// <summary>
    /// Unit tests for EnemyFactory class.
    /// Tests enemy creation, management, and factory pattern implementation.
    /// </summary>
    public class EnemyFactoryTests
    {
        private readonly EnemyFactory _factory;

        public EnemyFactoryTests()
        {
            _factory = new EnemyFactory();
        }

        [Fact]
        public void CreateEnemy_WithValidParameters_ShouldReturnEnemy()
        {
            // Arrange
            var name = "Test Zombie";
            var type = EnemyType.Zombie;

            // Act
            var enemy = _factory.CreateEnemy(type, name);

            // Assert
            Assert.NotNull(enemy);
            Assert.Equal(name, enemy.Name);
            Assert.Equal(type, enemy.Type);
            Assert.True(enemy.IsAlive);
        }

        [Theory]
        [InlineData(EnemyType.Zombie, "Zombie Grunt", "Brrrains...")]
        [InlineData(EnemyType.Robot, "Battle Droid", "Beep Boop!")]
        [InlineData(EnemyType.Ghost, "Phantom", "Boo!")]
        [InlineData(EnemyType.Dragon, "Fire Drake", "Roar!")]
        public void CreateEnemy_WithDifferentTypes_ShouldHaveCorrectProperties(
            EnemyType type, string name, string expectedShout)
        {
            // Act
            var enemy = _factory.CreateEnemy(type, name);

            // Assert
            Assert.Equal(type, enemy.Type);
            Assert.Equal(name, enemy.Name);
            Assert.Equal(expectedShout, enemy.Shout);
            Assert.True(enemy.Health > 0);
        }

        [Fact]
        public void GetEnemies_WhenEmpty_ShouldReturnEmptyList()
        {
            // Act
            var enemies = _factory.GetEnemies();

            // Assert
            Assert.NotNull(enemies);
            Assert.Empty(enemies);
        }

        [Fact]
        public void GetEnemies_AfterCreatingEnemies_ShouldReturnAllEnemies()
        {
            // Arrange
            _factory.CreateEnemy(EnemyType.Zombie, "Zombie1");
            _factory.CreateEnemy(EnemyType.Robot, "Robot1");

            // Act
            var enemies = _factory.GetEnemies();

            // Assert
            Assert.Equal(2, enemies.Count);
        }

        [Fact]
        public void RemoveEnemy_WithValidId_ShouldReturnTrueAndRemoveEnemy()
        {
            // Arrange
            var enemy = _factory.CreateEnemy(EnemyType.Zombie, "Test Zombie");
            var initialCount = _factory.GetEnemies().Count;

            // Act
            var result = _factory.RemoveEnemy(enemy.Id);

            // Assert
            Assert.True(result);
            Assert.Equal(initialCount - 1, _factory.GetEnemies().Count);
        }

        [Fact]
        public void RemoveEnemy_WithInvalidId_ShouldReturnFalse()
        {
            // Arrange
            _factory.CreateEnemy(EnemyType.Zombie, "Test Zombie");
            var invalidId = Guid.NewGuid();

            // Act
            var result = _factory.RemoveEnemy(invalidId);

            // Assert
            Assert.False(result);
            Assert.Single(_factory.GetEnemies());
        }

        [Fact]
        public void RemoveEnemy_WithEnemyObject_ShouldReturnTrueAndRemoveEnemy()
        {
            // Arrange
            var enemy = _factory.CreateEnemy(EnemyType.Robot, "Test Robot");
            var initialCount = _factory.GetEnemies().Count;

            // Act
            var result = _factory.RemoveEnemy(enemy);

            // Assert
            Assert.True(result);
            Assert.Equal(initialCount - 1, _factory.GetEnemies().Count);
        }

        [Fact]
        public void GetEnemies_ShouldReturnReadOnlyList()
        {
            // Arrange
            _factory.CreateEnemy(EnemyType.Dragon, "Test Dragon");

            // Act
            var enemies = _factory.GetEnemies();

            // Assert
            Assert.IsAssignableFrom<IReadOnlyList<Enemy>>(enemies);
        }

        [Fact]
        public void CreateEnemy_MultipleEnemies_ShouldHaveUniqueIds()
        {
            // Arrange & Act
            var enemy1 = _factory.CreateEnemy(EnemyType.Zombie, "Zombie1");
            var enemy2 = _factory.CreateEnemy(EnemyType.Zombie, "Zombie2");

            // Assert
            Assert.NotEqual(enemy1.Id, enemy2.Id);
        }

        [Theory]
        [InlineData(EnemyType.Zombie, 100)]
        [InlineData(EnemyType.Robot, 100)]
        [InlineData(EnemyType.Ghost, 100)]
        [InlineData(EnemyType.Dragon, 100)]
        public void CreateEnemy_WithDifferentTypes_ShouldHaveCorrectHealth(EnemyType type, int expectedHealth)
        {
            // Act
            var enemy = _factory.CreateEnemy(type, "Test");

            // Assert
            Assert.Equal(expectedHealth, enemy.Health);
        }
    }
}
