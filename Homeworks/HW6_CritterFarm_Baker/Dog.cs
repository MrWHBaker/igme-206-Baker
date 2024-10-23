using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    internal class Dog : Critter
    {

        // ----------------------------------------------------------------------
        // Constructors
        // ----------------------------------------------------------------------

        // Creation constructor (Sets defaults and calls the base class constructor)
        public Dog(string name)
            : base(name, CritterType.Dog, 5, 5)
        {
        }

        // Load constructor (Builds a critter using data from a save file)
        public Dog(string name, int hunger, int boredom)
            : base(name, CritterType.Dog, hunger, boredom)
        {
        }

        // ----------------------------------------------------------------------
        // Methods
        // ----------------------------------------------------------------------

        // Unique mood behavior
        protected override void UpdateMood()
        {
            int irritation = Hunger + Boredom;

            // Dogs get angry if irritation is above 25 and frustrated if it's above 15.
            // otherwise they are happy
            if (irritation > 25)
            {
                mood = CritterMood.Angry;
            }
            else if (irritation > 15)
            {
                mood = CritterMood.Frustrated;
            }
            else
            {
                mood = CritterMood.Happy;
            }
        }
    }
}
