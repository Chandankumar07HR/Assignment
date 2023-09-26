using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Rectangle : IShapes
    {
        //private int length;
        //private int width;
        public float GetArea()
        {
            Console.WriteLine("Enter the length ");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the width");
            int width = int.Parse(Console.ReadLine());
            float area = length * width;
            return area;
        }

        public float GetCircumference()
        {
            Console.WriteLine("Enter the length ");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the width");
            int width = int.Parse(Console.ReadLine());
            float circumference = 2 * (length + width);
            return circumference;
        }
    }
}
