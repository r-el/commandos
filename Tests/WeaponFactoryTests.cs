using Xunit;
using Commandos.Factories;
using Commandos.Enums;
using Commandos.Entities;

namespace Commandos.Tests
{
    /// <summary>
    /// Unit tests for WeaponFactory class.
    /// Tests weapon creation, management, and factory pattern implementation.
    /// </summary>
    public class WeaponFactoryTests
    {
        private readonly WeaponFactory _factory;

        public WeaponFactoryTests()
        {
            _factory = new WeaponFactory();
        }

        [Fact]
        public void CreateWeapon_WithValidType_ShouldReturnWeapon()
        {
            // Arrange
            var weaponType = WeaponType.Rifle;

            // Act
            var weapon = _factory.CreateWeapon(weaponType);

            // Assert
            Assert.NotNull(weapon);
            Assert.Equal(weaponType, weapon.Type);
        }

        [Fact]
        public void CreateWeapon_WithCustomName_ShouldUseCustomName()
        {
            // Arrange
            var weaponType = WeaponType.Pistol;
            var customName = "Custom Pistol";

            // Act
            var weapon = _factory.CreateWeapon(weaponType, customName);

            // Assert
            Assert.Equal(customName, weapon.Name);
            Assert.Equal(weaponType, weapon.Type);
        }

        [Theory]
        [InlineData(WeaponType.Rifle, "AK-47", "Assault Corp", 30)]
        [InlineData(WeaponType.Pistol, "Glock-19", "Handgun Ltd", 12)]
        [InlineData(WeaponType.Sniper, "Barrett M82", "Precision Arms", 5)]
        [InlineData(WeaponType.Grenade, "Frag Grenade", "Explosive Co", 1)]
        public void CreateWeapon_WithDifferentTypes_ShouldHaveCorrectProperties(
            WeaponType type, string expectedName, string expectedManufacturer, int expectedBullets)
        {
            // Act
            var weapon = _factory.CreateWeapon(type);

            // Assert
            Assert.Equal(type, weapon.Type);
            Assert.Equal(expectedName, weapon.Name);
            Assert.Equal(expectedManufacturer, weapon.Manufacturer);
            Assert.Equal(expectedBullets, weapon.Bullets);
        }

        [Fact]
        public void GetWeaponCount_WhenEmpty_ShouldReturnZero()
        {
            // Act
            var count = _factory.GetWeaponCount();

            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void GetWeaponCount_AfterCreatingWeapons_ShouldReturnCorrectCount()
        {
            // Arrange
            _factory.CreateWeapon(WeaponType.Rifle);
            _factory.CreateWeapon(WeaponType.Pistol);

            // Act
            var count = _factory.GetWeaponCount();

            // Assert
            Assert.Equal(2, count);
        }

        [Fact]
        public void GetWeapons_WhenEmpty_ShouldReturnEmptyList()
        {
            // Act
            var weapons = _factory.GetWeapons();

            // Assert
            Assert.NotNull(weapons);
            Assert.Empty(weapons);
        }

        [Fact]
        public void GetWeapons_AfterCreatingWeapons_ShouldReturnAllWeapons()
        {
            // Arrange
            _factory.CreateWeapon(WeaponType.Rifle);
            _factory.CreateWeapon(WeaponType.Sniper);

            // Act
            var weapons = _factory.GetWeapons();

            // Assert
            Assert.Equal(2, weapons.Count);
        }

        [Fact]
        public void GetWeaponsByType_WithMatchingType_ShouldReturnFilteredList()
        {
            // Arrange
            _factory.CreateWeapon(WeaponType.Rifle);
            _factory.CreateWeapon(WeaponType.Pistol);
            _factory.CreateWeapon(WeaponType.Rifle, "Custom Rifle");

            // Act
            var rifles = _factory.GetWeaponsByType(WeaponType.Rifle);

            // Assert
            Assert.Equal(2, rifles.Count);
            Assert.All(rifles, w => Assert.Equal(WeaponType.Rifle, w.Type));
        }

        [Fact]
        public void GetWeaponsByType_WithNoMatchingType_ShouldReturnEmptyList()
        {
            // Arrange
            _factory.CreateWeapon(WeaponType.Rifle);

            // Act
            var grenades = _factory.GetWeaponsByType(WeaponType.Grenade);

            // Assert
            Assert.Empty(grenades);
        }

        [Fact]
        public void RemoveWeapon_ExistingWeapon_ShouldReturnTrueAndDecreaseCount()
        {
            // Arrange
            var weapon = _factory.CreateWeapon(WeaponType.Pistol);
            var initialCount = _factory.GetWeaponCount();

            // Act
            var result = _factory.RemoveWeapon(weapon);

            // Assert
            Assert.True(result);
            Assert.Equal(initialCount - 1, _factory.GetWeaponCount());
        }

        [Fact]
        public void RemoveWeapon_NonExistingWeapon_ShouldReturnFalse()
        {
            // Arrange
            _factory.CreateWeapon(WeaponType.Rifle);
            var nonExistingWeapon = new Weapon("Test", "Test", 10, WeaponType.Pistol);

            // Act
            var result = _factory.RemoveWeapon(nonExistingWeapon);

            // Assert
            Assert.False(result);
            Assert.Equal(1, _factory.GetWeaponCount());
        }

        [Fact]
        public void GetWeapons_ShouldReturnReadOnlyList()
        {
            // Arrange
            _factory.CreateWeapon(WeaponType.Sniper);

            // Act
            var weapons = _factory.GetWeapons();

            // Assert
            Assert.IsAssignableFrom<IReadOnlyList<Weapon>>(weapons);
        }

        [Fact]
        public void CreateWeapon_MultipleWeapons_ShouldCreateSeparateInstances()
        {
            // Act
            var weapon1 = _factory.CreateWeapon(WeaponType.Rifle);
            var weapon2 = _factory.CreateWeapon(WeaponType.Rifle);

            // Assert
            Assert.NotSame(weapon1, weapon2);
            Assert.Equal(weapon1.Name, weapon2.Name); // Same type, same default name
            Assert.Equal(weapon1.Type, weapon2.Type);
        }
    }
}
