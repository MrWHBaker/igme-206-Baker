/* 
 * Wyatt H. Baker
 * Homework 2: Stats Analysis
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/13uxd-298WyJnL3v0W3L5OD_eGMS3xIth-ASy47Wy42s/edit
 *      
 * Last edited 09-25-24 by Wyatt H. Baker
 * No known issues.
 */

using System.Numerics;

namespace statsAnalysis_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- 1: Declare Variables -------------------------------------------------------------------------------
            // Stat variables are declared twice each, to hold seperate information for players 1 and 2
            // *(This could also be done with n-value arrays for n players -
            // trying to stick to material introduced within this assinment's schedule)
            string name1;
            string name2;

            int wins1;
            int wins2;

            int losses1;
            int losses2;

            int gamesPlayed1;
            int gamesPlayed2;

            // Playtime in hours, accepting fractional values.
            double hoursPlayed1;
            double hoursPlayed2;

            double winPercentage1;
            double winPercentage2;

            // Average game time in minutes without fractions
            int averageGameTime1;
            int averageGameTime2;

            // Boolean so as to produce the same final error stop regardless of issue
            bool errorFlag = false;


            // --- 2: Collect Base Stats and Validate Input -----------------------------------------------------------
            // Prompt and read in each stat sequentially by player.
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========= STATS ANALYZER =========\n");

            // This could also be done with a loop and/or methods, outside of mechanics from this project's scope


            // Player 1:
            Console.Write("Enter the name for Player 1: ");
            name1 = Console.ReadLine().Trim();

            Console.Write("Enter the number of games {0} played: ", name1);
            gamesPlayed1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of games {0} won: ", name1);
            wins1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of games {0} lost: ", name1);
            losses1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the total time played by {0} in hours: ", name1);
            hoursPlayed1 = double.Parse(Console.ReadLine());


            // Validate input and check for bad data
            Console.ForegroundColor = ConsoleColor.DarkRed;

            // Check names for empty strings
            if (name1 == "")
            {
                Console.WriteLine("ERROR: Invalid name for player 1");
                errorFlag = true;
            }

            // Check that numeric values are positive
            if
                (
                    gamesPlayed1 < 0
                    || wins1 < 0
                    || losses1 < 0
                    || hoursPlayed1 < 0
                )
            {
                Console.WriteLine("ERROR: Games & total play time must be non-negative numbers!");
                errorFlag = true;
            }

            // Check if wins and losses sum to total games
            if ( gamesPlayed1 != wins1 + losses1 )
            {
                Console.WriteLine("ERROR: The number of games won and lost does not match the total number of games played!");
                errorFlag = true;
            }

            // Ensure total games and playtime are non-zero
            if (gamesPlayed1 == 0 || hoursPlayed1 == 0)
            {
                Console.WriteLine("ERROR: No stats to calculate for a player with zero games or no play time!!");
                errorFlag = true;
            }

            // Halt program if errors were found
            if (errorFlag)
            {
                Console.WriteLine("\nCannot continue with analysis. Goodbye.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;




            // Repeat for Player 2:
            Console.Write("\nEnter the name for Player 2: ");
            name2 = Console.ReadLine().Trim();

            Console.Write("Enter the number of games {0} played: ", name2);
            gamesPlayed2 = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of games {0} won: ", name2);
            wins2 = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of games {0} lost: ", name2);
            losses2 = int.Parse(Console.ReadLine());

            Console.Write("Enter the total time played by {0} in hours: ", name2);
            hoursPlayed2 = double.Parse(Console.ReadLine());


            // Validate input and check for bad data
            Console.ForegroundColor = ConsoleColor.DarkRed;

            // Check names for empty strings
            if (name2 == "")
            {
                Console.WriteLine("ERROR: Invalid name for player 2");
                errorFlag = true;
            }

            // Check that numeric values are positive
            if
                (
                    gamesPlayed2 < 0
                    || wins2 < 0
                    || losses2 < 0
                    || hoursPlayed2 < 0
                )
            {
                Console.WriteLine("ERROR: Games & total play time must be non-negative numbers!");
                errorFlag = true;
            }

            // Check if wins and losses sum to total games
            if (gamesPlayed2 != wins2 + losses2)
            {
                Console.WriteLine("ERROR: The number of games won and lost does not match the total number of games played!");
                errorFlag = true;
            }

            // Ensure total games and playtime are non-zero
            if (gamesPlayed2 == 0 || hoursPlayed2 == 0)
            {
                Console.WriteLine("ERROR: No stats to calculate for a player with zero games or no play time!!");
                errorFlag = true;
            }

            // Halt program if errors were found
            if (errorFlag)
            {
                Console.WriteLine("\nCannot continue with analysis. Goodbye.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;


            // --- 3: Analyze Data and Display Results ----------------------------------------------------------------
            // Calculate averages and win rates

            averageGameTime1 = (int)((hoursPlayed1 * 60) / gamesPlayed1);
            averageGameTime2 = (int)((hoursPlayed2 * 60) / gamesPlayed2);

            winPercentage1 = (wins1 / (double)gamesPlayed1);
            winPercentage2 = (wins2 / (double)gamesPlayed2);

            // Display information
            Console.WriteLine("\nSummary Table:");

            Console.WriteLine("\t\t\t{0}\t\t{1}", name1, name2);
            Console.WriteLine("\tGames Played\t{0}\t\t{1}", gamesPlayed1, gamesPlayed2);
            Console.WriteLine("\tGames Won\t{0}\t\t{1}", wins1, wins2);
            Console.WriteLine("\tGames Lost\t{0}\t\t{1}", losses1, losses2);
            Console.WriteLine("\tTotal Time (h)\t{0:F1}\t\t{1:F1}", hoursPlayed1, hoursPlayed2);
            Console.WriteLine("\tWin Rate\t{0:P3}\t\t{1:P3}", winPercentage1, winPercentage2);
            Console.WriteLine("\tAvg Time (m)\t{0}\t\t{1}", averageGameTime1, averageGameTime2);


            // Output the player who has a better win rate
            Console.WriteLine();

            if (winPercentage1 == winPercentage2)
            {
                Console.WriteLine("It's a draw!");
            }    
            else if (winPercentage1 > winPercentage2)
            {
                Console.WriteLine("{0} has a better win rate!", name1);
            }
            else
            {
                Console.WriteLine("{0} has a better win rate!", name2);
            }

        }
    }
}
