using Commandos.Entities;
using Commandos.Interfaces;
using Commandos.Entities.Commandos;

Console.WriteLine("\n=== Testing Weapon Class ===");
// יצירת מופעים של נשקים
Weapon ak47 = new("AK-47", "Kalashnikov", 30);
Weapon m16 = new("M16", "Colt", 20);
Weapon glock = new("Glock 17", "Glock", 17);

Console.WriteLine($"Weapon 1: {ak47.Name} by {ak47.Manufacturer}, Bullets: {ak47.Bullets}");
Console.WriteLine($"Weapon 2: {m16.Name} by {m16.Manufacturer}, Bullets: {m16.Bullets}");
Console.WriteLine($"Weapon 3: {glock.Name} by {glock.Manufacturer}, Bullets: {glock.Bullets}");

Console.WriteLine("\n=== Testing Shoot Method ===");
ak47.Shoot();
ak47.Shoot();
m16.Shoot();
glock.Shoot();

Console.WriteLine("\n=== After Shooting ===");
Console.WriteLine($"{ak47.Name}: {ak47.Bullets} bullets left");
Console.WriteLine($"{m16.Name}: {m16.Bullets} bullets left");
Console.WriteLine($"{glock.Name}: {glock.Bullets} bullets left");

Console.WriteLine("\n=== Testing Empty Weapon ===");
// ירי עד שנגמרים הכדורים
Weapon smallGun = new("Derringer", "Unknown", 2);
Console.WriteLine($"Starting with {smallGun.Bullets} bullets");
smallGun.Shoot();
smallGun.Shoot();
smallGun.Shoot(); // Should show "out of bullets"

Console.WriteLine("\n=== Testing Encapsulation ===");
// יצירת מופע של קומנדו
Commando commando = new("Yoni", "Kodkod");

Console.WriteLine("\n=== Testing Private Name Field Access ===");
// The Name field is private, so we cannot access it directly from outside the class
// Console.WriteLine($"Accessing commando.Name property: {commando.Name}"); // This would cause a compilation error
Console.WriteLine("The Name field is private and cannot be accessed directly from outside the class.");

Console.WriteLine("\n=== Testing SayName Method with Rank-based Access ===");
Console.WriteLine($"GENERAL access: {commando.SayName("GENERAL")}");
Console.WriteLine($"COLONEL access: {commando.SayName("COLONEL")}");
Console.WriteLine($"CAPTAIN access: {commando.SayName("CAPTAIN")}");
Console.WriteLine($"lowercase general: {commando.SayName("general")}");

Console.WriteLine("\n=== Testing CodeName Property (get/set) ===");
Console.WriteLine($"Initial CodeName: {commando.CodeName}");
commando.CodeName = "ShadowFox";
Console.WriteLine($"Modified CodeName: {commando.CodeName}");
Console.WriteLine($"Number of tools: {commando.Tools.Length}");

// הדפסת כל הכלים
Console.WriteLine("Tools:");
foreach (ITool tool in commando.Tools)
    Console.WriteLine($"  - {tool.Name}");


// בדיקת מצבים ראשוניים
Console.WriteLine($"\nInitial states:");
Console.WriteLine($"IsWalking: {commando.IsWalking}");
Console.WriteLine($"IsHidden: {commando.IsHidden}");
Console.WriteLine($"IsAttacking: {commando.IsAttacking}");

Console.WriteLine("\n=== Testing Methods ===");
commando.StartWalking();
Console.WriteLine($"After StartWalking - IsWalking: {commando.IsWalking}");
commando.Hide();
Console.WriteLine($"After Hide - IsHidden: {commando.IsHidden}");
commando.StartAttack();
Console.WriteLine($"After StartAttack - IsAttacking: {commando.IsAttacking}");
Console.WriteLine($"\nCommando status: {commando}");

// עצירת פעילויות
commando.StopWalking();
commando.Reveal();
commando.StopAttack();

Console.WriteLine($"After stopping all activities: {commando}");

Console.WriteLine("\n=== Testing Class Recognition ===");
Console.WriteLine($"Commando class works: {typeof(Commando).Name}");

Console.WriteLine("\n========================================");
Console.WriteLine("=== INHERITANCE TESTING ===");
Console.WriteLine("========================================");

Console.WriteLine("\n=== Creating Derived Classes ===");
AirCommando airCommando = new("Alex", "Falcon");
SeaCommando seaCommando = new("Marina", "Kraken");

Console.WriteLine($"Air Commando created: {airCommando.CodeName}");
Console.WriteLine($"Sea Commando created: {seaCommando.CodeName}");

Console.WriteLine("\n=== Testing Inherited Methods ===");
Console.WriteLine("Air Commando inherited methods:");
airCommando.StartWalking();
airCommando.Hide();
Console.WriteLine($"Air Commando GENERAL access: {airCommando.SayName("GENERAL")}");
Console.WriteLine($"Air Commando COLONEL access: {airCommando.SayName("COLONEL")}");

Console.WriteLine("\nSea Commando inherited methods:");
seaCommando.StartWalking();
seaCommando.StartAttack();
Console.WriteLine($"Sea Commando GENERAL access: {seaCommando.SayName("GENERAL")}");
Console.WriteLine($"Sea Commando status: {seaCommando}");

Console.WriteLine("\n=== Testing Unique Methods ===");
Console.WriteLine("Air Commando unique ability:");
airCommando.Parachute();

Console.WriteLine("\nSea Commando unique ability:");
seaCommando.Swim();

Console.WriteLine("\n=== Testing Polymorphism ===");
Commando[] commandoSquad = [airCommando, seaCommando, new Commando("John", "Ghost")];

Console.WriteLine("Commando squad roll call:");
for (int i = 0; i < commandoSquad.Length; i++)
{
    Console.WriteLine($"Commando {i + 1}: {commandoSquad[i].SayName("GENERAL")} ({commandoSquad[i].CodeName})");
    Console.WriteLine($"  Type: {commandoSquad[i].GetType().Name}");
    Console.WriteLine($"  Tools available: {commandoSquad[i].Tools.Length}");
}

Console.WriteLine("\n=== Testing Type Checking ===");
foreach (Commando squadMember in commandoSquad)
{
    if (squadMember is AirCommando air)
    {
        Console.WriteLine($"{air.CodeName} is an Air Commando - executing parachute!");
        air.Parachute();
    }
    else if (squadMember is SeaCommando sea)
    {
        Console.WriteLine($"{sea.CodeName} is a Sea Commando - executing swim!");
        sea.Swim();
    }
    else
    {
        Console.WriteLine($"{squadMember.CodeName} is a regular Commando - executing standard operations!");
        squadMember.StartWalking();
        squadMember.Hide();
    }
    Console.WriteLine();
}

Console.WriteLine("=== Inheritance Testing Complete ===");