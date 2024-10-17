using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Pets
{
    /// <summary>
    /// Horses are Pets that say neigh
    /// </summary>
    internal class Horse : Pet
    {
        // Parameterized Horse constructor 
        public Horse(string name, DateTime birthday)
            : base(name, birthday, "horse")
        {
        }

        // We also want to override Speak so that this Goldfish can talk!
        public override void Speak()
        {
            Console.WriteLine(this.Name + " NEIGH.");
        }

        // Horses are famously used to sneak past the Trojan guards
        public void InvadeTroy()
        {

            Console.WriteLine("\nSURPRISE! IT'S THE GREEKS!");
            
            Console.WriteLine("THIS HORSE \"{0}\" WAS A PLOY BY THE GREEKS!", name.ToUpper());

            Console.WriteLine("I'VE HEARD OF A TROJAN HORSE BUT THIS IS RIDICULOUS!\n");
        }
    }
}
