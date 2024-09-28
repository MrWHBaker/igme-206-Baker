/* 
 * Wyatt H. Baker
 * PE - Guessing Game
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1_VNlxiE2SSDOxhRLTJtHTYpb7oMC5IXzam2HrVY9XHk/edit
 *      
 * Last edited 09-28-24 by Wyatt H. Baker
 * Using methods created by Professor Mesh
 * No known issues.
 */

namespace PE_GuessingGame_Baker
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

        // Method to process and act based on user input
        public static int ValidateInput(int turnNumber)
        {
            // Declare variables
            int input;
            bool validInput;

            // Ask for input until properly formatted input is provided
            do
            {
                validInput = int.TryParse(
                GetPromptedInput($"\nTurn #{turnNumber}: Guess a number between 0 and 100 (inclusive):"),
                out input);

                if (!validInput || input < 0 || input > 100)
                {
                    Console.WriteLine("Invalid guess - try again.");
                }
            }
            while (!validInput || input < 0 || input > 100);

            return input;
        }

        static void Main(string[] args)
        {
            // --- Declare variables --------------------------------------------------------------
            int guess;
            int turnNumber = 1;
            bool gameIsOver = false;

            // Generate a random number
            Random rng = new Random();
            int answer = rng.Next(101);

            // For testing purposes, print the answer on screen
            Console.WriteLine(answer + "\n");

            // Main program loop
            do
            {
                // Call method to process user input
                guess = ValidateInput(turnNumber);

                // Analyze user input and either continue or end game
                // On a correct guess, end the program and print turn number
                if (guess == answer)
                {
                    Console.WriteLine("Correct! You won in {0} turns.", turnNumber);
                    gameIsOver = true;
                }

                // On an incorrect guess, update turn number and try again
                else
                {
                    // Here I'm using nested if statements rather than if-else so that
                    // each case won't need to seperately update the turn number
                    if (guess > answer) { Console.WriteLine("Too high"); }
                    if (guess < answer) { Console.WriteLine("Too low"); }

                    turnNumber++;
                }

                // End the game when the user runs out of turns
                if (turnNumber > 8)
                {
                    Console.WriteLine("\n\nYou ran out of turns. The number was {0}.", answer);
                    gameIsOver = true;
                }
            }
            while (!gameIsOver);


        }
    }
}
