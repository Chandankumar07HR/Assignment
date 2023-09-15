using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    //4. Create a class called Saledetails which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount
    //Create a method called Sales() that takes qty, Price details of the object and updates the TotalAmount as Qty *Price
    //Pass the other information like SalesNo, Productno, Price,Qty and Dateof sale through constructor
    //call the show data method to display the values.

    public class Saledetails
    {
        public int Salesno { get; set; }
        public int Productno { get; set; }
        public double Price { get; set; }
        public string Dateofsale { get; set; }
        public int Qty { get; set; }
        public double Totalamount { get; set; }

        public Saledetails(int salesno, int productno, double price, int qty, string dateofsale)
        {
            this.Salesno = salesno;
            this.Productno = productno;
            this.Price = price;
            this.Qty = qty;
            this.Dateofsale = dateofsale;
            this.Totalamount = qty * price;
        }

        public void Sales()
        {
            this.Totalamount = this.Qty * this.Price;
            Console.WriteLine("total amount is " + this.Totalamount);
        }

        public void ShowData()
        {
            Console.WriteLine("Salesno: {0}", this.Salesno);
            Console.WriteLine("Productno: {0}", this.Productno);
            Console.WriteLine("Price: {0}", this.Price);
            Console.WriteLine("Qty: {0}", this.Qty);
            Console.WriteLine("Dateofsale: {0}", this.Dateofsale);
            Console.WriteLine("Totalamount: {0}", this.Totalamount);
        }
    }
}
