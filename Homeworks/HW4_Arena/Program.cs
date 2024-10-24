﻿/***
 * Wyatt Baker
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/1eOYYtup_hlHzLSw62bFBEFJY8Qm_7SFdtTi3FH8IIuw/edit
 *
 * Primary upgrades:
 *  1. Enemy Customization
 *  2. Customize Console Interface
 *  
 * Optional extra upgrades:
 *  3.
 *  4.
 *  
 * Known Bugs:
 * 
 * Other notes:
 * 
 */
using System.Security.Cryptography;

namespace HW4_Arena
{
    /// <summary>
    /// Primary class for the console app. Main() will be run on program launch. Other helper methods are
    /// also defined that Main() will need. It's your job to finish them!
    /// 
    /// Do NOT change anything except where explicitly marked with a TODO comment!
    /// See the comments through this program AND read the assignment write-up for details.
    /// </summary>
    internal class Program
    {
        // *** These constants are defined for you to make your code more readable AND help ensure it works
        //     with the code given to you. Do NOT change these!

        // Constants for the tile types
        private const char Empty = ' ';
        private const char Wall = '#';
        private const char Enemy = 'E';
        private const char Player = '@';
        private const char PlayerStart = '0';
        private const char Exit = '1';

        // Constants for directions
        private const char Up = 'w';
        private const char Down = 's';
        private const char Left = 'a';
        private const char Right = 'd';

        // Player stat indices
        private const int Strength = 0;
        private const int Dexterity = 1;
        private const int Constitution = 2;
        private const int Health = 3;

        // Possible fight outcomes
        private const int Win = 0;
        private const int Lose = 1;
        private const int Run = 2;
        private const int Draw = 3;

        // *** Other constants
        // TODO: It's okay to tweak these numbers a bit to balance your game and/or add new ones.
        // (But don't delete what is here. Main needs some of them!)
        const int EnemySpacing = 6;
        const int MaxPoints = 10;
        const int HealthMult = 5;
        const int DamageMult = 5;
        const int EnemyAttack = 5;
        const int EnemyMaxHealth = 50;

        const int EnemyBaseHealth = 10;

        // Random object to be used for enemy types
        static Random rng = new Random();

        // Variables to hold player's console color choices
        static ConsoleColor wallColor;
        static ConsoleColor enemyColor;
        static ConsoleColor playerColor;
        static ConsoleColor startExitColor;

