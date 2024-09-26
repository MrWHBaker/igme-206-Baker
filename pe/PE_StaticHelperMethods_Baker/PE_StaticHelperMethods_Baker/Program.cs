/* 
 * Wyatt H. Baker
 * PE - Static Helper Methods
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1Ky0RxivVxdatNuzqrsK2anKzLHzEaiZ7cm_VuhTvqYU/edit
 *      
 * Last edited 09-26-24 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_StaticHelperMethods_Baker
{
    internal class Program
    {

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // LEAVE THE REST OF THE CODE ALONE!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Helper written by Prof. Mesh
        /// Check if one number is a factor of another value
        /// </summary>
        /// <param name="factor">The factor to test</param>
        /// <param name="value">The value to check</param>
        /// <returns>True if value can be evenly divided by the factor</returns>
        public static bool IsFactorOf(int factor, int value)
        {
            // Return true if "factor" is smaller than "value"
            // and is evenly divisible into "value"
            return factor < value && value % factor == 0;
        }


        /// <summary>
        /// Input helper written by Prof. Mesh
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
        /// </summary>
        /// <param name="prompt">What to print before waiting for input</param>
        /// <returns>A trimmed version of what the user entered</returns>
        public static string GetPromptedInput(string prompt)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }

        // Helper method to analyze and judge the quality of the user's numbers
        public static void CheckNumbers(int a, int b)
        {
            // Test if either user number is a factor of the other
            // (Factor pairs are rad. The user should know how cool (or uncool) their choices are.)
            if (IsFactorOf(a, b) || IsFactorOf(b, a))
            {
                Console.WriteLine("{0} & {1} are awesome numbers.", a, b);
            }
            else
            {
                Console.WriteLine("{0} and {1} are okay I guess.", a, b);
            }
        }

        // Helper method to generate a secret code based on the user's input
        public static int GetSecretCode(string name, int a, int b)
        {
            // return the sum of the numeric value of the first character in the user's name and...
            // the name's length, multiplied by the absolute value of the difference between the...
            // user's numbers
            return ((int)name[0] + name.Length) * Math.Abs(a - b);
        }

        // Helper method to print all information available to the user
        public static void PrintAllInfo(string name, int a, int b)
        {
            // Print the user's information
            Console.WriteLine("Your name is {0}", name.ToUpper());
            Console.WriteLine("\tyour favorite numbers are {0} and {1},", a, b);

            // Analyze and return secret code and quality of numbers
            Console.WriteLine("\tand your secret code is {0}.", GetSecretCode(name, a, b));
            CheckNumbers(a, b);
        }


        // --- MAIN METHOD ------------------------------------------------------------------------
        static void Main(string[] args)
        {
            // Setup variables
            string name = "";
            int a = 0;
            int b = 0;
            int choice = 0;

            // Get values for name, a, and b using GetPromptedInput and parsing if needed.
            // Fyi, lines that begin with // TODO: will appear in a VS task list for you!
            // https://docs.microsoft.com/en-us/visualstudio/ide/using-the-task-list

            // Prompt the user for necessary input
            name = GetPromptedInput("What is your name?");                  // NAME
            a = int.Parse(GetPromptedInput("Enter a whole number:"));       // FIRST NUMBER
            b = int.Parse(GetPromptedInput("Enter another whole number:")); // SECOND NUMBER

            // Reformat the name
            name = name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1).ToLower();

            // Print the menu
            Console.WriteLine("\nHello {0}, what would you like to do?\n" +
                "\t1 - Compare numbers\n" +
                "\t2 - Get my secret code\n" +
                "\t3 - Output all info",
                name);
            choice = int.Parse(GetPromptedInput(">"));
            Console.WriteLine();

            // Figure out what to do and do it
            switch (choice)
            {
                // Check numbers
                case 1:
                    CheckNumbers(a,b);
                    break;

                // Get secret code
                case 2:
                    Console.WriteLine("Your secret code is {0}.", GetSecretCode(name, a, b));
                    break;

                // Output all info
                case 3:
                    PrintAllInfo(name, a, b);
                    break;

                // Say goodbye for invalid choices
                default:
                    Console.WriteLine("That wasn't a valid choice. Goodbye.");
                    break;
            }

        }
    }
}
