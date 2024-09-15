/* 
 * Wyatt H. Baker
 * PE - If Statements
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1r6n9DdOHQMa6qZYm-9p6EaWF_Dfp6S4q8QvW-igVvYQ/edit
 *      
 * Last edited 09-15-24 by Wyatt H. Baker
 * No known issues.
 */

using System.Numerics;

namespace PE_IfStatements_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* SCENARIO  INPUT      RESULT
             * 1	another creature	The creature of interest and this other creature sniff eachother for hours on end
             * 2	possible food	is this safe to eat? 
             *                          y: The creature devours it. 
             *                          n: The creature devours it even faster than normal.
             *                          other: The world may never know. The creature, however, devours it nonetheless
             * 3    fire hydrant     I daren't say what the creature does next. This is a serious game for goodness sake.
             * unusable input       The very concept of (input) shatters the mind of the creature
             */

            // --- Prepare User Input -----------------------------------
            String userInput;
            Console.Write("What does the creature sense? ");
            userInput = Console.ReadLine().ToLower().Trim();


            // --- Analyze input ----------------------------------------
            // Another Creature
            if (userInput == "another creature")
            {
                Console.WriteLine("The creature of interest and this other creature sniff eachother for hours on end");
            }


            // Possible Food
            else if (userInput == "possible food")
            {
                Console.Write("Is this food safe to eat? ");
                userInput = Console.ReadLine().ToLower().Trim();

                // Safe to eat
                if (userInput[0] == 'y')
                {
                    Console.WriteLine("The creature devours it.");
                }
                // Not safe to eat
                else if (userInput[0] == 'n')
                {
                    Console.WriteLine("The creature devours it even faster than normal.");
                }
                // Unusable input
                else
                {
                    Console.WriteLine("The world may never know. The creature, however, devours it nonetheless.");
                    Console.WriteLine("\nUnrecognized response - Please consider: \n'Yes'\n'No'");
                }
            }


            // Fire hydrant
            else if (userInput == "fire hydrant")
            {
                Console.WriteLine("I daren't say what the creature does next. This is a serious game for goodness sake.");
            }


            // Unusable input
            else
            {
                Console.WriteLine("The very concept of {0} shatters the mind of the creature.", userInput);

                Console.WriteLine("\nUnrecognized response - Please consider: \n'Another creature'\n'Possible food'\n'Fire hydrant'");
            }

        }
    }
}
