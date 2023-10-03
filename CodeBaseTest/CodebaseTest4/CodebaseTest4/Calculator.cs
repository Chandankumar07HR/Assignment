using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseTest4
{
    //declaration of delegate with a signature
    delegate int CalculatorDelegate(int num1, int num2);

    class Calculator
    {
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }

        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        static void Main(string[] args)
        {
            //instantiating a delegate object and passing the reference of a function
            CalculatorDelegate addition = new CalculatorDelegate(Add);
            CalculatorDelegate subtraction = new CalculatorDelegate(Subtract);
            CalculatorDelegate multiplication = new CalculatorDelegate(Multiply);
            

            // Get user input for two integers
            Console.Write("Enter the first integer: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second integer: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            // Perform calculation using delegates
            int resultAddition = addition(num1, num2);
            int resultSubtraction = subtraction(num1, num2);
            int resultMultiplication = multiplication(num1, num2);

            // Displaying the results
            Console.WriteLine($"Addition Result: {resultAddition}");
            Console.WriteLine($"Subtraction Result: {resultSubtraction}");
            Console.WriteLine($"Multiplication Result: {resultMultiplication}");

            Console.ReadLine();
        }
    }
   
}
