using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Magic8Ball_Baker
{
    internal class Magic8Ball
    {
        // --- Declare Fields ---------------------------------------------------------------------
        private string owner;
        private int timesShaken;

        private string[] responses;
        private Random rng;


        // --- Constructor ------------------------------------------------------------------------
        public Magic8Ball(string owner)
        {
            this.owner = owner;
            timesShaken = 0;

            responses = 
                [
                "IT IS UNCERTAIN",
                "THE ANSWER IS FORBIDDEN",
                "I'LL NEVER TELL ;)",
                "WOULDN'T YOU LIKE TO KNOW",
                "I RECKON IT IS SO",
                "DON'T EVEN BEGIN TO COUNT ON IT",
                "WHAT'S IT TO YOU?",
                "yeah.",
                "NOT IN A MILLION YEARS"
                ];
            

            rng = new Random();
        }


        // --- Functional Methods -----------------------------------------------------------------
        
        // Returns a random response from the list
        public string ShakeBall()
        {
            timesShaken++;
            return responses[rng.Next(0,responses.Length)];
        }

        public string Report()
        {
            switch (timesShaken)
            {
                case 0:
                    return $"{owner} has not shaken the ball yet.";

                case 1:
                case 2:
                case 3:
                    return $"{owner} has shaken the ball {timesShaken} times.";

                default:
                    return
                        (
                        $"{owner} has shaken the ball {timesShaken} times. " +
                        "That's a lot of questions!"
                        );
            }
        }

    }
}
