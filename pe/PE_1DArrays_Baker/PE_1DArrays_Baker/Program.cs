﻿/* 
 * Wyatt H. Baker
 * PE - 1d Arrays
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1tkjGUPDFXSEDYUME1cV0-89FkmgRUhNV0G_jRE-_u7E/edit
 *      
 * Last edited 09-21-24 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_1DArrays_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ VARIABLES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Some local variables to support playing with different
            // types of arrays in different ways.
            double[] scores = { 1, 1.23, 2, 2.34, 3, 3.45, 4, 4.56, 5, 5.67, 6, 6.78, 7, 7.89, 8, 8.90, 9, 9.01, 10 };
            double sum = 0;
            double average;
            string name; // Yes, this is an array too! Strings use a char[] under the hood.
            const int MaxNum = 50; // This will always be >5
            int[] fives;



            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ FILL ARRAYS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Use a loop to prompt the user for a name that is at least 5 characters long
            do
            {
                Console.Write("Enter a name with at least 5 letters: ");
                name = Console.ReadLine();

                if (name.Length < 5)
                {
                    Console.WriteLine("That name has {0} letters.", name.Length);
                }
            }
            while (name.Length < 5);

            // TODO: Figure out how many multiples of 5 there are between 5 and MaxNum (inclusive),
            //       initialize fives to have an array that will hold that many numbers,
            //       then use a loop to fill it
            fives = new int[MaxNum / 5];

            for (int i = 0; i < fives.Length; i++)
            {
                fives[i] = (i + 1) * 5;
            }


            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ CALCS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Use a loop to calculate the sum of all values in the scores array.
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }

            // TODO: Use the sum and size of the scores array to calculate the average
            average = sum / scores.Length;



            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ OUTPUT ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Without using Substring, print out every other character in the name
            //  (Use a loop and access the characters 1 by 1 instead)
            Console.Write("\nNickname: ");

            for (int i = 0; i < name.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(name[i]);
                }
            }

            // TODO: Print the fives array all on 1 line
            Console.Write("\n\nFives: ");

            for (int i = 0; i < fives.Length; i++)
            {
                Console.Write("{0} ", fives[i]);
            }


            // TODO: Print out the sum and average of the scores as well as a list of all scores
            // that are divisible by 2
            Console.WriteLine("\n\nTotal score: {0}", sum);
            Console.WriteLine("Average score: {0}", average);

            Console.Write("\nScores divisible by 2: ");
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] % 2 == 0)
                {
                    Console.Write("{0} ", scores[i]);
                }
            }

            // Empty space for a cleaner console
            Console.WriteLine("");



        }
    }
}
