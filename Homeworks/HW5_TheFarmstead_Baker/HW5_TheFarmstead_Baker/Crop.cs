/* 
 * Last edited 10-14-24 by Wyatt H. Baker
 * No known issues.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_TheFarmstead_Baker
{
    // The Crop class defines information to be tracked about each crop type
    internal class Crop
    {
        // -------- FIELDS ------------------------------------------------------------------------
        private string name;

        private double cost;

        private int growthTime;
        private int daysLeft;


        // -------- PROPERTIES --------------------------------------------------------------------
        // --- get only
        public double SellingPrice { get { return cost * growthTime; } }

        public bool CanHarvest { get { return daysLeft <= 0; } }


        // --- get/set
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int GrowthTime
        {
            get { return growthTime; }
            set { growthTime = value; }
        }

        public int DaysLeft
        {
            get { return daysLeft; }
            set { daysLeft = value; }
        }

        // -------- METHODS -----------------------------------------------------------------------
        // --- Constructors
        public Crop(Crop other)
        {
            name = other.Name;
            cost = other.Cost;
            growthTime = other.GrowthTime;
            daysLeft = growthTime;
        }

        public Crop(string name, double cost, int growthTime)
        {
            this.name = name;
            this.cost = cost;
            this.growthTime = growthTime;
            daysLeft = growthTime;
        }

        // --- Operations
        // Update the crop's day
        public bool DayPassed()
        {
            daysLeft -= 1;
            return false; // TEMPORARY
        }

        // Print the crop's current status
        public override string ToString()
        {
            if (daysLeft <= 0)
            {
                return $"{name} ready to harvest for {SellingPrice:C}";
            }
            else
            {
                return $"{name} has {daysLeft} days left to harvest";
            }
        }

    }
}
