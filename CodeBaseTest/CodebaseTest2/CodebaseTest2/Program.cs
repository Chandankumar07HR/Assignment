using System;
using System.Collections.Generic;
using System.Linq;

namespace CodebaseTest2
{
    class Product
    {
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public int Price { set;  get; }

        public Product(int productId, string productName, int price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }
    }
    class Program
    {
        static void Main()
        {
            
            List<Product> products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter details for product " + (i + 1) + ":");
                Console.Write("Product ID: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Price: ");
                int price = Convert.ToInt32(Console.ReadLine());

                // Create a new product and add it to the list
                Product product = new Product(productId, productName, price);
                products.Add(product);
            }

            // Sort the products by price
           
            products = products.OrderBy(p => p.Price).ToList();

            // Display the sorted products
            Console.WriteLine("Sorted Products by Price:");
            foreach (var product in products)
            {
                Console.WriteLine("Product ID: " + product.ProductId + ", Product Name: " + product.ProductName + ", Price: " + product.Price);
            }
            Console.ReadLine();
        }
    }
   
}
