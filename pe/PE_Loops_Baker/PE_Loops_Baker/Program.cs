/* 
 * Wyatt H. Baker
 * PE - Loops
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1BFxvyQRAT6S3IS4F8xWYHjsIJ-0Gz_nqseCfAGFf-SU/edit
 *      
 * Last edited 09-21-24 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_Loops_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Variable Declaration ------------------------------------------------------------------
            int loopCounter = 0;

            int userInputX;
            int userInputY;

            // --- PART 1 --------------------------------------------------------------------------------
            // Print intigers 0-5 with a while loop
            while (loopCounter <= 5)
            {
                Console.WriteLine(loopCounter);
                loopCounter++;
            }


            // Print integers 100-95 with a do while loop
            Console.WriteLine("");
            loopCounter = 100;

            do
            {
                Console.WriteLine(loopCounter);
                loopCounter--;
            }
            while (loopCounter >= 95);


            // Print intigers 0-25 by 5's with a for loop
            Console.WriteLine("");

            for (int i = 0; i <= 25; i++)
            {
                if (i % 5 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            // This can also be done with the following, but as I understand
            // the previous is closer to the convention stated in class

            /*
            Console.WriteLine("");

            for (int i = 0; i <= 25; i += 5)
            {
                Console.WriteLine(i);
            }
            */

            // --- PART 2 --------------------------------------------------------------------------------
            Console.WriteLine("");

            // Prompt user for dimensions
            Console.Write("Enter a width: ");
            userInputX = int.Parse(Console.ReadLine());

            Console.Write("Enter a height: ");
            userInputY = int.Parse(Console.ReadLine());

            // --- SOLID BOX ---
            // Print "o" the number of times indicated by inputX,
            // and create a new line the number of times indicated by inputY
            for (int i = userInputY; i > 0; i--)
            {
                for (int j = userInputX; j > 0; j--)
                {
                    Console.Write("o");
                }
                Console.WriteLine("");
            }

            // --- OUTLINE ---
            // Print "o" at the top and side edges of the box,
            // and print empty space through the middle
            Console.WriteLine("");

            for (int i = userInputY; i > 0; i--)
            {
                for (int j = userInputX; j > 0; j--)
                {
                    if (j == 1 || j == userInputX || i == userInputY || i == 1)
                    {
                        Console.Write("o");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}