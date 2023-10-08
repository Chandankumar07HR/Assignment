using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Remove_Characters();
            Program.Multiplication_table();
            Console.ReadLine();
        }

        //1) 1. Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.
        public static void Remove_Characters()
        {
            Console.WriteLine("-----Remove Characters--------");
            Console.Write("Enter the string: ");
            string input = Console.ReadLine();

            Console.Write("Enter the position to remove: ");
            int position = Convert.ToInt32(Console.ReadLine());

            if (position >= 0 && position < input.Length)
            {
                string result = input.Remove(position, 1);
                Console.WriteLine("Result: " + result);
            }
            else
            {
                Console.WriteLine("Invalid position");
            }

        }



        //2)  Write a C# Sharp program that prints the multiplication table of a number as input.
        public static void Multiplication_table()
        {
            Console.WriteLine("----Multiplication table-----------");
            Console.Write("Enter the number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Multiplication Table of " + number + ":");
                for (int i = 1; i <= 10; i++)
                {
                    int result = number * i;
                    Console.WriteLine($"{number} * {i} = {result}");
                }
            }
            else
            {
                //if we not give any number this will be displayed
                Console.WriteLine("Invalid input Please enter the valid number");
            }
        }

    }

}

