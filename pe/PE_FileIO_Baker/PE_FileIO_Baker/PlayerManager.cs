using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Player class
 * Holds a list of player objects
 * 
 * Last edited 10-10-2024 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_FileIO_Baker
{
    internal class PlayerManager
    {
        // -------- Fields ------------------------------------------------------------------------
        private string fileName = "../../../players.txt";
        private List<Player> players = new List<Player>();


        // -------- Methods -----------------------------------------------------------------------
        // --- Constructor
        public PlayerManager() 
        { 
            
        }

        // --- Behaviors
        // Create a new player
        public void CreatePlayer(string name, int strength, int health)
        {
            // Create the player based on input and add it to the list
            Player nextPlayer = new Player(name, strength, health);
            players.Add( nextPlayer );

            // Print confirmation message
            Console.WriteLine("\tAdded {0} to the list.", name);
        }

        // Print all characters in the manager
        public void Print()
        {
            if (players.Count == 0)
            {
                Console.WriteLine("\tThere are no players yet.");
                return;
            }

            foreach (Player player in players)
            {
                Console.WriteLine("\t" + player.ToString());
            }
        }


        // Clear existing players and load data from a file
        public void Load()
        {
            // Empty list
            players.Clear();

            // Read each line from the file
            string line = "";
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(fileName);
                Console.WriteLine("\tLoading data from players.txt");

                while ((line = reader.ReadLine()) != null)
                {

                    // Split received line into pieces
                    string[] playerStats = line.Split(',');

                    // Create a new character with the data
                    Player newPlayer = new Player
                        (
                        playerStats[0],
                        int.Parse(playerStats[1]),
                        int.Parse(playerStats[2])
                        );

                    // Add the new player to the list
                    players.Add( newPlayer );
                    Console.WriteLine("\tAdded {0} to the list.", newPlayer.Name);

                }
            }
            // Catch exception in the event that there is no file
            catch (FileNotFoundException e)
            {
                Console.WriteLine("\tThere is no player data to load");
            }
            // General exception catch for safety
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            // Close the file and print confirmation
            if (reader != null)
            {
                reader.Close();
            }

            if (players.Count > 0)
            {
                Console.WriteLine("\tLoaded all data from file.");
                Console.WriteLine("\t{0} players created.", players.Count);
            }
        } // End Load()


        // Save existing player data to a text file
        public void Save()
        {
            // Checks if there are players to save in the first place
            if (players.Count > 0)
            {
                // prepare streamWriter
                StreamWriter writer = null;

                // Add each player to the file
                try
                {
                    writer = new StreamWriter(fileName);
                    foreach (Player player in players)
                    {
                        writer.WriteLine
                            ("{0},{1},{2}", player.Name, player.Health, player.Strength);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong!");
                    Console.WriteLine(e.ToString());
                }

                // Close file and print confirmation
                if (writer != null)
                {
                    writer.Close();
                    Console.WriteLine("\tSaved {0} players to file players.txt", players.Count);
                }
            }

            // If there are no players to save, notify user
            else
            {
                Console.WriteLine("\tThere is no player data yet.");
            }
        } // End Save()
    } // End PlayerManager class
}
