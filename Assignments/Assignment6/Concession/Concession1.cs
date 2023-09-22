using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concession
{

    public class Concession1
    {
        
        private const int TotalFare = 500;

        public  void CalculateConcession(int age, string name)
        {
            if (age <= 5)
            {
                Console.WriteLine($"free ticket booked for little champ: {name} age:{age}");
            }
            else if (age > 60)
            {
                double concessionAmount = TotalFare * 0.30;
                double discountedFare = TotalFare - concessionAmount;
                Console.WriteLine($"Senior Citizen - Discounted Fare: {discountedFare} for {name} (Age: {age})");
            }
            else
            {
                Console.WriteLine($"Ticket Booked for {name} (Age: {age}) - Fare: {TotalFare}");
            }
        }


    }
}
