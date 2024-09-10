/* 
 * Wyatt H. Baker
 * Homework 1 - Character Story
 * IGME 206 01
 *      Instruction document:
 *      https://docs.google.com/document/d/1FL56QqpNtMweNRlBtU3jUyMp3C6c7ABd8IhM5ifgfF4/edit
 *      
 * Last edited 09-10-24 by Wyatt H. Baker
 * No known issues
 */


namespace characterStory_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Variable definitions
            // Value to hold the needed experience to level up
            const int XpToLevel = 15000;

            // Character stats
            String name = "Gnome Soldier #7";
            String gnomeFood = "gravel";
            double health = 20;
            int experience = 11;
            int level = 0;

            // Other game stats
            int parsnipXp = 1;
            int goldenParsnipXp = 42000;
            double minimumDamageValue = 18.5;




            // Print the intro passage ------------------------------------------------
            Console.WriteLine("\n\n    ~~~ Chapter 1: It begins... ~~~");
            Console.WriteLine( name + " has left home for a grand adventure. This shall surely end well for " + name + "!\n");

            // Print character stats
            Console.WriteLine("    STATISTICS");
            Console.WriteLine("   NAME: " + name + "\n   LEVEL: " + level + "\n   HP: " + health + "\n   XP: " + experience);





            // Print Adventure passage, and adjust numeric stats accordingly -----------
            Console.WriteLine("\n\n    ~~~ Chapter 2: Roughing it for Riches! ~~~");

            // Print the first couple game events, and calculate their effects to the character's stats
            Console.WriteLine("Not long after " + name + " sets out into the forest, he discovers a parsnip and gains " + parsnipXp + " XP! ");
            experience += parsnipXp;

            Console.WriteLine("Then, he discovers another parsnip and gains " + parsnipXp + " XP! \n");
            experience += parsnipXp;

            // Print the passage where the gnome gets hurt, and adjust character health
            Console.WriteLine( name + " trips and falls down a steep hill. " + name + " takes " + minimumDamageValue + " damage. ");
            health -= minimumDamageValue;
            Console.WriteLine(health + " points of health remain.");

            // Print the golden parsnip discovery section
            Console.WriteLine(name + " discovers a GOLDEN PARSNIP at the bottom of the hill! He gains " + goldenParsnipXp + " XP!");
            experience += goldenParsnipXp;

            // Calculate the character's change in level, and the remaining experience needed for the next level up
            Console.WriteLine(name + " levels up " + (experience / XpToLevel) + " times!");
            level += (experience / XpToLevel);
            Console.WriteLine(name + " needs " + (XpToLevel - (experience % XpToLevel)) + " XP to level up again.");




            // Print conclusion statement -----------------------------------------------
            Console.WriteLine("\n\n    ~~~ Chapter 3: Returning to normalcy ~~~");
            Console.WriteLine(name + " decides this whole adventuring thing is far beyond his pay grade. Parsnips in hand, he hurries home.");
            Console.WriteLine("It's a journey just as long as the way here, but with all he's learned, " + name + " is able to avoid more damage.\n");
            Console.WriteLine
            (
                name + " arrives home just in time for supper! \nIt's " + gnomeFood 
                + ". This is the kind of gnome that eats " + gnomeFood 
                + ". Did I mention that before? I'm sure I did."
            );

            // Print adjusted character stats
            Console.WriteLine("\n    STATISTICS");
            Console.WriteLine("   NAME: " + name + "\n   LEVEL: " + level + "\n   HP: " + health + "\n   XP: " + experience);


            // Blank lines printed at the end for a nicer looking console
            Console.WriteLine("\n\n\n");









        }
    }
}
