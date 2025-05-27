
namespace Commandos.Entities.Commandos
{
    public class AirCommando(string name, string codeName) : Commando(name, codeName)
    {
        public void Parachute()
        {
            Console.WriteLine($"{_name} ({CodeName}) is parachuting from the sky! 🪂");
            Console.WriteLine("The air commando descends with precision and grace...");
        }
    }
}
