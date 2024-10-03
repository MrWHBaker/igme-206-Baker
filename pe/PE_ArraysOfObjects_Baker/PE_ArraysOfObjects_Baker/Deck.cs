using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ArraysOfObjects_Baker
{
    // Deck class holds a set of cards and operations to run on them
    internal class Deck
    {
        // --- Fields -----------------------------------------------------------------------------
        // Random number generator to be used by the deck
        Random rng;
        // Array of Card objects held in the deck
        Card[] cards;

        // --- Methods ----------------------------------------------------------------------------
        // Constructor
        public Deck()
        {
            rng = new Random();
            cards = new Card[52];

            string[] suit = {"Hearts", "Spades", "Diamonds", "Clubs"};

            // Loop through each suit and value to fill the deck
            for (int i = 0; i < 4; i++)
            {
                // Fill the suit with the appropriate card values
                for (int j = 0; j < 13; j++)
                {
                    cards[(i * 13) + j] = new Card(j + 1, suit[i]);
                }
            }
        }

        // Print all cards to the screen
        public void Print()
        {
            Console.WriteLine("Your deck:");

            // Loop through the cards array and run each one's print method
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Print();
            }
        }

        // Deal a random selection of cards at a specified amount
        public void Deal(int amount)
        {
            Console.WriteLine("\nYour hand:");

            for (int i = 0; i < amount; i++)
            {
                cards[rng.Next(0,52)].Print();
            }
        }
    } // End Class Deck
}
