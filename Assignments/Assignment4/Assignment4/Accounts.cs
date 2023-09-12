using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment4
{
    public class Accounts
    {
        public int accountNo;
        public string customerName;
        public string accountType;
        public string transactionType;
        public int amount;
        public int balance;

        public Accounts(int accountNo, string customerName, string accountType, string transactionType, int amount, int balance)
        {
            this.accountNo = accountNo; 
            this.customerName = customerName;
            this.accountType = accountType;
            this.transactionType = transactionType;
            this.amount = amount;
            this.balance = balance;
        }

        public void UpdateBalance()
        {
            if (this.transactionType == "d")
            {
                this.balance += this.amount;
                Console.WriteLine("Amount is deposited successfully");
            }
            else if (this.transactionType == "w")
            {
                if (this.balance < this.amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    this.balance -= this.amount;
                    Console.WriteLine("withdrawn successfully");
                }
            }
        }

        public void Credit(int amount)
        {
            this.amount = amount;
            UpdateBalance();
        }

        public void Debit(int amount)
        {
            this.amount = amount;
            UpdateBalance();
        }

        public void ShowData()
        {
            Console.WriteLine("Account number: {0}", this.accountNo);
            Console.WriteLine("Customer name: {0}", this.customerName);
            Console.WriteLine("Account type: {0}", this.accountType);
            Console.WriteLine("Transaction type: {0}", this.transactionType);
            Console.WriteLine("Amount: {0}", this.amount);
            Console.WriteLine("Balance: {0}", this.balance);
        }

        
    }
}