        /// <summary>
        /// DO NOT CHANGE ANY CODE IN MAIN!!!
        /// 
        /// But it's definitely worth reading it to get an understanding of 
        /// how/when your methods will be called.
        /// 
        /// AND it's okay to *temporarily* comment out chunks of code until 
        /// you're ready for them to run to make it easier to test other things.
        /// </summary>
        static void Main(string[] args)
        {
            // ** SETUP **
            // Player's name
            string name;

            // Stats - to make it easier to pass these around between methods, all 4 stats are
            // in a single array with elements in the order [Strength, Dexterity, Constitution, Health]
            // Constants are defined above to help with this.
            int[] stats = new int[4];

            // Define the variable to refer to the final arena
            char[,] arena;

            // Track the player's location as [row, col] (NOT x, y)
            int[] playerLoc = {1, 1};

            // Is the game still running?
            bool stillPlaying = true;

            // How many enemies are left?
            int numEnemies;

            // ** GET PLAYER STATS & BUILD ARENA **
            // Welcome & get stats 
            name = GetPlayerInfo(stats);

            // Build & print the Arena
            arena = BuildArena(out numEnemies);

            // ** GAME LOOP **
            while (stillPlaying)
            {
                // ** PRINT EVERYTHING **

                // Clear the console and then print the arena
                Console.Clear();
                PrintArena(arena, playerLoc);
                Console.WriteLine(
                    $"\n{name}, your stats are: " +
                    $"Strength {stats[Strength]}, " +
                    $"Dexterity {stats[Dexterity]}, " +
                    $"Constitution {stats[Constitution]}, " +
                    $"Health {stats[Health]}");

                // ** DETECT MOVEMENT **

                // Get the desired direction
                char direction = SmartConsole.GetPromptedChoice(
                        $"\n Where would you like to go? {Up}/{Left}/{Down}/{Right} >",
                        new char[] { Up, Left, Down, Right });
                Console.WriteLine();

                // Figure out what is there, but don't move yet
                int[] nextLoc = { playerLoc[0], playerLoc[1] };
                switch (direction)
                {
                    case Up:
                        nextLoc[0]--; // row--
                        break;

                    case Down:
                        nextLoc[0]++; // row++
                        break;

                    case Left:
                        nextLoc[1]--; // col --
                        break;

                    case Right:
                        nextLoc[1]++; // col ++
                        break;
                }

                // ** TAKE ACTION **
                // Act based on what is in the next location (row, col)
                switch(arena[nextLoc[0], nextLoc[1]])
                {
                    // Do nothing. We're stuck.
                    case Wall:
                        Console.WriteLine("\n You can't go there...");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    // Move to that spot
                    case Empty:
                        playerLoc = nextLoc;
                        break;

                    // Launch a new fight and determine how to proceed based on the result
                    case Enemy:
                        switch(Fight(stats))
                        {
                            // Take over the enemy's spot if we win
                            case Win:
                                playerLoc = nextLoc;
                                arena[playerLoc[0], playerLoc[1]] = Empty;
                                numEnemies--;
                                break;

                            // A loss or draw is game over
                            case Lose:
                            case Draw:
                                stillPlaying = false;
                                break;

                            // Run back to the start and regain half health
                            case Run:
                                Console.WriteLine("You retreat to the starting area of the arena to heal up.");
                                playerLoc = new int[] { 1, 1 };
                                stats[Health] += (stats[Constitution] * HealthMult)/2;
                                stats[Health] = Math.Clamp(stats[Health], 0, stats[Constitution] * HealthMult); // cap at max health
                                break;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    case Exit:
                        if(numEnemies > 0)
                        {
                            Console.WriteLine("You must defeat all enemies before you can escape.");
                        }
                        else
                        {
                            Console.WriteLine("You made it to the exit! Congratulations!");
                            stillPlaying = false;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

        }

        /// <summary>
        /// Given a reference to the player's current stats, launch a new fight
        /// </summary>
        /// <param name="stats">A reference to an int[] containing [Strength, Dexterity, Constitution, Health]</param>
        /// <returns>The result of the fight using an int code. See the constants at the top of Program.cs</returns>
        private static int Fight(int[] stats)
        {
            // TODO: Implement the Fight method

            // - Choose a random enemy name
            // - Initialize the enemy's health
            // - Print the start of combat event

            // Combat loop:
            // - Print the player's and enemy's health stats
            // - Prompt the player for action
            // Loop will not have a condition, and will run until a return condition qualifies

            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            string[] enemyTypes = 
            { 
                "goat", "colossal squid", "man-eating tortoise", "birch tree", "mega-gnome"
            };

            int[] enemyHealthMult = {3,4,5,6};

            // Randomize enemy
            string enemyName = enemyTypes[rng.Next(0, enemyTypes.Length)];
            int enemyHealth = enemyHealthMult[rng.Next(0, enemyHealthMult.Length)];
            enemyHealth *= EnemyBaseHealth;

            // Let the player know that combat has started
            Console.WriteLine("An angry {0} attacks you!", enemyName);

            //Begin turn loop
            do
            {
                // Show the player the current stats
                Console.WriteLine
                    (
                    "\nYour current health is {0}, the {1}'s health is {2}",
                    stats[Health], enemyName, enemyHealth
                    );

                // Prompt the player for action
                switch
                (
                    SmartConsole.GetPromptedInput
                    ("What would you like to do? Attack/Run >").ToLower()
                )
                // Run relevant operation
                {
                    // --- Player attacks
                    case "attack":
                        // Damage enemy
                        Console.WriteLine
                            (
                            "You swing at the {0} for {1} damage", 
                            enemyName, stats[Strength] * DamageMult
                            );
                        enemyHealth -= stats[Strength] * DamageMult;

                        // Damage player
                        Console.WriteLine
                            (
                            "The {0} charges at you for {1} damage.",
                            enemyName, EnemyAttack - stats[Dexterity]
                            );
                        stats[Health] -= (EnemyAttack - stats[Dexterity]);

                        // Check if the fight is over
                        // Player and enemy both run out of health
                        if (stats[Health] <= 0 && enemyHealth <= 0)
                        {
                            Console.WriteLine
                                (
                                "You defeated the {0}, but at great cost," +
                                " as you have also lost the fight.",
                                enemyName
                                );

                            return Draw;
                        }
                        // Player wins
                        else if (enemyHealth <= 0)
                        {
                            Console.WriteLine
                                (
                                "\nYou have defeated the {0}! Congradulations!",
                                enemyName
                                );

                            return Win;
                        }
                        // Player loses
                        else if (stats[Health] <= 0)
                        {
                            Console.WriteLine
                                (
                                "Your wounds are too much, the {0} wins this time.",
                                enemyName
                                );

                            return Lose;
                        }

                        break;

                    // --- Player runs
                    case "run":
                        return Run;

                    // --- Bad input
                    default:
                        Console.WriteLine("Command not recognized! Oh no! LOOK OUT!!");

                        // Damage player
                        Console.WriteLine
                            (
                            "The {0} charges at you for {1} damage.",
                            enemyName, EnemyAttack - stats[Dexterity]
                            );
                        stats[Health] -= (EnemyAttack - stats[Dexterity]);

                        if (stats[Health] <= 0)
                        {
                            Console.WriteLine
                                (
                                "Your wounds are too much. " +
                                "The last thing you see is the {0} proclaiming, " +
                                "\"You should have been more careful with your input!\"",
                                enemyName
                                );

                            return Lose;
                        }

                        break;
                }


            } while (true);

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Get the player's name & stats. Stats are loaded into the provided array and
        /// the name is returned.
        /// </summary>
        /// <param name="statsArray">A reference int[4] array that this method will put data into</param>
        /// <returns>The player's name</returns>
        private static string GetPlayerInfo(int[] statsArray)
        {
            // TODO: Implement the GetPlayerInfo method

            // - Use the SmartConsole's GetPromptedInput method to get the player's name
            // - Use the SmartConsole's GetValidIntegerInput to fill out necessary stats
            //     For each stat, calculate the new max based on the previous input
            //     The final unassigned stat points can also be determined from this calculation

            // - This method will also be used to get console customization input

            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Get name and introduce program
            string name = SmartConsole.GetPromptedInput("Welcome, please enter your name: >");
            int points = MaxPoints;
            string[] statTypes = { "Strength", "Dexterity", "Constitution" };

            Console.WriteLine
                (
                "\nHello {0}, I'll need a bit more information from you before we can start." +
                "\nYou have {1} points to build your character and " +
                "three attributes to allocate them to.\n",
                name, MaxPoints
                );

            // Prompt user for stats
            for (int i = 0; i < statTypes.Length; i++)
            {
                statsArray[i] = SmartConsole.GetValidIntegerInput
                    (
                    $"How many points would you like to allocate to {statTypes[i]}? >",
                    1, points
                    );
                points -= statsArray[i];

                if (i < 2)
                {
                    Console.WriteLine($"You have {points} points remaining.\n");
                }
            }
            Console.WriteLine($"You left {points} points unused.\n");

            // Calculate health and return name
            statsArray[Health] = statsArray[Constitution] * HealthMult;


            // Customize Console colors
            ConsoleCustomization();

            return name;
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Given a reference to a 2d array variable (that will be null to start):
        /// - Prompt for the desired size and initialize the array
        /// - Put walls along all borders
        /// - Evenly space enemies every few tiles (vert & hor)
        /// - Put empty cells everywhere else
        /// - Place the player start in the top left
        /// - Place an exit in the bottom right
        /// </summary>
        /// <param name="numEnemies">An out param to store the total number of enemies created</param>
        /// <returns>A reference to the final 2d arena</returns>
        private static char[,] BuildArena(out int numEnemies)
        {
            // Start by setting numEnemies to 0. Increment this whenever you create
            // an enemy and the out param will work just fine. :)
            numEnemies = 0;

            // TODO: Implement the BuildArena method

            // - Prompt the user for width and height using SmartConsole's GetValidIntegerInput method
            // - Design a for loop to fill the 2D arena array.
            //     All items in the array where either index is 0 or the the max should be a border
            //     Use the modulus operation to insert enemy locations
            //     Insert player start and exit last

            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Prompt for arena size and construct array
            int arenaWidth = SmartConsole.GetValidIntegerInput
                ("How wide should the arena be? (Enter a value from 10 to 50) >", 10, 50);
            int arenaHeight = SmartConsole.GetValidIntegerInput
                ("How tall should the arena be? (Enter a value from 10 to 50) >", 10, 50);

            char[,] arena = new char[arenaHeight, arenaWidth];

            // Fill arena array
            for (int i = 0; i < arenaHeight; i++)
            {
                for (int j = 0; j < arenaWidth; j++)
                {
                    // Build walls
                    if (j == 0 || i == 0 || j == arenaWidth - 1 || i == arenaHeight - 1)
                    {
                        arena[i, j] = Wall;
                    }
                    
                    // Place enemies
                    else if (i % EnemySpacing == 0 && j % EnemySpacing == 0)
                    {
                        arena[i, j] = Enemy;
                        numEnemies++;
                    }

                    // Place start and exit
                    else if (i == 1 && j == 1)
                    {
                        arena[i, j] = PlayerStart;
                    }

                    else if (j == arenaWidth - 2 && i == arenaHeight - 2)
                    {
                        arena[i, j] = Exit;
                    }

                    // Fill blank spaces
                    else
                    {
                        arena[i, j] = Empty;
                    }
                }
            }


            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // All done
            return arena;
        }

        /// <summary>
        /// Given a reference to a 2d arena and the player's current location, 
        /// print every character using the correct colors.
        /// </summary>
        /// <param name="arena">A reference to the arena to print. This could be ANY size.</param>
        /// <param name="playerLoc">The player's location in a 1d array with element [row, col]</param>
        private static void PrintArena(char[,] arena, int[] playerLoc)
        {
            // TODO: Implement the PrintArena method

            // - Loop through the arena array and print each row
            // - Compare each item to the player's location so as to print it in the right place
            // - Check for the character in each index and set the color accordingly

            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Loop through each element of the array
            for (int i = 0; i < arena.GetLength(0); i++)
            {
                for (int j = 0; j < arena.GetLength(1); j++)
                {
                    // Check if this is where the player should go
                    if (i == playerLoc[0] && j == playerLoc[1])
                    {
                        Console.ForegroundColor = playerColor;
                        Console.Write(Player);
                    }
                    else
                    {
                        // Determine color
                        switch (arena[i, j]) 
                        {
                            case Wall:
                                Console.ForegroundColor = wallColor;
                                break;

                            case Enemy:
                                Console.ForegroundColor = enemyColor;
                                break;

                            case PlayerStart:
                            case Exit:
                                Console.ForegroundColor = startExitColor;
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                        }

                        // Print character
                        Console.Write(arena[i, j]);
                    }
                        
                }

                // New line to seperate each row
                Console.WriteLine();
                    
            }
            // Reset console color
            Console.ForegroundColor = ConsoleColor.White;
           
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Method to customize the console colors
        /// </summary>
        private static void ConsoleCustomization()
        {
            // Create an array of values of ColsoleColor
            // (Found in Microsoft's .NET Documentation)
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            // Introduce the process and print the player's choices
            Console.WriteLine("Let's customize your dungeon!");
            Console.WriteLine("Here's what we've got available:");

            for (int i = 0; i < colors.Length; i++)
            {
                Console.ForegroundColor = colors[i];
                Console.WriteLine("\t{0}: {1}", i, colors[i]);
            }

            // Empty space to keep Console clean
            Console.WriteLine();


            // Prompt the player for each element
            Console.WriteLine("Now, please choose a color from the list from each element");
            Console.WriteLine("Enter a number (1-15) for each.\n");

            wallColor = colors
                [
                SmartConsole.GetValidIntegerInput("Wall color: >",0,15)
                ];

            enemyColor = colors
                [
                SmartConsole.GetValidIntegerInput("Enemy color: >",0,15)
                ];

            playerColor = colors
                [
                SmartConsole.GetValidIntegerInput("Player color: >", 0, 15)
                ];

            startExitColor = colors
                [
                SmartConsole.GetValidIntegerInput("Start and Exit door color: >", 0, 15)
                ];
        }
    }
}