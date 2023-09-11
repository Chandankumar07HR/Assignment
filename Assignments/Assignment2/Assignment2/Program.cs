// 1)Write a  Program to assign integer values to an array  and then print the following
//a.	 Average value of Array elements
//b.Minimum and Maximum value in an array
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the number of elements in the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Calculate average
            double sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            double average = sum / n;

            // Find minimum and maximum
            int min = arr[0];
            int max = arr[0];

            for (int i = 1; i < n; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            //printing the results
            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");
            Console.ReadLine();

            Program.secondprogram(); //calling secong program() function in main using class name and not using or creating object because the funis static

        }
        //2.	Write a program in C# to accept ten marks and display the 
        //		following
        //a.Total
        //b.Average
        //c.Minimum marks
        //d.Maximum marks
        //e.Display marks in ascending order
        //f.Display marks in descending order
        static void secondprogram()
        {
            int[] marks = new int[10];

            // Accepting ten marks from the user
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("-----------------");
                Console.Write("Enter mark {0}: ", i + 1);
                //marks[i] = int.Parse(Console.ReadLine());
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Calculating total and average
            int total = marks.Sum();
            double average = (double)total / 10;

            // Finding minimum and maximum marks
            int minMark = marks.Min();
            int maxMark = marks.Max();

            // Sorting marks in ascending order
            int[] ascendingMarks = marks.OrderBy(mark => mark).ToArray();

            // Sorting marks in descending order
            int[] descendingMarks = marks.OrderByDescending(mark => mark).ToArray();


            Console.WriteLine("1) Total: " + total);
            Console.WriteLine("2) Average: " + average);
            Console.WriteLine("3) Minimum Marks: " + minMark);
            Console.WriteLine("4) Maximum Marks: " + maxMark);

            Console.WriteLine("5) Marks in Ascending Order:");
            foreach (int mark in ascendingMarks)
            {
                Console.Write(mark + " ");
            }
            Console.WriteLine();

            Console.WriteLine("6) Marks in Descending Order:");
            foreach (int mark in descendingMarks)
            {
                Console.Write(mark + " ");
            }
            Console.ReadLine();
        }

    }
}