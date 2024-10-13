using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Pets
{
    /// <summary>
    /// Goldfish are pets that say NOTHING
    /// </summary>
    internal class Goldfish : Pet
    {
        // Parameterized Goldfish constructor 
        public Goldfish(string name, DateTime birthday)
            : base(name, birthday, "goldfish")
        {
        }

        // We also want to override Speak so that this Goldfish can't talk!
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says NOTHING to the likes of YOU.");
        }

    }
}
