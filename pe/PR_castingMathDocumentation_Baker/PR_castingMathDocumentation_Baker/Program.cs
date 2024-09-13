/* 
 * Wyatt H. Baker
 * PE - Casting, Math & Documentation
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1ibDROBK1nO4bHIbmaB10vAJ66pUrSGBGLV_ziIb1EAM/edit
 *      
 * Last edited 09-13-24 by Wyatt H. Baker
 * No known issues.
 */

namespace PR_castingMathDocumentation_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Variable declarations ------------------------------------

            // Operators
            String name = "Bart Simpson";

            int playTime = 274;

            int pointOneX = -13;
            int pointOneY = 51;

            int pointTwoX = 17;
            int pointTwoY = 28;

            double operatorA = 7.9;
            double operatorB = 2.25;

            double sixtyDegrees = 60;
            double sixtyDegreesRadians = (sixtyDegrees*(Math.PI/180));

            // Storage variables to hold operation results
            int intStorage;
            double doubleStorage;

            // Other necessary variables
            const int HoursInDay = 24;
            const double ThePower = 2;

            const int Round0 = 0;
            const int Round3 = 3;


            // --- Begin operations ------------------------------------------

            // Print addition operations -----------------------
            Console.WriteLine("--- Addition ---");

            // Add A and B
            Console.WriteLine("Number A: " + operatorA);
            Console.WriteLine("Number B: " + operatorB);

            doubleStorage = operatorA + operatorB;
            Console.WriteLine("{0} + {1} = {2}", operatorA, operatorB, doubleStorage);

            // Add A and B casted as integers
            Console.WriteLine("Now I'll add just the whole number parts.");

            intStorage = (int)operatorA + (int)operatorB;
            Console.WriteLine("{0} + {1} = {2}", (int)operatorA, (int)operatorB, intStorage);



            // Print Division and Modulus operations ------------
            Console.WriteLine("\n--- DIVISION and MODULUS ---");

            // Calculate days played
            Console.WriteLine("{0} has played a game for {1} hours.", name, playTime);
            Console.WriteLine("They have played for {0} days and {1} hours.", playTime/HoursInDay, playTime%HoursInDay);



            // Print Sine and Cosine operations -----------------
            Console.WriteLine("\n--- SINE and COSINE ---");

            Console.WriteLine("{0} degrees is {1} radians.", sixtyDegrees, sixtyDegreesRadians);
            Console.WriteLine("The sine is {0}", Math.Sin(sixtyDegreesRadians));
            Console.WriteLine("The cosine is {0}", Math.Cos(sixtyDegreesRadians));



            // Print Distance operations -------------------------
            Console.WriteLine("\n--- DISTANCE ---");

            // Calculate distance between points 1 and 2
            doubleStorage = (Math.Sqrt(Math.Pow((pointOneX-pointTwoX), ThePower) + Math.Pow((pointOneY-pointTwoY), ThePower)));

            Console.WriteLine("Point One: ({0},{1})", pointOneX, pointOneY);
            Console.WriteLine("Point Two: ({0},{1})", pointTwoX, pointTwoY);
            Console.WriteLine("The distance between these points is {0}", doubleStorage);



            // Print rounding operations -------------------------
            Console.WriteLine("\n--- ROUNDING ---");
            Console.WriteLine
            (
                    "The distance is {0}, which is approximately {1} units, or {2} to be more precise",
                    doubleStorage, Math.Round(doubleStorage, Round0), Math.Round(doubleStorage, Round3)
            );




        }
    }
}
