using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenus
{
    // Menu item to change the color of the console background
    // Last edited 10-12-2024 by Wyatt H. Baker

    class ChangeColorItem : MenuItem
    {
        // ~~~ FIELDS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Random rng;

        // ~~~ PROPERTIES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ CONSTRUCTORS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ChangeColorItem(Random rng)
            : base
            (
                 "COLOR", "Change the menu color", "The color is now: "
            )
        {
            this.rng = rng;
        }

        // ~~~ OVERRIDES from Object ~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ METHODS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // But a child class has the option to do override and implement
        // differently
        public override void Run()
        {

            // Generate a random number to determine the next color
            int color = rng.Next(0, 3);
            string colorName;


            // Set the color to the console
            switch (color)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    colorName = "green";
                    break;

                case 1:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    colorName = "red";
                    break;

                case 2:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    colorName = "yellow";
                    break;

                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    colorName = "Black";
                    break;

            }
            Console.Write(actionText + colorName);
        }
    }
}
