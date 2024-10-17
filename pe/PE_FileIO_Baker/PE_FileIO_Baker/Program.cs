/* 
 * Wyatt H. Baker
 * PE - Filo IO With Classes
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1bdEwXtXEnyY2xfeDdS7XJ7FMqHUE0IzZn2OLopcwEwU/edit?tab=t.0
 *      
 * Last edited 10-10-2024 by Wyatt H. Baker
 * Using helper methods created by Professor Mesh
 * No known issues.
 */


namespace PE_FileIO_Baker
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

        // Method to retrieve valid integer input from the user
        public static int GetValidIntegerInput(string prompt)
        {
            int result;
            bool isValid = int.TryParse(GetPromptedInput(prompt), out result);

            while (!isValid)
            {
                isValid = int.TryParse
                    (
                    GetPromptedInput("Please enter a valid whole number"),
                    out result
                    );
            }
            return result;
        }


        static void Main(string[] args)
        {
            /*
            // --- Test Player Class
            Player newPlayer = new Player("Mario", 100, 2);

            Console.WriteLine(newPlayer.Name);
            Console.WriteLine(newPlayer.Strength);
            Console.WriteLine(newPlayer.Health);

            Console.WriteLine(newPlayer.ToString());
            */

            // -------- Declare Variables ---------------------------------------------------------
            string userInput;

            // Instantiate a Player Manager
            PlayerManager manager = new PlayerManager();

            // -------- Main program loop ---------------------------------------------------------
            do
            {
                // Prompt the user to enter a command
                userInput = GetPromptedInput("\nCreate. Print. Save. Load. Quit. >>").ToLower();

                // Run instructed operation
                switch (userInput) 
                {
                    // Create a player from prompted user input
                    case "create":
                        //userInput = GetPromptedInput("\tWhat is the player's name?");

                        manager.CreatePlayer
                            (
                                GetPromptedInput("\tWhat is the player's name?"),
                                GetValidIntegerInput("\tPlayer's strength?"),
                                GetValidIntegerInput("\tPlayer's health?")
                            );

                        //Console.WriteLine("Added {0} to the list.", userInput);
                        break;

                    // Print all player data to the console
                    case "print":
                        manager.Print();
                        break;

                    // Save all player data to a file
                    case "save":
                        manager.Save();
                        break;

                    // Load player data from a file
                    case "load":
                        manager.Load();
                        break;

                    // End program
                    case "quit":
                        Console.WriteLine("\tGoodbye!");
                        return;

                    // Default response for unrecognized input
                    default:
                        Console.WriteLine("\tSorry, I didn't understand that command.");
                        break;
                }
            } while (true);
        }
    }
}
