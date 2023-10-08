// 1.Write a C# Sharp program to accept two integers and check whether they are equal or not. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the first number:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("the first number is" + num1);

            Console.WriteLine("Input 2nd number:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("the second number is" + num2);

            if (num1 == num2)
            {
                Console.WriteLine($"{num1} and {num2} are equal");

            }
            else
                Console.WriteLine($"{num1} and {num2} are not equal");

            Program.negative(); //calling nagative() function in main function and the function negative is static so i dont want to create object and the negative function is in same class as of main.
            Program.operations();
            Console.ReadLine();

        }
        //2. Write a C# Sharp program to check whether a given number is positive or negative.
        static void negative()
        {
            Console.WriteLine("-------------");
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number > 0)
            {
                Console.WriteLine($"{number} is a positive number");
            }
            else if (number < 0)
            {
                Console.WriteLine($"{number} is a negative number");
            }
            else
            {
                Console.WriteLine($"{number} is neither positive nor negative");
            }
        }
        //3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 
        /*Test Data
        Input first number: 20
        Input operation: -  
        Input second number: 12
        Expected Output :     
         20 - 12 = 8  */
        static void operations()
        {
            Console.WriteLine("----------------");
            Console.Write("Enter the first number: ");
            if (double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.Write("Enter the operation (+, -, *, /): ");
                char operation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                Console.Write("Enter the second number: ");
                if (double.TryParse(Console.ReadLine(), out double num2))
                {
                    double result = 0.0;

                    switch (operation)
                    {
                        case '+':
                            result = num1 + num2;
                            break;
                        case '-':
                            result = num1 - num2;
                            break;
                        case '*':
                            result = num1 * num2;
                            break;
                        case '/':
                            if (num2 != 0)
                            {
                                result = num1 / num2;
                            }
                            else
                            {
                                Console.WriteLine("Error: Division by zero is not allowed.");
                                return;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid operation.");
                            return;
                    }

                    Console.WriteLine($"{num1} {operation} {num2} = {result}");
                }
                else
                {
                    Console.WriteLine("Invalid second number input.");
                }
            }
            else
            {
                Console.WriteLine("Invalid first number input.");
            }
        }

    }
}
