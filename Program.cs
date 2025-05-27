using Commandos.Entities;
using Commandos.Interfaces;

Console.WriteLine("\n=== Testing Commando ===");
// יצירת מופע של קומנדו
Commando commando = new("Yoni", "Kodkod");

// בדיקת שדות הקונסטרקטור
Console.WriteLine($"Commando Name: {commando.Name}");
Console.WriteLine($"Commando CodeName: {commando.CodeName}");
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