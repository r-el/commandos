
using Commandos.Entities.Commandos;
using Commandos.Enums;
using Commandos.Factories;

Console.WriteLine("🎯 =================================");
Console.WriteLine("🎯 Testing CommandoFactory - Separate Branch");
Console.WriteLine("🎯 =================================\n");

// Create CommandoFactory
CommandoFactory commandoFactory = new();

Console.WriteLine("=== Creating Commandos ===");

// Create different types of commandos
var regularCommando = commandoFactory.CreateCommando(CommandoType.Regular, "John", "Kodkod");
var airCommando = commandoFactory.CreateCommando(CommandoType.Air, "Alex", "Eagle");
var seaCommando = commandoFactory.CreateCommando(CommandoType.Sea, "Marina", "Kraken");

Console.WriteLine($"✅ Created {commandoFactory.GetCommandoCount()} commandos");

Console.WriteLine("\n=== List of All Soldiers ===");
var allCommandos = commandoFactory.GetCommandos();
foreach (var commando in allCommandos)
{
    Console.WriteLine($"🪖 {commando.SayName("GENERAL")} ({commando.CodeName}) - Type: {commando.GetType().Name}");
}

Console.WriteLine("\n=== Testing Unique Functions ===");
if (airCommando is AirCommando air)
{
    air.Parachute();
}

if (seaCommando is SeaCommando sea)
{
    sea.Swim();
}

Console.WriteLine("\n=== Search Commando by Code Name ===");
var foundCommando = commandoFactory.GetCommandoByCodeName("Eagle");
if (foundCommando != null)
{
    Console.WriteLine($"🔍 Found: {foundCommando.SayName("GENERAL")} ({foundCommando.CodeName})");
}

Console.WriteLine("\n=== Commandos by Type ===");
var airCommandos = commandoFactory.GetCommandosByType(CommandoType.Air);
Console.WriteLine($"Air Commandos: {airCommandos.Count}");
foreach (var cmd in airCommandos)
{
    Console.WriteLine($"  ✈️ {cmd.CodeName}");
}

Console.WriteLine("\n=== Removing Commando ===");
var removed = commandoFactory.RemoveCommando(regularCommando);
Console.WriteLine($"Removed {regularCommando.CodeName}: {(removed ? "Success" : "Failed")}");
Console.WriteLine($"Remaining commandos: {commandoFactory.GetCommandoCount()}");

Console.WriteLine("\n✅ =================================");
Console.WriteLine("✅ CommandoFactory Testing Complete!");
Console.WriteLine(value: "✅ =================================");
