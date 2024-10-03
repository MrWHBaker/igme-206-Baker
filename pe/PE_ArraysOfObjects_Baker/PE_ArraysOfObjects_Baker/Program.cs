/* 
 * Wyatt H. Baker
 * PE - Arrays of Objects
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1RuAfFYOzlZvX37DgXFVvGX3zMuygVVrpJn4Wg7Fvt-Q/edit
 *      
 * Last edited 10-02-24 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_ArraysOfObjects_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test cards with various values and suits
            /*
            Card kingOfHearts = new Card(13, "Hearts");
            kingOfHearts.Print();

            Card aceOfSpades = new Card(1, "Spades");
            aceOfSpades.Print();

            Card twoOfClubs = new Card(2, "Clubs");
            twoOfClubs.Print();
            */

            // Initialize a deck of cards and print its information
            Deck myDeck = new Deck();
            myDeck.Print();

            // Prompt the user for the number of cards they want dealt
            Console.Write("\nEnter a number of cards to deal (1-52): ");

            // Feed user input directly into the deck's deal method, assume valid input
            myDeck.Deal(int.Parse(Console.ReadLine()));
        }
    }
}
