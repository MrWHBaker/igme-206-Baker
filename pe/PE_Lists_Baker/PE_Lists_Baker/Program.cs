/* 
 * Wyatt H. Baker
 * PE - Lists
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1yr-JcmbBOSWCzaoHlt7F1n6dnWku0ZKLwbX_2kfBm_w/edit
 *      
 * Last edited 10-05-24 by Wyatt H. Baker
 * Using helper methods by Prof. Mesh
 * No known issues.
 */

namespace PE_Lists_Baker
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

        // Method to grant a specified item to a random player
        public static void GrantItem(string item, Player player1, Player player2, Random rng)
        {
            double randomResult = rng.NextDouble();
            Player selection;

            // Determine which player to grant the item to
            if (randomResult > 0.5)
            {
                selection = player1;
            }
            else
            {
                selection = player2;
            }

            // Grant the item
            selection.AddToInventory(item);
        }

        // Main program method
        static void Main(string[] args)
        {
            // ******** PART 1 ********************************************************************
            // -------- Declare Variables and Set Up Objects --------------------------------------
            string userInput;
            double randomResult;

            // List of stolen items
            List<string> items = new List<string>();

            // Create a Random object for use in the program
            Random rng = new Random();

            // Prompt the user for names and create player objects for each
            Player player1 = new Player(GetPromptedInput("Enter Player 1's name:"));
            Player player2 = new Player(GetPromptedInput("Enter Player 2's name:"));
            Console.WriteLine(""); // Console Whitespace



            // -------- Fill Player Inventories ---------------------------------------------------
            // Prompt the user for 5 items, and assign to a random character
            for (int i = 0; i < 5; i++)
            {
                userInput = GetPromptedInput("Enter an item:").Trim();
                GrantItem(userInput, player1, player2, rng);
            }
            

            // Print both inventories
            Console.WriteLine(); // Console Whitespace
            player1.PrintInventory();
            player2.PrintInventory();

            // ******** PART 2 ********************************************************************
            // -------- User Interface Loop -------------------------------------------------------
            do
            {
                // Prompt the user for a command
                userInput = GetPromptedInput
                    ("\nEnter a command (print, steal, or quit) or an item:").ToLower();
                

                // Run relevent behavior
                switch (userInput) {

                    // --- Print player inventories
                    case "print":
                        player1.PrintInventory();
                        player2.PrintInventory();
                        break;

                    // --- Steal from a player
                    case "steal":
                        // Determine which character to steal from
                        Player choice;

                        userInput = GetPromptedInput
                            ("Which player would you like to steal from (1 or 2)?");

                        if (userInput == "1")
                        {
                            choice = player1;
                        }
                        else
                        {
                            choice = player2;
                        }

                        // Get an item index and steal the appropriate item
                        userInput = GetPromptedInput
                            ($"Which item # would you like to steam from {choice.Name}?");

                        items.Add( choice.GetItemInSlot( int.Parse(userInput) ) );
                        break;

                    // --- End program
                    case "quit":
                        Console.WriteLine($"\nYou stole {items.Count} item(s):");

                        // Print out stolen items
                        foreach ( string item in items )
                        {
                            Console.WriteLine($"\t{item}");
                        }

                        return;

                    // --- Assume any other input is an item to be granted to a player
                    default:
                        GrantItem(userInput, player1, player2, rng);
                        break;

                }


            } while (true);
        }
    }
}
