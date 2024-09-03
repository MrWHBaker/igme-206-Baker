/*
 * Wyatt H. Baker
 * PE - Statements and Expressions
 * https://docs.google.com/document/d/1vl8WUygXAinknNA2v_4nWTg9IuH8rUOCzFjw5Y7y4tU/edit
 * 
 * No known issues
 */

namespace PE_StatementsExpressions_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // Print a line to the console with a label and the character's name (Including a newline for spacing).
            Console.WriteLine("Name: Bad Larry\n");


            // Fill out a character's stats page from a pool of 50 points without using variables.
            // Each stat should be calculated and printed with a label.

            // Character's first stat should be equal to 20% of the total points.
            Console.WriteLine("Strength: " + (50 * 0.2));

            // The second stat should always be half of the first stat.
            // Calculate this by first calculating 20% of 50 again, and then calculating 50% of that number.
            Console.WriteLine("Dexterity: " + ((50 * 0.2) / 2));

            // The third stat should always be exactly 7 points
            Console.WriteLine("Intelligence: " + 7);

            // The Fourth stat is the sum of the second and third stats, minus two points.
            Console.WriteLine("Health: " + (((50 * 0.2) / 2) + 7));

            // Remaining points go to the fifth stat. This value is calculated in one expression.
            Console.WriteLine("Charisma: " +
                (50 -
                    ((50 * 0.2) +
                    ((50 * 0.2) / 2) +
                    7 +
                    (((50 * 0.2) / 2) + 7))
                )
            );


            // Give a final note about the number of points (Plus an extra line for spacing)
            Console.WriteLine("\nJust try and put those suckers in a calculator. All adds up to 50, baby");
        }
    }
}
