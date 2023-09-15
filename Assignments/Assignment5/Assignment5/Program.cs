using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment5
{
 //1) Create a Class Program which would be used to accepts two  Strings - FirstName and LastName and call the static method Display() that displays the first name in one line and the LastName in the second line after converting the same to upper case.
    class Program
    {
        static void Main()
        {
            // Get the first name and last name from the user.
            Console.WriteLine("Enter the FirstName");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the LastName");
            string lastName = Console.ReadLine();

            // Calling the Display() method to display the first name and last name in uppercase.
            Program.Display(firstName, lastName);

            Program.Occurence();

            Console.ReadLine();
        }

        static void Display(string firstName, string lastName)
        {
            // Converting the First Name and Last name to uppercase.
            firstName = firstName.ToUpper();
            lastName = lastName.ToUpper();

            // Display the first name and last name in separate lines.
            Console.WriteLine($"FirstName is {firstName}");
            Console.WriteLine($"LastName is {lastName}");
        }
 //2) Create a Program to count the no.of occurrences of a letter in a given string
        static void Occurence()
        {
            Console.Write("Enter a string: ");
            string inputString = Console.ReadLine();

            Console.Write("Enter the letter to count: ");
            char letterToCount = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine(); 

            int count = 0;
            foreach (char c in inputString)
            {
                if (char.ToLower(c) == letterToCount)
                {
                    count++;
                }
            }

            Console.WriteLine($"The letter '{letterToCount}' appears {count} times in the input string.");

        }


    }
}
