using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ArraysOfObjects_Baker
{
    // Card objects represent a single card with a value and suit
    internal class Card
    {
        // --- Fields -----------------------------------------------------------------------------
        private int value;
        private string suit;

        // --- Methods ----------------------------------------------------------------------------
        // Constructor
        public Card(int value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }


        // Print card properties to screen
        public void Print()
        {
            Console.WriteLine($" - {identity()} of {suit}");
        }


        // Method to identify a card's title without storing it as a field
        public string identity()
        {
            switch (value)
            {
                case 1:
                    return "Ace";

                case 11:
                    return "Jack";

                case 12:
                    return "Queen";

                case 13:
                    return "King";

                default:
                    return $"{value}";
            }
        }
    } // End Class Card
}
