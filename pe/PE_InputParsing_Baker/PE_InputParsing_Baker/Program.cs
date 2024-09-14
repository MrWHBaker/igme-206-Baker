/* 
 * Wyatt H. Baker
 * PE - Input & Parsing
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1-cwu4r6ES1Cg5RujrKAKU8aGUKaWGBjv5wgFe6IvKmk/edit
 *      
 * Last edited 09-14-24 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_InputParsing_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Variable declarations ------------------------------------

            // Operators
            String name;

            int playTime;

            int pointOneX;
            int pointOneY;

            int pointTwoX;
            int pointTwoY;

            double operatorA;
            double operatorB;

            double degrees;
            double radians;

            // Storage variables to hold operation results
            String userInput;

            int intStorage;
            double doubleStorage;

            // Other necessary variables
            const int HoursInDay = 24;
            const double ThePower = 2;

            const int Round0 = 0;
            const int Round3 = 3;

            const double RadianConversion = Math.PI/180;


            // --- Begin operations ------------------------------------------

            // Print addition operations -----------------------
            Console.WriteLine("--- Addition ---");

            //Get user input
            Console.Write("What is the first number? ");
            userInput = Console.ReadLine();
            operatorA = double.Parse(userInput);

            Console.Write("What is the second number? ");
            userInput = Console.ReadLine();
            operatorB = double.Parse(userInput);

            // Add A and B
            doubleStorage = operatorA + operatorB;
            Console.WriteLine("{0} + {1} = {2}", operatorA, operatorB, doubleStorage);

            // Add A and B casted as integers
            Console.WriteLine("Now I'll add just the whole number parts.");

            intStorage = (int)operatorA + (int)operatorB;
            Console.WriteLine("{0} + {1} = {2}", (int)operatorA, (int)operatorB, intStorage);

            

            // Print Division and Modulus operations ------------
            Console.WriteLine("\n--- DIVISION and MODULUS ---");

            // Get user input
            Console.Write("What is that player's name? ");
            name = Console.ReadLine();

            Console.Write("How many hours have they logged? ");
            userInput = Console.ReadLine();
            playTime = int.Parse(userInput);

            // Calculate days played
            Console.WriteLine("{0} has played a game for {1} hours.", name, playTime);
            Console.WriteLine("They have played for {0} days and {1} hours.", playTime / HoursInDay, playTime % HoursInDay);



            // Print Sine and Cosine operations -----------------
            Console.WriteLine("\n--- SINE and COSINE ---");

            // Get user input
            Console.Write("Enter an angle in degrees: ");
            userInput = Console.ReadLine();
            degrees = double.Parse(userInput);

            // Convert to radians, and calculate sine and cosine
            radians = degrees * RadianConversion;

            Console.WriteLine("{0} degrees is {1} radians.", degrees, radians);
            Console.WriteLine("The sine is {0}", Math.Sin(radians));
            Console.WriteLine("The cosine is {0}", Math.Cos(radians));



            // Print Distance operations -------------------------
            Console.WriteLine("\n--- DISTANCE and ROUNDING ---");

            // Get user input
            Console.Write("Enter Point 1 X: ");
            userInput = Console.ReadLine();
            pointOneX = int.Parse(userInput);

            Console.Write("Enter Point 1 Y: ");
            userInput = Console.ReadLine();
            pointOneY = int.Parse(userInput);

            Console.Write("Enter Point 2 X: ");
            userInput = Console.ReadLine();
            pointTwoX = int.Parse(userInput);

            Console.Write("Enter Point 2 Y: ");
            userInput = Console.ReadLine();
            pointTwoY = int.Parse(userInput);

            // Calculate distance between points 1 and 2
            doubleStorage = (Math.Sqrt(Math.Pow((pointOneX - pointTwoX), ThePower) + Math.Pow((pointOneY - pointTwoY), ThePower)));

            Console.WriteLine("Point One: ({0},{1})", pointOneX, pointOneY);
            Console.WriteLine("Point Two: ({0},{1})", pointTwoX, pointTwoY);
            Console.WriteLine("The distance between these points is {0}", doubleStorage);

            // Print rounding operation
            Console.WriteLine
            (
                    "The distance is {0}, which is approximately {1} units, or {2} to be more precise",
                    doubleStorage, Math.Round(doubleStorage, Round0), Math.Round(doubleStorage, Round3)
            );

            
        }
    }
}
