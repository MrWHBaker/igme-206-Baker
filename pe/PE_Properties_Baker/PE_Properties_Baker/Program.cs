/* 
 * Wyatt H. Baker
 * PE - Properties
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1z9HVMUdQWjPEswC2UwoDFwaoHdpaLT1Yvo7KtKBBaYs/edit
 *      
 * Last edited 10-03-24 by Wyatt H. Baker
 * Using helper method by Prof. Mesh
 * No known issues.
 */


namespace PE_Properties_Baker
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

        // Method to ensure good user int input
        // In this case, we'll also ensure that it's a positive number
        public static int GetValidInt(string prompt)
        {
            // Use console color scheme consistent with Professor Mesh's GetPromptedInput
            Console.ForegroundColor= ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Loop to check that user input is valid
            bool inputIsValid = false;
            int input;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                inputIsValid = int.TryParse(Console.ReadLine(), out input);
                Console.ForegroundColor = ConsoleColor.White;

                // Re-prompt user on failure
                if (!inputIsValid || input < 1) 
                {
                    Console.WriteLine("Please enter a properly formatted positive integer.");
                    Console.Write(prompt + " ");
                }
            } while (!inputIsValid || input < 1);

            return input;
        }

        // Main program method
        static void Main(string[] args)
        {
            // --- Declare Variables --------------------------------------------------------------
            string userInput;

            // --- Introduce program and Create Book object via user input ------------------------
            Console.WriteLine("Welcome to Book Simulator 2020\n");

            Book newBook = new Book
                (
                GetPromptedInput("What is the book's title?"),
                GetPromptedInput("Who is the book's author?"),
                GetValidInt("How many pages does it have?"),
                GetPromptedInput("Who is the book's current owner?")
                );

            // --- Main program loop --------------------------------------------------------------
            do
            {
                // Prompt user for the next action
                userInput = GetPromptedInput("\nWhat would you like to do?").ToLower();

                switch (userInput)
                {
                    // Get information
                    case "title":
                        Console.WriteLine($"The title is {newBook.Title}.");
                        break;

                    case "author":
                        Console.WriteLine($"The author is {newBook.Author}.");
                        break;

                    case "pages":
                        Console.WriteLine($"The book has {newBook.PageCount} pages.");
                        break;

                    // Allow user to get or set the owner
                    case "owner":
                        userInput = GetPromptedInput
                            ("Would you like to change the owner (yes/no)?");

                        if (userInput == "yes")
                        {
                            userInput = GetPromptedInput
                                ("Who is the new owner?");
                            newBook.Owner = userInput;

                            Console.WriteLine($"The new owner is {newBook.Owner}.");
                        }
                        else
                        {
                            Console.WriteLine($"Ok. {newBook.Owner} is still the owner.");
                        }
                        break;

                    // Update the times read
                    case "read":
                        newBook.TimesRead += 1;
                        Console.WriteLine($"The total times read is now {newBook.TimesRead}.");
                        break;

                    // Print all info
                    case "print":
                        newBook.Print();
                        break;

                    // Exit program
                    case "done":
                        Console.WriteLine("Goodbye.");
                        return;

                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }

            } while (true);
        }
    }
}
