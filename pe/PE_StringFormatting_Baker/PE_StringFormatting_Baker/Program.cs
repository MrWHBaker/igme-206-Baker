/* 
 * Wyatt H. Baker
 * PE - String Formatting
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1cSjoItBB29vQMierRirOugLgHEsvWvopl3NMiyo79Yg/edit
 *      
 * Last edited 09-14-24 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_StringFormatting_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Variable Declarations ---------------------------------------

            const String StatUpdate = "{0}, you now have {1} health and ${2} remaining.";

            String name;
            String title;
            String nameWithTitle;

            int health = 100;
            double walletBalance;

            String action;
            int actionHealthReq;

            String item;
            double itemCost;



            // --- Player creation ---------------------------------------------

            Console.Write("What is your name brave adventurer? ");
            name = Console.ReadLine();

            Console.Write("What is your title? ");
            title = Console.ReadLine();

            nameWithTitle = String.Format("{0} the {1}", name, title);

            Console.Write("How much money are you carrying? $");
            walletBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("Welcome, {0}!", nameWithTitle);



            // --- Player action -----------------------------------------------

            // Prompt user for desired action and health cost
            Console.Write("\nWhat do you want to do next? ");
            action = Console.ReadLine();

            Console.Write("How much health does it take to do this? ");
            actionHealthReq = int.Parse(Console.ReadLine());

            // Execute action and update player stats
            Console.WriteLine("\nOkay, let's see you {0}!", action);

            health -= actionHealthReq;

            Console.WriteLine(StatUpdate, nameWithTitle, health, walletBalance);


            // --- Player purchase ---------------------------------------------

            // Prompt user for desired item and monetary cost
            Console.Write("\nWhat do you want to buy? ");
            item = Console.ReadLine();

            Console.Write("How much does it normally cost? $");
            itemCost = double.Parse(Console.ReadLine()) * 1.1;

            // Execute purchase and update player stats
            Console.WriteLine("\nYou bought {0} for ${1}!", item, Math.Round(itemCost, 3));

            walletBalance -= itemCost;
            walletBalance = Math.Round(walletBalance, 2);

            Console.WriteLine(StatUpdate, nameWithTitle, health, walletBalance);

        }
    }
}
