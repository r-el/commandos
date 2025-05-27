using Commandos.Entities.Tools;
using Commandos.Interfaces;

namespace Commandos.Entities
{
    public class Commando(string name, string codeName)
    {
        private string Name = name;
        public string CodeName { get; set; } = codeName;
        public ITool[] Tools { get; private set; } = [new Bag(), new Chisel(), new WaterBottle(), new Rope(), new Hummer()];
        public bool IsWalking { get; set; } = false;
        public bool IsHidden { get; set; } = false;
        public bool IsAttacking { get; set; } = false;

        public string SayName(string commanderRank)
        {
            return commanderRank switch
            {
                "GENERAL" => Name,
                "COLONEL" => CodeName,
                _ => "CLASSIFIED"
            };
        }

        public void StartWalking()
        {
            Console.WriteLine($"{Name} ({CodeName}) is now walking.");
            IsWalking = true;
        }
        public void StopWalking()
        {
            Console.WriteLine($"{Name} ({CodeName}) has stopped walking.");
            IsWalking = false;
        }

        public void Hide()
        {
            Console.WriteLine($"{Name} ({CodeName}) is now hiding.");
            IsHidden = true;
        }
        public void Reveal()
        {
            Console.WriteLine($"{Name} ({CodeName}) is now revealed.");
            IsHidden = false;
        }

        public void StartAttack()
        {
            Console.WriteLine($"{Name} ({CodeName}) is now attacking.");
            IsAttacking = true;
        }
        public void StopAttack()
        {
            Console.WriteLine($"{Name} ({CodeName}) has stopped attacking.");
            IsAttacking = false;
        }

        public override string ToString()
        {
            List<string> status = [];
            if (IsWalking) status.Add("Walking");
            if (IsHidden) status.Add("Hidden");
            if (IsAttacking) status.Add("Attacking");

            string statusString = status.Count > 0 ? $" ({string.Join(", ", status)})" : "";
            return $"{Name} ({CodeName}){statusString}";
        }
    }
}