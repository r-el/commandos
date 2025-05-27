using Commandos.Interfaces;

namespace Commandos.Entities.Tools
{
    public record Bag : ITool
    {
        public string Name => "Bag";
    }
}
