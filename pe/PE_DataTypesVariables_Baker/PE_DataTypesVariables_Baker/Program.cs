/* Wyatt H. Baker
 * PE - Statements and Expressions
 * IGME 206 practice exercise, as follows:
 * https://docs.google.com/document/d/1U91F590ypwhbyZGczKPR0nOnukeN886Zx_xY-AxTJSE/edit
 * 
 * No known issues
 */

namespace PE_DataTypesVariables_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This program calculates and assigns stats for an RPG character using variables

            // First, declare a variable to hold the character's name
            String name;
            name = ("Steve, but not the one from Minecraft.");

            // Declare a constant value for the total stat pool
            const int StatTotal = 50;

            // Declare variables to hold the character's stats, and one to hold the sum of all stats;
            // Stats will be Strength, Dexterity, Intelligence, Health, Charisma, and the sum declared as characterTotal
            double strength;
            double dexterity;
            double intelligence;
            double health;
            double charisma;
            double characterTotal;

            // Initialize Strength to be 23% of the starting points
            strength = (StatTotal * 0.23);

            // Initialize Dexterity to be half the Strength value
            dexterity = (strength / 2);

            // Initialize Intelligence to be exactly 7
            intelligence = 7;

            // Initialize Health to be the sum of Dex and Int, !MINUS 2!
            health = (dexterity + intelligence - 2);

            // Initialize Charisma to the leftover value
            charisma = (StatTotal - (strength + dexterity + intelligence + health));

            // Add up stats to check that total is correct
            characterTotal = (strength + dexterity + intelligence + health + charisma);

            // Print character data to console
            Console.WriteLine("Name: " + name);

            Console.WriteLine("\nstrength: " + strength);
            Console.WriteLine("Dexterity: " + dexterity);
            Console.WriteLine("Intelligence: " + intelligence);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("charisma: " + charisma);

            // Print characterTotal to verify accuracy
            Console.WriteLine("\nTOTAL: " + characterTotal); 

        }
    }
}
