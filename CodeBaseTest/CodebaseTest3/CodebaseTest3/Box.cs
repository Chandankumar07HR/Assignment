using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseTest3
{
    public class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public static Box Add(Box box1, Box box2)
        {
            double length = box1.Length + box2.Length;
            double breadth = box1.Breadth + box2.Breadth;
            return new Box(length, breadth);
        }

        public void Display()
        {
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"Breadth: {Breadth}");
        }
    }

    public class Test
    {
        static void Main()
        {
            Console.WriteLine("Enter the length of the first box:");
            double length1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the breadth of the first box:");
            double breadth1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the length of the second box:");
            double length2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the breadth of the second box:");
            double breadth2 = Convert.ToDouble(Console.ReadLine());

            Box box1 = new Box(length1, breadth1);
            Box box2 = new Box(length2, breadth2);
            Box box3 = Box.Add(box1, box2);

            Console.WriteLine("Details of the third box:");
            box3.Display();
            Console.ReadLine();
        }
    }

}
