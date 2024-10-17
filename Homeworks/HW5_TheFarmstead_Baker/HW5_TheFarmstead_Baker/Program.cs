/* 
 * Wyatt H. Baker
 * HW 5 - The Farmstead
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?tab=t.0
 *      
 * Last edited 10-14-24 by Wyatt H. Baker
 * No known issues.
 */


namespace HW5_TheFarmstead_Baker
{
    internal class Program
    {
        // ******** Helper method to set up a list of crops ***************************************
        static Crop[] PrepCrops()
        {
            // Prepare crop list
            int cropNum = SmartConsole.GetValidNumericInput
            (
                "\nHow many types of crops do you want to define?", 1, 5
            );

            Crop[] cropList = new Crop[cropNum];

            // Prompt the user to fill out each crop type
            for (int i = 0; i < cropNum; i++)
            {
                Console.WriteLine($"\nDefine crop type #{i + 1}");

                // Create a new crop object directly from user input
                cropList[i] = new Crop
                (
                       SmartConsole.GetPromptedInput("  Name:"),
                       SmartConsole.GetValidNumericInput("  Cost:", 1, 500),
                       SmartConsole.GetValidNumericInput("  Days until Harvest:", 1, 10)
                );
            }

            return cropList;
        }



        // ******** Main program method ***********************************************************
        static void Main(string[] args)
        {
            // -------- DECLARE VARIABLES ---------------------------------------------------------
            Farm playerFarm;
            Random rng = new Random();

            int day = 1;



            // -------- SET UP FARM ---------------------------------------------------------------
            // Introduce player
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to Farmstead, your virtual farming adventure!");
            Console.WriteLine
            (
                " Start your farming journey by defining the crops available and naming your farm."
            );

            // Create Farm object directly from user input
            playerFarm = new Farm
            (
                PrepCrops(),

                SmartConsole.GetPromptedInput("\nPlease name your farm:"),

                SmartConsole.GetValidNumericInput
                ("\nHow many fields are available for planting?", 1, 5),

                SmartConsole.GetValidNumericInput
                ("\nHow much money are you starting with?", 1, 1000 ),

                SmartConsole.GetValidNumericInput
                ( "\nWhat is the daily maintenance cost?", 1, 50 ),

                rng
            );



            // -------- MAIN GAME LOOP ------------------------------------------------------------

            do
            {
                // Give daily report
                playerFarm.PrintStatus();

                // Prompt user for action
                char choice = SmartConsole.GetPromptedChoice
                (
                    "  1. Plant crops\n  2. Harvest and sell produce" +
                    "\n  3. Do nothing today\n  4. Quit\n>  ",
                    ['1','2','3','4']
                );

                switch (choice)
                {
                    // Plant crops
                    case '1':
                        playerFarm.Plant();
                        break;

                    case '2':
                        playerFarm.Harvest();
                        break;

                    case '3':
                        Console.WriteLine();
                        break;

                    case '4':
                        SmartConsole.PrintSuccess
                            ($"\n\nYou quit with {playerFarm.Money:C} in the bank!");
                        return;
                }

                playerFarm.DayPassed();

                // Check if the farm still has money to continue loop
                if (playerFarm.Money <= 0)
                {
                    SmartConsole.PrintError($"{playerFarm.Name} ran out of money!");
                    return;
                }

            } while (true);
        }
    }
}
