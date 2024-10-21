//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
using System.Runtime.CompilerServices;

namespace GDP_Exam_1
{
    /// <summary>
    /// A standalone class to hold Item object instances
    /// </summary>
    class Inventory
    {
        // NO additional fields are permitted.
        private List<Item> items = new List<Item>();

        /// <summary>
        /// Return the number of items within the
        /// inventory's list. Nothing can be changed.
        /// </summary>
        public int NumberItems
        {
            // TODO: Complete the property
            get 
            {
                return items.Count;
            }
        }

        /// <summary>
        /// TODO: Complete the AddItem method to add a provided Item reference
        /// into the inventory list
        /// </summary>
        public void AddItem(Item itemToAdd)
        {
            // Add the provided item to the end of the list
            items.Add(itemToAdd);
        }

        /// <summary>
        /// TODO: Complete the PrintSummary method to print the number of items
        /// in the inventory and then a summary of each item.
        /// </summary>
        public void PrintSummary()
        {
            // First, print the number of items
            Console.WriteLine($"The inventory currenty has {items.Count} item(s):");

            // Iterate the list and run each Item's ToString
            foreach (Item item in items)
            {
                Console.WriteLine("\t" + item.ToString());
            }

            // Print out total weight and weapon damage
            Console.WriteLine("Total weight: {0}", CalculateTotalWeight());
            Console.WriteLine("Total damage from weapon(s): {0}", CalculateTotalDamage());

        }


        /// <summary>
        /// TODO: Complete the CalculateTotalWeight method to return the total
        /// weight of all items in the inventory
        /// </summary>
        private double CalculateTotalWeight()
        {
            // Iterate list and sum each weight
            double total = 0;

            foreach (Item item in items)
            {
                total += item.Weight;
            }

            return total;
        }

        /// <summary>
        /// TODO: Complete CalculateTotalWeight method to return the total
        /// damage of all weapons in the inventory
        /// </summary>
        
        private double CalculateTotalDamage()
        {
            double total = 0;

            foreach (Item item in items)
            {
                if (item is Weapon)
                {
                    // Cast as a weapon
                    Weapon weapon = (Weapon)item;
                    total += weapon.Damage;
                }
            }

            return Math.Round(total,2);
        }
        
        /// <summary>
        /// Loads items from a file line by line
        /// </summary>
        public void LoadItems(string filename)
        {
            StreamReader input = null;

            // TODO: Add exception handling
            try
            {
                input = new StreamReader(filename);
                string line = null;

                while ((line = input.ReadLine()) != null)
                {
                    // TODO: For each line, seperate the data and create
                    // new Food or Weapon objects appropriately
                    string[] nextItem = line.Split('~');
                    Item newItem;

                    // Check if this is a weapon
                    if (nextItem[0] == "Weapon")
                    {
                        newItem = new Weapon
                        (nextItem[1], int.Parse(nextItem[2]), double.Parse(nextItem[3]));
                    }
                    // Anything else must be food
                    else
                    {
                        newItem = new Food
                        (nextItem[1], int.Parse(nextItem[2]), double.Parse(nextItem[3]));
                    }

                    // Add it to the list
                    items.Add(newItem);
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                // Clean up error
                // I think there's a better way to do this, But I wanted to be careful of time
                string error = e.ToString();
                string[] cleanError = error.Split('\'');

                Console.WriteLine("Uh oh: Could not find file '{0}'.", cleanError[1]);
            }

            // Close the file
            if (input != null)
            {
                input.Close();
            }
        }
    }
}
