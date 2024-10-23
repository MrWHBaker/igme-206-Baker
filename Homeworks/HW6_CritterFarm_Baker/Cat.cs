using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    internal class Cat : Critter
    {
        // ----------------------------------------------------------------------
        // Constructors
        // ----------------------------------------------------------------------

        // Creation constructor (Sets defaults and calls the base class constructor)
        public Cat(string name)
            : base(name, CritterType.Cat, 2, 0)
        {
        }

        // Load constructor (Builds a critter using data from a save file)
        public Cat(string name, int hunger, int boredom)
            : base(name, CritterType.Cat, hunger, boredom)
        {
        }

        // ----------------------------------------------------------------------
        // Methods
        // ----------------------------------------------------------------------

        // Unique mood behavior
        protected override void UpdateMood()
        {
            int irritation = Hunger + ( 2 * Boredom );

            // Cats get angry if irritation is above 25, otherwise they are happy
            if (irritation > 25)
            {
                mood = CritterMood.Angry;
            }
            else
            {
                mood = CritterMood.Happy;
            }
        }

        // Method that can be called randomly when time passes
        // Decreases the cat's boredom
        public void CauseChaos()
        {
            Console.WriteLine( name + " also gets joy out of randomly causing trouble!");
            Boredom -= Boredom / 2;
        }

    }
}
