using System;
using Commandos.Entities;
using Commandos.Entities.Commandos;
using Commandos.Entities.Enemies;
using Commandos.Enums;

namespace Commandos.Demo
{
    /// <summary>
    /// Simple demonstration of the Game class using the three factories.
    /// </summary>
    public class GameDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("🎮 =========================================");
            Console.WriteLine("🎮 Commandos Game Demo");
            Console.WriteLine("🎮 =========================================\n");

            Game game = new();
            
            // Demonstrate factory usage
            Console.WriteLine("Creating entities using the three factories:\n");
            
            // Create commandos (using available types: Regular, Air, Sea)
            Commando regular = game.CreateCommando(CommandoType.Regular, "Barrett", "Eagle Eye");
            Commando air = game.CreateCommando(CommandoType.Air, "Dugan", "Sky Walker");
            Commando sea = game.CreateCommando(CommandoType.Sea, "Natasha", "Deep Blue");
            
            Console.WriteLine($"✅ Created Regular Commando: {regular.CodeName}");
            Console.WriteLine($"✅ Created Air Commando: {air.CodeName}");
            Console.WriteLine($"✅ Created Sea Commando: {sea.CodeName}");
            
            // Create enemies (using available types: Zombie, Robot, Ghost, Dragon)
            Enemy zombie = game.CreateEnemy(EnemyType.Zombie, "Hans");
            Enemy robot = game.CreateEnemy(EnemyType.Robot, "Klaus");
            
            Console.WriteLine($"✅ Created Zombie: {zombie.Name}");
            Console.WriteLine($"✅ Created Robot: {robot.Name}");
            
            // Create weapons (using available types: Rifle, Pistol, Grenade, Sniper)
            Weapon rifle = game.CreateWeapon(WeaponType.Rifle, "M1 Garand");
            Weapon pistol = game.CreateWeapon(WeaponType.Pistol);
            Weapon grenade = game.CreateWeapon(WeaponType.Grenade);
            
            Console.WriteLine($"✅ Created Rifle: {rifle.Name}");
            Console.WriteLine($"✅ Created Pistol: {pistol.Name}");
            Console.WriteLine($"✅ Created Grenade: {grenade.Name}");
            
            Console.WriteLine("\n🎮 Demo completed! All three factories working correctly.");
        }
    }
}
