using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class ShapeFactory
    {
        public static IShapes GetShapes(string Shapetype)
        {
            IShapes shape = null;

            if (Shapetype == "Circle")
            {
                shape = new Circle();
            }
            else if (Shapetype == "Rectangle")
            {
                shape = new Rectangle();
            }
            else if(Shapetype == "Triangle")
            {
                shape = new Triangle();
            }
            return shape;
        }
    }
}
