/* 
 * Wyatt H. Baker
 * PE - 2d Arrays
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1sHTLdpL9oFUDTzCVaOG38gYA_nSnDhd7MVY6IYx2P4A/edit
 *      
 * Last edited 09-28-24 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_2dArrays_Baker
{
    internal class Program
    {
        // --- Fill an array with numbers incremented by 1 from the provided starting point -------
        public static void Fill2DArray(int[,] array, int startNum)
        {
            // Iterate through the rows to fill one column at a time
            for (int i = 0; i < array.GetLength(0); i++)
            {
                // Iterate through the columns to fill each element in the row
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = startNum;
                    startNum += 1;
                }
            }
        }

        // --- Print out an array with proper formatting ------------------------------------------
        public static void Print2DArray(int[,] array)
        {
            // Run a loop based on the number of columns to print the header
            for (int i = 0; i < array.GetLength(1); i++)
            {
                Console.Write("\tCol {0}", i + 1);
            }

            // Iterate through the rows to print a header,
            // then the columns to print each row element
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("\nRow {0}:", i + 1);

                // Iterate through columns to print the next element
                for (int j = 0;j < array.GetLength(1); j++)
                {
                    Console.Write("\t" + array[i, j]);
                }
            }

        }


        // --- Main Method ------------------------------------------------------------------------
        static void Main(string[] args)
        {
            // Initiate a 2D array of 2 x 4 elements with sequential values
            int[,] integerArray = new int[2, 4];
            Fill2DArray(integerArray, 10);

            // Print values in the array
            Print2DArray(integerArray);
        }

    }
}
