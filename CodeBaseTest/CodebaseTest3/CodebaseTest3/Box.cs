using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseTest3
{
    class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }
        public Box(int length, int breadth)
        {
            Length = length;
            Breadth = breadth;
        }
        public void Add(Box third)
        {
            Length = third.Length + Length;
            Breadth = third.Breadth + Breadth;
        }


        public void Display()
        {
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"Breadth: {Breadth}");
        }
    }

    class Test
    {
        public static void Main(string[] args)
        {
            // Prompting the user to enter the length and breadth of the first box.
            Console.WriteLine("Enter the length of the first box:");
            int length1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the breadth of the first box:");
            int breadth1 = Convert.ToInt32(Console.ReadLine());

            // Create a new Box object with the user input.
            Box box1 = new Box(length1, breadth1);

            // Prompting the user to enter the length and breadth of the second box.
            Console.WriteLine("Enter the length of the second box:");
            int length2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the breadth of the second box:");
            int breadth2 = Convert.ToInt32(Console.ReadLine());

            // Creating a new Box object with the user input.
            Box box2 = new Box(length2, breadth2);

            // Add the two boxes together and store the result in a third box.
            Box box3 = new Box(0, 0);
            box3.Add(box1);
            box3.Add(box2);

            // Display the details of the third box.
            Console.WriteLine($"The details of the third box are:");
            box3.Display();
            Console.ReadLine();

        }

    }

}
