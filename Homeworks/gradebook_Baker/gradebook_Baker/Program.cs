/* 
 * Wyatt H. Baker
 * Homework 3: Gradebook
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1CRdgLx-tmPCrJD4Lz4gKxuINPltc_18wgmnESYKsGXA/edit
 *      
 * Last edited 10-01-24 by Wyatt H. Baker
 * No known issues.
 */


namespace gradebook_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // *** ACTIVITY 1 *********************************************************************
            // --- Declare Variables --------------------------------------------------------------
            int numberOfGrades;
            string[] assignmentNames;
            double[] grades;

            double averageGrade = 0;

            // Necessary data storage for activity 5
            int overAverage;
            double highestGrade;
            double lowestGrade;

            bool duplicateGrade = false;

            // Ask user for number of assignments
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("How many assignments are you saving? ");

            // Loop to request proper input for as long as the user enters invalid numbers

            // This code will be reused - This could be made more efficient with
            // methods, but that is outside this assignment's scope
            do
            {
                // This could be done more effectively with TryParse, but that is outside
                // this assignment's scope

                Console.ForegroundColor = ConsoleColor.Cyan;
                numberOfGrades = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                if (numberOfGrades < 1)
                {
                    Console.Write("That is not a valid number. Enter the number of assignments: ");
                }
            }
            while (numberOfGrades < 1);

            // Set the length of the names and grades array to the user's input
            assignmentNames = new string[numberOfGrades];
            grades = new double[numberOfGrades];

            Console.WriteLine($"You are saving {numberOfGrades} assignments");

            // --- Fill assignments ---------------------------------------------------------------
            // Loop to prompt the user for assignment names and grades

            for (int i = 0; i < numberOfGrades; i++)
            {
                // Ask for the assignment's name
                Console.Write($"\nEnter the name for assignment #{i + 1}: ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                assignmentNames[i] = Console.ReadLine().Trim();
                Console.ForegroundColor = ConsoleColor.White;

                // Ask for the assignment's grade, and validate input
                Console.Write($"Enter the grade for {assignmentNames[i]}: ");

                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    grades[i] = double.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;

                    if (grades[i] < 0 || grades[i] > 100)
                    {
                        Console.Write("Grade must be between 0 and 100. Enter grade: ");
                    }
                }
                while (grades[i] < 0 || grades[i] > 100);

                // Prepare averageGrade variable
                averageGrade += grades[i];
            }

            // Confirm successful inputting
            Console.WriteLine("\nAll grades are entered!\n");



            // *** ACTIVITY 2 *********************************************************************
            // Finalize average grade
            averageGrade = averageGrade / numberOfGrades;

            // Print the formatted grade report
            Console.WriteLine("Grade Report:");

            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.WriteLine("  {0}. {1}: {2}", i + 1, assignmentNames[i], grades[i]);
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Average: {0:F2}", averageGrade);



            // *** ACTIVITY 3 *********************************************************************
            // Ask the user which assignment grade to replace, and verify input

            do
            {
                Console.Write("\nWhich number grade do you want to replace? ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                int input = int.Parse(Console.ReadLine()) - 1;
                Console.ForegroundColor = ConsoleColor.White;

                if (input < 0 || input > numberOfGrades - 1)
                {
                    Console.Write($"Index must be a number between 1 and {numberOfGrades}. Try again. ");
                }
                else
                {
                    // Now that a proper index has been entered, prompt for the new grade
                    Console.Write($"\nWhat is the new grade for {assignmentNames[input]}? ");
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        grades[input] = double.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;

                        if (grades[input] < 0 || grades[input] > 100)
                        {
                            Console.Write("Grade must be between 0 and 100. Enter grade: ");
                        }
                    }
                    while (grades[input] < 0 || grades[input] > 100);

                    Console.WriteLine
                        (
                        "\nReplacing the grade at index {0} with {1}\n",
                        input + 1, grades[input]
                        );

                    // exit the loop once proper input is given
                    break;
                }
            }
            while (true);



            // *** ACTIVITY 4 *********************************************************************
            // Recalculate average grade to account for changed grade
            averageGrade = 0;

            for (int i = 0; i < numberOfGrades; i++)
            {
                averageGrade += grades[i];
            }

            averageGrade /= numberOfGrades;

            // Print the final grade report
            Console.WriteLine("Final Grade Report:");

            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.WriteLine("  {0}. {1}: {2}", i + 1, assignmentNames[i], grades[i]);
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Final average: {0:F2}", averageGrade);



            // *** ACTIVITY 5 *********************************************************************
            // --- Calculate how many grades are above average ------------------------------------
            overAverage = 0;

            for (int i = 0; i < numberOfGrades; i++)
            {
                if (grades[i] > averageGrade)
                {
                    overAverage += 1;
                }
            }
            Console.WriteLine($"\n{overAverage} grades are above average.\n");


            // --- Find highest and lowest grades -------------------------------------------------

            highestGrade = 0;
            // loop to compare each grade entry against the previous max
            for (int i = 0; i < numberOfGrades; i++)
            {
                if (grades[i] > highestGrade)
                {
                    highestGrade = grades[i];
                }
            }
            Console.WriteLine($"The highest grade is {highestGrade}.");


            lowestGrade = 100;
            // loop to compare each grade entry against the previous max
            for (int i = 0; i < numberOfGrades; i++)
            {
                if (grades[i] < lowestGrade)
                {
                    lowestGrade = grades[i];
                }
            }
            Console.WriteLine($"The lowest grade is {lowestGrade}.");


            // --- Find Duplicates ----------------------------------------------------------------
            // First loop uses each grade as a reference point, one a a time
            for (int i = 0; i < numberOfGrades; i++)
            {
                // second loop compares subsequent entries against the reference
                for (int j = i + 1; j < numberOfGrades; j++)
                {
                    if (grades[i] == grades[j])
                    {
                        duplicateGrade = true;
                    }
                }
            }

            // Determine and print result
            Console.WriteLine();

            if (duplicateGrade)
            {
                Console.WriteLine("A grade appears more than once in this set of grades.");
            }
            else 
            {
                Console.WriteLine("All grades are unique.");
            }


        }
    }
}
