using Xunit;
using Commandos.Factories;
using Commandos.Enums;
using Commandos.Entities.Commandos;

namespace Commandos.Tests
{
    /// <summary>
    /// Unit tests for CommandoFactory class.
    /// Tests factory pattern implementation and commando management functionality.
    /// </summary>
    public class CommandoFactoryTests
    {
        private readonly CommandoFactory _factory;

        public CommandoFactoryTests()
        {
            _factory = new CommandoFactory();
        }

        [Fact]
        public void CreateCommando_WithRegularType_ShouldReturnBasicCommando()
        {
            // Arrange
            var name = "John";
            var codeName = "Alpha";

            // Act
            var commando = _factory.CreateCommando(CommandoType.Regular, name, codeName);

            // Assert
            Assert.NotNull(commando);
            Assert.Equal(codeName, commando.CodeName);
            Assert.Equal(typeof(Commando), commando.GetType());
        }

        [Fact]
        public void CreateCommando_WithAirType_ShouldReturnAirCommando()
        {
            // Arrange
            var name = "Alex";
            var codeName = "Eagle";

            // Act
            var commando = _factory.CreateCommando(CommandoType.Air, name, codeName);

            // Assert
            Assert.NotNull(commando);
            Assert.Equal(codeName, commando.CodeName);
            Assert.IsType<AirCommando>(commando);
        }

        [Fact]
        public void CreateCommando_WithSeaType_ShouldReturnSeaCommando()
        {
            // Arrange
            var name = "Marina";
            var codeName = "Kraken";

            // Act
            var commando = _factory.CreateCommando(CommandoType.Sea, name, codeName);

            // Assert
            Assert.NotNull(commando);
            Assert.Equal(codeName, commando.CodeName);
            Assert.IsType<SeaCommando>(commando);
        }

        [Fact]
        public void GetCommandoCount_WhenEmpty_ShouldReturnZero()
        {
            // Arrange & Act
            var count = _factory.GetCommandoCount();

            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void GetCommandoCount_AfterCreatingCommandos_ShouldReturnCorrectCount()
        {
            // Arrange
            _factory.CreateCommando(CommandoType.Regular, "John", "Alpha");
            _factory.CreateCommando(CommandoType.Air, "Alex", "Eagle");

            // Act
            var count = _factory.GetCommandoCount();

            // Assert
            Assert.Equal(2, count);
        }

        [Fact]
        public void GetCommandoByCodeName_ExistingCommando_ShouldReturnCommando()
        {
            // Arrange
            var codeName = "Eagle";
            var createdCommando = _factory.CreateCommando(CommandoType.Air, "Alex", codeName);

            // Act
            var foundCommando = _factory.GetCommandoByCodeName(codeName);

            // Assert
            Assert.NotNull(foundCommando);
            Assert.Equal(createdCommando, foundCommando);
            Assert.Equal(codeName, foundCommando.CodeName);
        }

        [Fact]
        public void GetCommandoByCodeName_NonExistingCommando_ShouldReturnNull()
        {
            // Arrange
            var codeName = "NonExistent";

            // Act
            var foundCommando = _factory.GetCommandoByCodeName(codeName);

            // Assert
            Assert.Null(foundCommando);
        }

        [Fact]
        public void GetCommandosByType_WithMatchingType_ShouldReturnFilteredList()
        {
            // Arrange
            _factory.CreateCommando(CommandoType.Air, "Alex", "Eagle");
            _factory.CreateCommando(CommandoType.Regular, "John", "Alpha");
            _factory.CreateCommando(CommandoType.Air, "Sarah", "Phoenix");

            // Act
            var airCommandos = _factory.GetCommandosByType(CommandoType.Air);

            // Assert
            Assert.Equal(2, airCommandos.Count);
            Assert.All(airCommandos, c => Assert.IsType<AirCommando>(c));
        }

        [Fact]
        public void RemoveCommando_ExistingCommando_ShouldReturnTrueAndDecreaseCount()
        {
            // Arrange
            var commando = _factory.CreateCommando(CommandoType.Regular, "John", "Alpha");
            var initialCount = _factory.GetCommandoCount();

            // Act
            var result = _factory.RemoveCommando(commando);

            // Assert
            Assert.True(result);
            Assert.Equal(initialCount - 1, _factory.GetCommandoCount());
        }

        [Fact]
        public void RemoveCommando_NonExistingCommando_ShouldReturnFalse()
        {
            // Arrange
            var existingCommando = _factory.CreateCommando(CommandoType.Regular, "John", "Alpha");
            var nonExistingCommando = new Commando("Jane", "Beta");

            // Act
            var result = _factory.RemoveCommando(nonExistingCommando);

            // Assert
            Assert.False(result);
            Assert.Equal(1, _factory.GetCommandoCount()); // Should remain unchanged
        }

        [Theory]
        [InlineData(CommandoType.Regular, typeof(Commando))]
        [InlineData(CommandoType.Air, typeof(AirCommando))]
        [InlineData(CommandoType.Sea, typeof(SeaCommando))]
        public void CreateCommando_WithDifferentTypes_ShouldReturnCorrectType(CommandoType type, Type expectedType)
        {
            // Arrange & Act
            var commando = _factory.CreateCommando(type, "Test", "TestCode");

            // Assert
            Assert.IsType(expectedType, commando);
        }

        [Fact]
        public void GetCommandos_ShouldReturnReadOnlyList()
        {
            // Arrange
            _factory.CreateCommando(CommandoType.Regular, "John", "Alpha");

            // Act
            var commandos = _factory.GetCommandos();

            // Assert
            Assert.IsAssignableFrom<IReadOnlyList<Commando>>(commandos);
        }
    }
}
