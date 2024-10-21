//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
using System.Runtime.CompilerServices;

namespace GDP_Exam_1
{
    /// <summary>
    /// Inherits from item and adds data & behavior specific for weapons
    /// </summary>
    // TODO: Make this inherit from item
    class Weapon : Item
    {
        // NO additional fields or properties are permitted.
        private double weight;
        private int damage;

        /// <summary>
        /// Return how much damage this weapon can do
        /// </summary>
        public int Damage { get { return damage; } }

        /// <summary>
        /// TODO: Add the Item class's required abstract Weight
        /// property.
        /// </summary>
        public override double Weight
            { get { return weight; } }

        /// <summary>
        /// TODO: Add a parameterized constructor using the constructor
        /// calls in Main & the writeup as a guide for what this constructor
        /// must do. Leverage the base class constructor as needed.
        /// </summary>
        public Weapon(string name, int damage, double weight)
            : base(name)
        {
            // Assign values not required by the base constructor
            this.weight = weight;
            this.damage = damage;
        }

        /// <summary>
        /// TODO: Override ToString to leverage the base class ToString 
        /// and add on the amount of damage this weapon does.
        /// </summary>
        public override string ToString()
        {
            string output = base.ToString();
            output += string.Format(", {0} damage", damage);

            return output;
        }
    }
}
