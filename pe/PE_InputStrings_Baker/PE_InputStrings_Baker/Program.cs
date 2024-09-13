/* 
 * Wyatt H. Baker
 * PE - Input & Strings
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1jY5NojS8rVRq7ZhxB_5E4hoRj30y40zFMzAa1X0sBN0/edit
 *      
 * Last edited 09-13-24 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_InputStrings_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Variable Declarations --------------------------------------------------
            // Inputs
            String name;
            String color;
            String pet;
            String band;

            // Outputs
            String nickName;



            // --- Start program -----------------------------------------------------------

            // Prompt user for name
            Console.Write("What is your name? ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Welcome {0}!", name);

            // Promt user for favorite color
            Console.Write("What is your favorite color? ");
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            color = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // Prompt user for pet's name
            Console.Write("What is your pet's name? ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            pet = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // Prompt use for band
            Console.Write("What is your favorite band? ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            band = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // --- Evaluate Inputs ---------------------------------------------------------

            // Length of the user's name
            Console.WriteLine("\nYour name is {0} letters long", name.Length);

            // Compare user name length to pet name length
            Console.WriteLine("and {0} letters longer than {1}'s name.", name.Length-pet.Length, pet);

            // Comment about the provided information in uppercase
            Console.WriteLine
                (
                    "\nI wonder if {0} and {1} like {2} as much as you do.",
                    pet.ToUpper(), band.ToUpper(), color.ToUpper()
                );

            // Create a new, 7-character name by combining parts of input
            Console.WriteLine
                (
                    "\nMaybe I should just call you {0}?",
                    name.ToUpper()[0] 
                    + color.Substring(0,2).ToLower() 
                    + pet.Substring(0,2).ToLower() 
                    + band.Substring(0,2).ToLower()
                );

        }
    }
}
