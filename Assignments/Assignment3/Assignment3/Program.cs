//1) Write a program in C# to accept a word from the user and display the length of it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------");
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            int length = word.Length;

            Console.WriteLine($"The length of the word '{word}' is {length}.");

            Program.reverse();
            Program.same();

            Console.ReadLine();
        }
        //2. Write a program in C# to accept a word from the user and display the reverse of it. 
        public static void reverse()
        {
            Console.WriteLine("-----------");
            Console.Write("Enter a word: ");
            string input = Console.ReadLine();

            // Convert the string to a character array
            //char[] charArray = input.ToCharArray();
            char[] charArray = new char[input.Length];


            for (int i = 0; i < input.Length; i++)

            {

                charArray[i] = input[i];

            }

            // Reverse the character array
            Array.Reverse(charArray);

            // Create a new string from the reversed character array
            string reversedWord = new string(charArray);

            Console.WriteLine("Reversed word: " + reversedWord);
        }
        //3.	Write a program in C# to accept two words from user and find out if they are same. 
        public static void same()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Enter the first word:");
            string word1 = Console.ReadLine();

            Console.WriteLine("Enter the second word:");
            string word2 = Console.ReadLine();

            if (string.Equals(word1, word2, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The words are the same.");
            }
            else
            {
                Console.WriteLine("The words are different.");

            }
        }
    }
}
