using Commandos.Entities.Commandos;
using Commandos.Enums;

namespace Commandos.Factories
{
    /// <summary>
    /// Factory class responsible for creating, managing, and removing commando instances.
    /// Maintains an internal collection of all created commandos.
    /// </summary>
    /// <remarks>
    /// This factory uses the Factory Pattern to create different types of commandos
    /// with predefined characteristics based on the commando type.
    /// </remarks>
    public class CommandoFactory
    {
        private readonly List<Commando> commandos = [];

        /// <summary>
        /// Creates a new commando instance based on the specified commando type, name, and code name.
        /// </summary>
        /// <param name="commandoType">The type of commando to create (Regular, Air, or Sea).</param>
        /// <param name="name">The real name of the commando.</param>
        /// <param name="codeName">The code name of the commando.</param>
        /// <returns>A new Commando instance with the specified type, name, and code name.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid commando type is provided.</exception>
        /// <remarks>
        /// The created commando is automatically added to the internal commandos collection.
        /// Each commando type creates a different specialized class:
        /// - Regular: Standard Commando
        /// - Air: AirCommando with parachute abilities
        /// - Sea: SeaCommando with swimming abilities
        /// </remarks>
        public Commando CreateCommando(CommandoType commandoType, string name, string codeName)
        {
            Commando commando = commandoType switch
            {
                CommandoType.Regular => new Commando(name, codeName),
                CommandoType.Air => new AirCommando(name, codeName),
                CommandoType.Sea => new SeaCommando(name, codeName),
                _ => throw new ArgumentException("Invalid commando type", nameof(commandoType)),
            };
            
            commandos.Add(commando);
            return commando;
        }

        /// <summary>
        /// Retrieves a read-only view of all commandos currently managed by the factory.
        /// </summary>
        /// <returns>A read-only list containing all commando instances.</returns>
        /// <remarks>
        /// Returns a read-only wrapper around the internal collection to prevent external modification
        /// while avoiding the overhead of creating a copy.
        /// </remarks>
        public IReadOnlyList<Commando> GetCommandos()
        {
            return commandos.AsReadOnly();
        }

        /// <summary>
        /// Gets the total count of commandos currently managed by the factory.
        /// </summary>
        /// <returns>The number of commandos in the collection.</returns>
        public int GetCommandoCount()
        {
            return commandos.Count;
        }

        /// <summary>
        /// Removes a specific commando instance from the factory's collection.
        /// </summary>
        /// <param name="commando">The commando instance to remove.</param>
        /// <returns>True if the commando was found and removed; false if the commando is not in the collection.</returns>
        /// <remarks>
        /// This method removes the commando by reference comparison. The operation is O(n) where n is the number of commandos.
        /// If the commando parameter is null, the method returns false.
        /// </remarks>
        public bool RemoveCommando(Commando commando)
        {
            if (commando == null)
                return false;

            return commandos.Remove(commando);
        }

        /// <summary>
        /// Removes all commandos from the factory's collection.
        /// </summary>
        /// <remarks>
        /// This operation clears the entire commandos collection.
        /// </remarks>
        public void ClearAllCommandos()
        {
            commandos.Clear();
        }

        /// <summary>
        /// Gets commandos filtered by their type.
        /// </summary>
        /// <param name="commandoType">The type of commandos to retrieve.</param>
        /// <returns>A read-only list of commandos matching the specified type.</returns>
        public IReadOnlyList<Commando> GetCommandosByType(CommandoType commandoType)
        {
            return commandoType switch
            {
                CommandoType.Regular => [.. commandos.Where(c => c.GetType() == typeof(Commando))],
                CommandoType.Air => [.. commandos.Where(c => c is AirCommando)],
                CommandoType.Sea => [.. commandos.Where(c => c is SeaCommando)],
                _ => []
            };
        }

        /// <summary>
        /// Gets a commando by their code name.
        /// </summary>
        /// <param name="codeName">The code name to search for.</param>
        /// <returns>The commando with the specified code name, or null if not found.</returns>
        public Commando? GetCommandoByCodeName(string codeName)
        {
            return commandos.FirstOrDefault(c => c.CodeName.Equals(codeName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
