using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concession;

namespace Assignment6
{

    class Program
    {
        public const int TotalFare = 500;
        public string Name { get; set; }
        public int Age { get; set; }

        static void Main()
        {
            //promting user to enter the name and age
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                //creating the object of Concession1 class to access the function CalculatorConcession using object
                Concession1 concession = new Concession1();

                //using object calling the method 
                concession.CalculateConcession(age, name);
            }
            else
            {
                Console.WriteLine("Please enter a valid age");
            }
            Console.ReadLine();
        }
    }
}

