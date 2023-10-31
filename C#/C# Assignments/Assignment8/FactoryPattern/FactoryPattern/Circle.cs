using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Circle : IShapes
    {
        //private double radius = 10;

        public float GetArea()
        {
            Console.WriteLine("Enter the Radius");
            double radius = Convert.ToDouble(Console.ReadLine());
            return (float)(Math.PI * radius * radius);
        }

        public float GetCircumference()
        {
            Console.WriteLine("Enter the Radius");
            double radius = Convert.ToDouble(Console.ReadLine());
            return (float)(2 * Math.PI * radius);
        }
    }
}
