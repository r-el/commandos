using Commandos.Entities;
using Commandos.Enums;

namespace Commandos.Factories
{
    /// <summary>
    /// Factory class responsible for creating, managing, and removing weapon instances.
    /// Maintains an internal collection of all created weapons.
    /// </summary>
    /// <remarks>
    /// This factory uses the Factory Pattern to create different types of weapons
    /// with predefined characteristics based on the weapon type.
    /// </remarks>
    public class WeaponFactory
    {
        private readonly List<Weapon> weapons = [];

        /// <summary>
        /// Creates a new weapon instance based on the specified weapon type and custom name.
        /// </summary>
        /// <param name="weaponType">The type of weapon to create (Rifle, Pistol, Grenade, or Sniper).</param>
        /// <param name="customName">Optional custom name for the weapon. If null, uses default name based on type.</param>
        /// <returns>A new Weapon instance with the specified type, name, and appropriate characteristics.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid weapon type is provided.</exception>
        /// <remarks>
        /// The created weapon is automatically added to the internal weapons collection.
        /// Each weapon type has predefined characteristics:
        /// - Rifle: 30 bullets, manufacturer "Assault Corp"
        /// - Pistol: 12 bullets, manufacturer "Handgun Ltd"
        /// - Grenade: 1 use, manufacturer "Explosive Co"
        /// - Sniper: 5 bullets, manufacturer "Precision Arms"
        /// </remarks>
        public Weapon CreateWeapon(WeaponType weaponType, string? customName = null)
        {
            Weapon weapon = weaponType switch
            {
                WeaponType.Rifle => new Weapon(
                    customName ?? "AK-47", 
                    "Assault Corp", 
                    30,
                    WeaponType.Rifle
                ),
                WeaponType.Pistol => new Weapon(
                    customName ?? "Glock-19", 
                    "Handgun Ltd", 
                    12,
                    WeaponType.Pistol
                ),
                WeaponType.Grenade => new Weapon(
                    customName ?? "Frag Grenade", 
                    "Explosive Co", 
                    1,
                    WeaponType.Grenade
                ),
                WeaponType.Sniper => new Weapon(
                    customName ?? "Barrett M82", 
                    "Precision Arms", 
                    5,
                    WeaponType.Sniper
                ),
                _ => throw new ArgumentException("Invalid weapon type", nameof(weaponType)),
            };
            
            weapons.Add(weapon);
            return weapon;
        }

        /// <summary>
        /// Retrieves a read-only view of all weapons currently managed by the factory.
        /// </summary>
        /// <returns>A read-only list containing all weapon instances.</returns>
        /// <remarks>
        /// Returns a read-only wrapper around the internal collection to prevent external modification
        /// while avoiding the overhead of creating a copy.
        /// </remarks>
        public IReadOnlyList<Weapon> GetWeapons()
        {
            return weapons.AsReadOnly();
        }

        /// <summary>
        /// Gets the total count of weapons currently managed by the factory.
        /// </summary>
        /// <returns>The number of weapons in the collection.</returns>
        public int GetWeaponCount()
        {
            return weapons.Count;
        }

        /// <summary>
        /// Removes a specific weapon instance from the factory's collection.
        /// </summary>
        /// <param name="weapon">The weapon instance to remove.</param>
        /// <returns>True if the weapon was found and removed; false if the weapon is not in the collection.</returns>
        /// <remarks>
        /// This method removes the weapon by reference comparison. The operation is O(n) where n is the number of weapons.
        /// If the weapon parameter is null, the method returns false.
        /// </remarks>
        public bool RemoveWeapon(Weapon weapon)
        {
            if (weapon == null)
                return false;

            return weapons.Remove(weapon);
        }

        /// <summary>
        /// Removes all weapons from the factory's collection.
        /// </summary>
        /// <remarks>
        /// This operation clears the entire weapons collection.
        /// </remarks>
        public void ClearAllWeapons()
        {
            weapons.Clear();
        }

        /// <summary>
        /// Gets weapons filtered by their type.
        /// </summary>
        /// <param name="weaponType">The type of weapons to retrieve.</param>
        /// <returns>A read-only list of weapons matching the specified type.</returns>
        public IReadOnlyList<Weapon> GetWeaponsByType(WeaponType weaponType)
        {
            return [.. weapons.Where(w => w.Type == weaponType)];
        }
    }
}
