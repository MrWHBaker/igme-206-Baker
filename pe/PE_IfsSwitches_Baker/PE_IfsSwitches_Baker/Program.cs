/* 
 * Wyatt H. Baker
 * PE - If's & Switches
 * IGME 206 1
 *      Instruction document:
 *      https://docs.google.com/document/d/1uuSWGZ0ucs9T6YoB7kT1kYaL9xvL0Rvi3F2drohkIE0/edit
 *      
 * Last edited 09-18-24 by Wyatt H. Baker
 * No known issues.
 */


namespace PE_IfsSwitches_Baker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare Variables
            string userInput;

            int userInt1;
            int userInt2;
            int userInt3;

            // --- QUESTION 1 ----------------------------------------------------------------------------------
            // Prompt the user for the answer to a question to be evaluated
            Console.Write("What chemical element is Coal most prominently comprised of? ");
            userInput = Console.ReadLine().Trim().ToLower();

            // Check whether the answer is correct and respond appropriately
            if (userInput == "carbon" || userInput == "c")
            {
                Console.WriteLine("That's correct!");
            }

            else
            {
                Console.WriteLine("It's carbon! The building block of life! ...I mean not in this particular case, but.");
            }

            // --- QUESTION 2 ----------------------------------------------------------------------------------
            // Prompt the user 3 times to provide specific information 
            Console.WriteLine("\n\nEnter 3 whole numbers in *ascending* order:");

            Console.Write("1: ");
            userInt1 = int.Parse(Console.ReadLine());

            Console.Write("2: ");
            userInt2 = int.Parse(Console.ReadLine());

            Console.Write("3: ");
            userInt3 = int.Parse(Console.ReadLine());

            // Compare the inputs
            // Proper order
            if (userInt1 < userInt2 && userInt2 < userInt3)
            {
                Console.WriteLine("That's correct!");
            }

            // Reverse order
            else if (userInt1 > userInt2 && userInt2 > userInt3)
            {
                Console.WriteLine("Oh so you're some kind of wise guy, eh? I don't have to put up with this. Go to the next question.");
            }

            // Other order
            else
            {
                Console.WriteLine("Is this some kind of joke to you?");
            }

            // --- QUESTION 3 ----------------------------------------------------------------------------------
            // Ask a multiple choice question that has a single correct answer and multiple possible incorrect answers.
            Console.WriteLine("\n\nWhich of these lines does NOT appear in the film \'Star Wars: Revenge of the Sith\'?");
            Console.WriteLine("\ta. \"If you're not with me, than you're my enemy!\"");
            Console.WriteLine("\tb. \"My god, it's full of stars.\"");
            Console.WriteLine("\tc. \"If one is to understand the great mystery, one must study all its aspects\"");
            Console.WriteLine("\td. \"NOOOOOOOOO!\"");

            // Prompt the user for a response
            Console.Write("> ");
            userInput = Console.ReadLine().Trim().ToLower();

            switch (userInput)
            {
                case "a":
                case "c":
                case "d":
                    Console.WriteLine("Nope! Classic line. You really ought to study up. Man, what a great film. Remember when Yoda fights Palpatine? That was so cool.");
                    break;

                case "b":
                    Console.WriteLine("That's right! This line is from the novelization of \'2001: A Space Odyssey\'");
                    break;

                default:
                    Console.WriteLine("What? No. That's not how multiple choice works. You're supposed to say, like, a, or something. You know that.");
                    break;
            }

        }
    }
}
