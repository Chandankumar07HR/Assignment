using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Triangle : IShapes
    {
        private float height;
        private int side1 = 5;
        private int side2 = 4;
        private int side3 = 3;

        public float GetArea()
        {
            float area = 0.5f * side1 * height;
            return area;
        }

        public float GetCircumference()
        {
            float circumference = side1 + side2 + side3;
            return circumference;
        }
    }
}
