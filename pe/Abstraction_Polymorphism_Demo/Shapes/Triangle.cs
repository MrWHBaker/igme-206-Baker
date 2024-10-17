using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    /// <summary>
    /// Triangles are shapes with three sides
    /// </summary>
    internal class Triangle : Shape
    {
        // Technically a triangle can be more complex,
        // but to calculate its area we'll just need its base and height
        private double baseLength;
        private double height;

        // Create a new triangle using the base constructor to save the type
        public Triangle(double baseLength, double height) : base("triangle")
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        // Implement CalculateArea correctly for a triangle
        public override double CalculateArea()
        {
            return 0.5 * baseLength * height;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return 0.5 * baseLength * height;
            }
        }
    }
}
