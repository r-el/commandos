namespace Commandos.Entities.Commandos
{
    public class SeaCommando(string name, string codeName) : Commando(name, codeName)
    {
        public void Swim()
        {
            Console.WriteLine($"{_name} ({CodeName}) is swimming through the waters! 🌊");
            Console.WriteLine("The sea commando navigates the depths with expert precision...");
        }
    }
}
