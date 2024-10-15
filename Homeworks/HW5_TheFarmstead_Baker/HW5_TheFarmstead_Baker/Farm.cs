/* 
 * Last edited 10-15-24 by Wyatt H. Baker
 * No known issues.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_TheFarmstead_Baker
{
    // The Farm class defines how the player can interact with their farm
    internal class Farm
    {
        // -------- FIELDS ------------------------------------------------------------------------
        private int daysPassed = 1;
        private double maintenanceCost;

        private string name;
        private double money;

        Crop[] currentCrops;
        Crop[] availableCrops;

        Random rng;

        // -------- PROPERTIES --------------------------------------------------------------------
        public double Money
        {
            get { return money; }
            set { money = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double potentialEarnings
        {
            get 
            {
                double potentialEarnings = 0;

                // Check each field's crop
                for (int i = 0; i < currentCrops.Length; i++)
                {
                    // Ensure that the field has a crop, and that it's ready to harvest
                    if (currentCrops[i] != null && currentCrops[i].DaysLeft <= 0)
                    {
                        // Add that crop's value to the potential earnings
                        potentialEarnings += currentCrops[i].Cost;
                    }
                }

                return potentialEarnings;
            }
        }

        public Crop[] AvailableCrops { get { return AvailableCrops; } }


        // -------- METHODS -----------------------------------------------------------------------
        // Constructors
        public Farm
        (
            Crop[] availableCrops, 
            string name, 
            int numPlots, 
            double money, 
            double maintenanceCost, 
            Random rng
        )
        {
            this.availableCrops = availableCrops;
            this.name = name;
            currentCrops = new Crop[numPlots];
            this.money = money;
            this.maintenanceCost = maintenanceCost;
            this.rng = rng;

            Console.WriteLine($"\n*** {name}, ready for a fruitful season! ***\n");
        }

        // Behavior
        private string BuildFieldList()
        {
            string fieldList = "";

            // Loop through each field to add its information to a string
            for (int i = 0; i < currentCrops.Length; i++)
            {
                string content;

                if (currentCrops[i] == null)
                {
                    content = "Empty";
                }
                else
                {
                    content = currentCrops[i].ToString();
                }

                fieldList += ($" - Field {i + 1}: {content}\n");
            }

            return fieldList;
        }

        public void DayPassed()
        {
            // Random weather event
            int weather = rng.Next(0, 20);

            // 5% chance of blight
            if (weather == 0)
            {
                SmartConsole.PrintError("\nBlight has struck the farm!");
                SmartConsole.PrintError("All our crops are dead! :(");

                // Reset all fields
                for (int i = 0; i < currentCrops.Length; i++)
                {
                    currentCrops[i] = null;
                }
            }
            // 20% chance of rain
            else if (weather < 5)
            {
                SmartConsole.PrintWarning("It rained. Nothing Grew today.");
                SmartConsole.PrintWarning("Hopefully tomorrow will be better.");
            }
            // Good weather
            else
            {
                foreach (Crop c in currentCrops)
                {
                    if (c != null)
                    {
                        c.DayPassed();
                    }
                }
            }

            // Update farm stats
            daysPassed += 1;
            money -= maintenanceCost;

        }

        public void Harvest()
        {
            // First, check if any fields are ready to harvest
            bool canHarvest = false;
            for (int i = 0; i < currentCrops.Length; i++)
            {
                if ( currentCrops[i] != null )
                {
                    canHarvest = true;
                }
            }

            if (!canHarvest)
            {
                SmartConsole.PrintError("\nYou have to plant something first!");
                return;
            }

            // Next, prompt user to chose a field to harvest from
            // Print the fields
            Console.WriteLine("\n\nWhich field would would you like to harvest?");
            Console.WriteLine(BuildFieldList());

            int choice = SmartConsole.GetValidNumericInput(">  ", 1, currentCrops.Length) - 1;

            // Check which field was chosen, and harvest if possible
            // Nothing is planted
            if (currentCrops[choice] == null)
            {
                SmartConsole.PrintError
                ($"You have to plant something in field {choice + 1} first!");
            }
            // Crop is still growing
            else if (!currentCrops[choice].CanHarvest)
            {
                SmartConsole.PrintError($"This crop is not ready!");
            }
            // Crop is ready to harvest
            else
            {
                SmartConsole.PrintSuccess
                ($"Sold {currentCrops[choice].Name} for {currentCrops[choice].SellingPrice:C}");

                // Update the farm's budget and clear the field
                money += currentCrops[choice].SellingPrice;
                currentCrops[choice] = null;
            }


        }

        public void Plant()
        {
            // First, ensure that there is an available field
            int openField = -1;

            for (int i = 0; i < currentCrops.Length; i++)
            {
                if (currentCrops[i] == null)
                {
                    openField = i;

                    // Make sure to end the loop after the first success
                    i = currentCrops.Length;
                }
            }

            // Fail the operation if there's no open field
            if (openField == -1)
            {
                SmartConsole.PrintError("\nUnable to plant right now. Harvest something first.");
                return;
            }


            // Prompt the user to chose a crop to plant from the list of available types
            Console.WriteLine("\n\nSelect a crop to plant:");

            for (int i = 0; i < availableCrops.Length; i++)
            {
                Console.WriteLine
                (
                    "  {0}. {1} (Cost: {2:C})", i+1, availableCrops[i].Name, availableCrops[i].Cost
                );

            }

            int choice = SmartConsole.GetValidNumericInput(">  ", 1, availableCrops.Length) - 1;


            // Plant the crop in the next available field
            currentCrops[openField] = new Crop(availableCrops[choice]);

            SmartConsole.PrintSuccess
            ($"{availableCrops[choice].Name} planted in field #{openField + 1}");

        }

        public void PrintStatus()
        {
            // Give daily report and calculate potential earnings
            Console.WriteLine();
            Console.WriteLine($"Day {daysPassed} at {name} with {money:C} on hand.");

            Console.WriteLine
            ($"We have {potentialEarnings:C} potential earnings from the fields ready to harvest");

            // Determine and print field information
            Console.WriteLine(BuildFieldList());

        }
    }
}
