/* 
 * Wyatt H. Baker
 * PE - Magic 8 Ball
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/13OBHKxRLnRKNiYijs119CSW9Y7kW77oRCd1uovYR-Hs/edit
 *      
 * Last edited 10-02-24 by Wyatt H. Baker
 * Using helper methods written by Prof. Mesh
 * No known issues.
 */

using System.Security.Cryptography;

namespace PE_Magic8Ball_Baker
{
    internal class Program
    {
        // Input helper written by Prof. Mesh
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


        // Main method
        static void Main(string[] args)
        {
            // --- Declare Variables --------------------------------------------------------------
            string userName;
            string userResponse;
            bool runAgain = true;


            // --- Set Up Ball Object -------------------------------------------------------------
            // Greet the user, and prompt for data
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to Magic 8 Ball Simulator!");

            userName = GetPromptedInput("Who owns this ball?");

            // Instantiate the ball
            Magic8Ball userBall = new Magic8Ball(userName);


            // --- Main Program Loop --------------------------------------------------------------
            do
            {
                // Offer the user to choose an operation
                Console.WriteLine("\nWhat would you like to do?");

                userResponse = GetPromptedInput
                    (
                    "You can 'shake' the ball, get a 'report', or 'quit': "
                    ).ToLower();

                // Evaluate input and act accordingly
                switch (userResponse)
                {
                    case "shake":
                        Console.Write("\t> What is your question? ");

                        // Set the console color and pretend we're actually processing the question
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("\t> The magic 8 ball says: ");

                        // Call the shake ball method (with some color for fun)
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(userBall.ShakeBall());
                        Console.ForegroundColor = ConsoleColor.White;

                        break;

                    case "report":
                        // Call the report method
                        Console.WriteLine("\t> " + userBall.Report());
                        break;

                    case "quit":
                        // Flag for the loop to end
                        Console.WriteLine("\t> Goodbye!");
                        runAgain = false;
                        break;

                    default:
                        // Default case for bad input
                        Console.WriteLine("\t> I do not recognize that response.");
                        break;
                }

            }
            while (runAgain);

        }
    }
}
