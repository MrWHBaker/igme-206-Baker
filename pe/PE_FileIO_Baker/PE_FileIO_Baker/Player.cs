using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Player class
 * Holds player information
 * 
 * Last edited 10-10-2024 by Wyatt H. Baker
 * No known issues.
 */

namespace PE_FileIO_Baker
{
    internal class Player
    {
        // -------- Fields ------------------------------------------------------------------------
        private string name;

        private int strength;
        private int health;


        // -------- Properties --------------------------------------------------------------------
        public string Name
        {
            get { return name; }
        }
        public int Strength
        {
            get { return strength; }
        }
        public int Health
        {
            get { return health; }
        }


        // -------- Methods -----------------------------------------------------------------------
        // --- Constructor
        public Player(string name, int strength, int health)
        {
            this.name = name;
            this.strength = strength;
            this.health = health;
        }

        // --- Return all player info
        public string ToString()
        {
            string playerInfo;
            playerInfo = $"Player: {name}. Strength {strength}, Health {health}.";

            return playerInfo;
        }
    } // End Player class
}
