using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    /// <summary>
    /// A parallelogram has two sets of parallel sides
    /// </summary>
    internal class Parallelogram : Shape
    {
        // Parallelograms have two different side lengths
        private double baseLength;
        private double height;

        // Create a new circle using the base constructor to save the type
        public Parallelogram(double baseLength, double height) : base("parallelogram")
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        // Implement CalculateArea correctly for a parallelogram
        public override double CalculateArea()
        {
            return baseLength * height;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return baseLength * height;
            }
        }
    }
}
