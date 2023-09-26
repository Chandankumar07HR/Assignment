using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter shape type: ");
            string shapetype = Console.ReadLine();

            IShapes cc = ShapeFactory.GetShapes(shapetype);

            if (cc != null)
            {
                Console.WriteLine("Area : {0}", cc.GetArea());
                Console.WriteLine("Circumference : {0}", cc.GetCircumference());
              
            }
            else
            {
                Console.WriteLine("Invalid Card.. please give correct type");
            }
            Console.Read();
        }
    }
}
