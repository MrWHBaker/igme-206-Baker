// ------------------------------------------------------------------
// DO NOT MODIFY ANY CODE IN THIS FILE EXCEPT:
// - To implement file loading & saving
// - To change the critter types available
// ------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HW6_CritterFarm
{
    /// <summary>
    /// Critter Manager class - Responsible for creating, storing and handling all
    /// critters created in the program. All methods and properties are public and
    /// can be accessed by the program at large, but all fields are private to the 
    /// class.
    /// </summary>
    class CritterManager
    {
        // ----------------------------------------------------------------------
        // Fields
        // ----------------------------------------------------------------------

        /// <summary>
        /// List to hold all of the critters by leveraging polymorphism
        /// </summary>
        private List<Critter> critterList;

        /// <summary>
        /// Reference to the current active critter
        /// </summary>
        private Critter activeCritter;

        /// <summary>
        /// The filename to use when loading/saving critters
        /// </summary>
        private string filename;

        /// <summary>
        /// Generator for any pseuod-random numbers needed
        /// </summary>
        private Random rng = new Random();

        // ----------------------------------------------------------------------
        // Properties
        // ----------------------------------------------------------------------

        /// <summary>
        /// Return the NAME of the current active critter or return null if
        /// one isn't active
        /// </summary>
        public String ActiveCritter 
        {
            get 
            {
                if (activeCritter != null)
                {
                    return activeCritter.Name;
                }
                else
                {
                    return null!; // The ! tells the compiler to ignore warnings about a possible null value.
                }
            } 
        }

        // ----------------------------------------------------------------------
        // Default Constructor
        // ----------------------------------------------------------------------

        /// <summary>
        /// Default constructor to initialize the list and active critter
        /// </summary>
        public CritterManager(string filename)
        {
            critterList = new List<Critter>();
            activeCritter = null!; // The ! tells the compiler to ignore warnings about a possible null value.
            this.filename = filename;
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter setup via user input
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Initial setup of critters. 
        /// Prompts a user for a number of critters, then their names,
        /// then adds newly instantiated critters to the critter list.
        /// All critters start with 0 hunger and 0 boredom.
        /// 
        /// TODO: Review SetupCritters() 
        /// THIS METHOD IS DONE FOR YOU so that you have examples of how to TryParse an enum type and
        /// use a switch statement with enums. You'll have to do both yourself when loading from a file!
        /// </summary>
        public void SetupCritters()
        {
            // Ask user for number of critters and their names
            int numberCritters = SmartConsole.GetValidNumericInput(
                "How many critters should your farm contain (1-5)?",
                1, 5);

            // Gather information about critter names from user,
            //   then create new Critter into the list
            for (int i = 0; i < numberCritters; i++)
            {
                string name = SmartConsole.GetPromptedInput("\nEnter critter " + (i + 1) + " name:");
                string typeString = SmartConsole.GetPromptedInput("What type of critter is "+name+" (Cat, Dog, or Horse)?");
                CritterType type = CritterType.Cat;

                // Enums work with a TryParse too! :)
                while (!Enum.TryParse<CritterType>(typeString, true, out type) // true as the middle param tells TryParse to ignore case
                    || !Enum.IsDefined(typeof(CritterType), type))
                        // TryParse accepts ints that aren't actually valid for this
                        // enum. Using IsDefined checks them before allowing the loop
                        // to proceed.
                {
                    SmartConsole.PrintWarning("Sorry, I don't know how to take care of a "+typeString+".\n");
                    typeString = SmartConsole.GetPromptedInput("What type of critter is " + name + " (Cat, Dog, or Horse)?");
                }

                // Create the correct type of critter
                // TODO: If you don't use Cat, Dog, & Horse as your critter types, fix the setup method

                // The switch statement cases and constructor calls below need to match YOUR critter types
                // TODO: Uncomment this once your child classes exist.
                
                switch (type)
                {
                    case CritterType.Cat:
                        critterList.Add(new Cat(name));
                        break;

                    case CritterType.Dog:
                        critterList.Add(new Dog(name));
                        break;

                    case CritterType.Horse:
                        critterList.Add(new Horse(name));
                        break;

                    default:
                        // shouldn't happen
                        SmartConsole.PrintError(String.Format("Not sure how to create {0} with a type of {1}", name, typeString));
                        i--; // Didn't actually add a critter so go back 1 with our lcv and try again.
                        break;
                }
                
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter file loading and saving
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Loads critter data from a file
        /// If there are no saved critters, calls SetupCritters() to allow user to
        /// enter their own critters.
        /// If file data exists, populates critterList with critters built from
        /// the file's data.
        /// </summary>
        public void LoadCrittersFromFile()
        {
            // ********************************
            // File name: critters.txt
            // File structure (sample line):
            // type|name|hunger #|boredom #
            // ********************************

            // TODO: Implement LoadCrittersFromFile()

            // Create a StreamWriter and attempt to open the file
            StreamReader reader = null;
            string line = "";
            
            try
            {
                reader = new StreamReader(filename);
                
                while ((line = reader.ReadLine()) != null)
                {
                    bool goodData;

                    // Split the line into an array
                    string[] critterInfo = line.Split('|');

                    // Create a new Critter using the data
                    CritterType critterType;
                    goodData = Enum.TryParse(critterInfo[0], out critterType);

                    if (!goodData)
                    {
                        SmartConsole.PrintWarning
                                (
                                    $"{critterInfo[0]}s aren't supported yet. " +
                                    $"Skipping this line: {line}"
                                );
                    }
                    else
                    {

                        string name = critterInfo[1];

                        // Ensure that critter data is properly formatted before loading
                        int hunger;
                        goodData = int.TryParse(critterInfo[2], out hunger);

                        int boredom;
                        goodData = int.TryParse(critterInfo[2], out boredom);

                        if (goodData)
                        {
                            switch (critterType)
                            {
                                case CritterType.Cat:
                                    critterList.Add
                                    (
                                        new Cat
                                        (
                                            critterInfo[1],
                                            int.Parse(critterInfo[2]),
                                            int.Parse(critterInfo[3])
                                        )
                                    );
                                    break;

                                case CritterType.Dog:
                                    critterList.Add
                                    (
                                        new Dog
                                        (
                                            critterInfo[1],
                                            int.Parse(critterInfo[2]),
                                            int.Parse(critterInfo[3])
                                        )
                                    );
                                    break;

                                case CritterType.Horse:
                                    critterList.Add
                                    (
                                        new Horse
                                        (
                                            critterInfo[1],
                                            int.Parse(critterInfo[2]),
                                            int.Parse(critterInfo[3])
                                        )
                                    );
                                    break;

                                default:
                                    SmartConsole.PrintWarning
                                    (
                                        $"{critterInfo[0]}s aren't supported yet. " +
                                        $"Skipping this line: {line}"
                                    );
                                    break;
                            }
                        }
                        else
                        {
                            SmartConsole.PrintWarning("Corrupt data. Skipping this line: " + line);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                SmartConsole.PrintError("Critter save file doesn't exist or can't be opened.");
                SmartConsole.PrintError("\nYou'll need to set up a new critter farm.");
                SetupCritters();
            }

            // Give final result message and close the file
            reader.Close();
            SmartConsole.PrintSuccess($"{critterList.Count} critters loaded successfully");
            
        }


        /// <summary>
        /// Saves critter data to a file.
        /// If there are no saved critters, writes "No critters saved."
        /// If critters do exist, writes their data to the file.
        /// </summary>
        public void SaveCrittersToFile()
        {
            // ********************************
            // File name: critters.txt
            // File structure (sample line):
            // type|name|hunger #|boredom #
            // ********************************

            // TODO: Implement SaveCrittersToFile()

            // Create a StreamWriter and attempt to open the file
            StreamWriter writer = null;
            string line = "";

            try
            {

                writer = new StreamWriter(filename);

                foreach (Critter critter in critterList)
                {
                    writer.WriteLine
                    (
                        "{0}|{1}|{2}|{3}",
                        critter.Name,
                        critter.Type,
                        critter.Hunger,
                        critter.Boredom
                    );
                }
            }
            catch (Exception e)
            {
                SmartConsole.PrintError("Uh oh - Your critters may not have saved.");
                SmartConsole.PrintError(e.Message);
            }

            // Close the file
            if (writer != null)
            {
                writer.Close();
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter Control Methods
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sets the active critter to one of the critters in the critter list.
        /// </summary>
        /// <param name="critterName">Name of critter to set the active critter to</param>
        /// <returns>Whether this operation was successful</returns>
        public bool ChooseCritter(string critterName)
        {
            // Determine if the Critter exists in the list
            // And set it as active
            activeCritter = null!; // The ! tells the compiler to ignore warnings about a possible null value.
            for (int i = 0; i < critterList.Count; i++)
            {
                if (critterList[i].Name == critterName)
                {
                    activeCritter = critterList[i];
                }
            }

            // Let Main know whether this was successful
            return activeCritter != null;
        }

        /// <summary>
        /// Retrieves a list of the names of all current critters
        /// </summary>
        /// <returns>List of names of all critters</returns>
        public List<string> GetCritterNames()
        {
            List<string> critterNames = new List<string>();
            for (int i = 0; i < critterList.Count; i++)
            {
                critterNames.Add(critterList[i].Name);
            }
            return critterNames;
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter Actions
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Feeds the active critter 4 units of food.
        /// </summary>
        public void FeedCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Feeding your critter...");
            activeCritter.Eat();
        }


        /// <summary>
        /// Plays with the active critter for 4 fun units.
        /// </summary>
        public void PlayWithCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Playing with your critter...");
            activeCritter.Play();
        }


        /// <summary>
        /// Talks with the active critter.
        /// </summary>
        public void TalkToCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Talking to your critter...");
            activeCritter.Talk();
        }


        /// <summary>
        /// Simulates time passing for every critter for every "round" of user actions.
        /// </summary>
        public void TimePassing()
        {
            foreach (Critter c in critterList)
            {
                c.PassTime();
                // TODO: Update this to call any child specific methods as well.
                //       For example, in the demo, time passing calls the
                //       the CauseMischeif method on any cats 25% of the time
                if (c is Cat)
                {
                    if (rng.Next(1, 5) == 1)
                    {
                        Cat cat = (Cat)c;
                        cat.CauseChaos();
                    }
                }
            }
        }

        /// <summary>
        /// Prints critter data about every critter in the list.
        /// Helpful for testing. 
        /// </summary>
        public void PrintCritters()
        {
            // Get string representation of every Critter in the list
            for(int i = 0; i < critterList.Count; i++)
            {
                Console.WriteLine("{0} ({2}): {1}", 
                    i + 1,
                    critterList[i],
                    critterList[i].Type);
            }
        }
    }
}
