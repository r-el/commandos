# 🎮 Commandos Game Project

A simple C# project demonstrating the use of Factory Pattern for creating commandos, enemies, and weapons.

## 📁 Project Structure

```
├── Game.cs                 # Main class - connects the three factories
├── Program.cs              # Application entry point
├── Demo/
│   └── GameDemo.cs         # Game usage demonstration
├── Factories/              # Factories for creating objects
│   ├── CommandoFactory.cs  # Commando factory
│   ├── EnemyFactory.cs     # Enemy factory
│   └── WeaponFactory.cs    # Weapon factory
├── Entities/               # Game entities
├── Enums/                  # Data types
├── Interfaces/             # Interfaces
└── Tests/                  # Tests
```

## 🚀 How to Run the Project

### Prerequisites
- .NET 8.0 SDK installed
- VS Code or Visual Studio

### Running the Project

```bash
# Navigate to project directory
cd "/home/ariel/Documents/csharp/20250527 - commandos"

# Run the project
dotnet run
```

### Build Only (without running)

```bash
# Build the project
dotnet build
```

## 🧪 How to Run Tests

### Run All Tests

```bash
# Run all tests
dotnet test

# Run tests with additional details
dotnet test --verbosity normal

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"
```

### Run Specific Tests

```bash
# Run a single test file
dotnet test --filter "ClassName=GameIntegrationTests"

# Run specific test by name
dotnet test --filter "TestMethodName=CreateCommando_ShouldReturnValidCommando"

# Run tests containing a specific word
dotnet test --filter "Name~Factory"
```

### Available Tests

1. **GameIntegrationTests** - Integration tests for Game class
2. **CommandoFactoryTests** - Tests for commando factory
3. **EnemyFactoryTests** - Tests for enemy factory
4. **WeaponFactoryTests** - Tests for weapon factory

## 📋 What the Project Does

The project demonstrates the use of Factory Pattern:

1. **Game class** - A simple class that connects the three factories
2. **Three independent factories**:
   - Creating commandos (Regular, Air, Sea)
   - Creating enemies (Zombie, Robot, Ghost, Dragon)
   - Creating weapons (Rifle, Pistol, Grenade, Sniper)

## 🎯 Usage Example

```csharp
Game game = new();

// Create a commando
var commando = game.CreateCommando(CommandoType.Regular, "Barrett", "Eagle Eye");

// Create an enemy
var enemy = game.CreateEnemy(EnemyType.Zombie, "Hans");

// Create a weapon
var weapon = game.CreateWeapon(WeaponType.Rifle, "M1 Garand");
```

## 🛠 Technologies

- **.NET 8.0**
- **C# 12**
- **xUnit** - Testing framework
- **Factory Pattern** - Design pattern for object creation

## 🔧 Running in VS Code

### Using the Graphical Interface
1. Open the folder in VS Code
2. Press **F5** to run the project
3. Press **Ctrl+Shift+P** and select "Test: Run All Tests" to run tests
4. Use the "Test Explorer" panel to run specific tests

### Useful Tips

```bash
# Watch for file changes (watch mode)
dotnet watch run

# Clean build files
dotnet clean

# Restore NuGet packages
dotnet restore

# Watch tests continuously
dotnet watch test
```

## ⚠️ Troubleshooting Common Issues

### Build Issues
```bash
# If there are build errors, try:
dotnet clean
dotnet restore
dotnet build
```

### Test Issues
```bash
# If tests don't run:
dotnet test --list-tests  # List all tests
dotnet test --logger trx  # Create detailed report
```

### Entry Point Issues
- The project is configured to start from `Program.cs`
- If there's a multiple entry points error, check `commandos.csproj`

## 📝 Development Notes

- The project uses **Implicit Usings** (enabled in csproj)
- **Nullable reference types** are enabled
- All tests use **xUnit framework**
- The factories are independent and not dependent on each other
