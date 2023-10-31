using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseTest3
{
    public class Cricket
    {
        public static void Pointscalculation(int no_of_matches)
        {
            int sum = 0;
            int[] scores = new int[no_of_matches];

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.WriteLine("Enter the score for match " + (i + 1) + ": ");
                scores[i] = Convert.ToInt32(Console.ReadLine());
                sum = scores[i] + sum;
            }

            float average = (float)sum / no_of_matches;

            //displaying the sum and average of scores
            Console.WriteLine("The sum of the scores is: " + sum);
            Console.WriteLine("The average of the scores is: " + average);
        }
    }

    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Enter the number of matches played: ");
            int no_of_matches = Convert.ToInt32(Console.ReadLine());
            
            //Pointscalculation method is static so no object created for Cricket class.
            Cricket.Pointscalculation(no_of_matches);
            Console.ReadLine();
        }
    }

}
