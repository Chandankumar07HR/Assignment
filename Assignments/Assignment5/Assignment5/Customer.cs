using System;
namespace Assignment5
{
  //3. Create a class called Customer with Customerid, Name, Age, Phone,City. Write a constructor with no arguments and another constructor with all information.  Write a method called DisplayCustomer(), which is called directly without any object. Also  include destructor
    class Customer
    {
        public string customerId { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public string city { get; set; }

        public Customer()
        {
            customerId = null;
            name = null;
            age = 0;
            phone = null;
            city = null;
        }

        public Customer(string customer_id, string name, int age, string phone, string city)
        {
            this.customerId = customer_id;
            this.name = name;
            this.age = age;
            this.phone = phone;
            this.city = city;
        }

        public static void DisplayCustomer(Customer customer)
        {
            Console.WriteLine("Customer ID: {0}", customer.customerId);
            Console.WriteLine("Name: {0}",  customer.name);
            Console.WriteLine("Age: {0}",  customer.age);
            Console.WriteLine("Phone: {0}",  customer.phone);
            Console.WriteLine("City: {0}",  customer.city);
        }
        static void Main()
        {

            Console.WriteLine("------3rd question output--------");
            Customer customer1 = new Customer();
            Customer customer2 = new Customer("1030", "karthik", 3, "9740343560", "bangalore");
            Customer.DisplayCustomer(customer1);
            Customer.DisplayCustomer(customer2);
            

            Console.WriteLine("-----4th question output--------");
            Saledetails sale = new Saledetails(1000, 1234, 100, 5, "14-09-2023");
            sale.ShowData();
            sale.Sales();

            Console.ReadLine();


        }
    }
}
