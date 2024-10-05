using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Lists_Baker
{
    internal class Player
    {
        // -------- Fields ------------------------------------------------------------------------
        private string name;
        private List<string> inventory;

        // -------- Methods -----------------------------------------------------------------------
        // --- Setup ---
        // Properties
        public string Name
        {
            get { return name; }
        }

        // Constructor
        public Player(string name)
        {
            this.name = name;
            inventory = new List<string>();
        }


        // --- Behavior ---
        // Add an item to the inventory
        public void AddToInventory(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"Item {item} added to {name}'s inventory.");
        }

        // Steal the item in a given slot
        public String GetItemInSlot(int index)
        {
            // Make sure the slot has an item
            if (index < 0 || index >= inventory.Count)
            {
                Console.WriteLine($"{index} was not a valid item #!");
                return null;
            }
            // steal the item if so
            else
            {
                Console.WriteLine
                    ($"{inventory[index]} stolen from slot {index} in {name}'s inventory!");

                string stolenItem = inventory[index];
                inventory.RemoveAt(index);
                return stolenItem;
            }
        }

        // Print the full inventory
        public void PrintInventory()
        {
            Console.WriteLine($"{name}'s inventory:");
            // Loop through the list and print each item
            foreach (string item in inventory)
            {
                Console.WriteLine($"\t- {item}");
            }
        }
    }
}
