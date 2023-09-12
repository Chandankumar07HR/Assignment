
// 2) 2. Create a class called student which has data members like rollno, name, class, Semester, branch, int [] marks=new int marks [5](marks of 5 subjects )

//-Pass the details of student like rollno, name, class, SEM, branch in constructor

//- For marks write a method called GetMarks() and give marks for all 5 subjects

//-Write a method called displayresult, which should calculate the average marks

//-If marks of any one subject is less than 35 print result as failed
//-If marks of all subject is >35, but average is < 50 then also print result as failed
//-If avg > 50 then print result as passed.

//-Write a DisplayData() method to display all values.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Student
{
    public int rollno;
    public string name;
    public string classname;
    public string semester;
    public string branch;
    public int[] marks = new int[5];

    public Student(int rollno, string name, string classname, string semester, string branch)
    {
        this.rollno = rollno;
        this.name = name;
        this.classname = classname;
        this.semester = semester;
        this.branch = branch;
    }

    public void GetMarks()
    {
        for (int i = 0; i < marks.Length; i++)
        {
            Console.WriteLine("Enter marks for subject {0}: ", i + 1);
            marks[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    public void DisplayResult()
    {
        int totalMarks = 0;
        foreach (int mark in marks)
        {
            totalMarks += mark;
        }
        double avgMarks = totalMarks / marks.Length;

        string result;
        if (marks[0] < 35)
        {
            result = "Failed";
        }
        else if (avgMarks < 50)
        {
            result = "Failed";
        }
        else
        {
            result = "Passed";
        }

        Console.WriteLine("Student Result:");
        Console.WriteLine("Roll No: {0}", rollno);
        Console.WriteLine("Name: {0}", name);
        Console.WriteLine("Class: {0}", classname);
        Console.WriteLine("Semester: {0}", semester);
        Console.WriteLine("Branch: {0}", branch);
        Console.WriteLine("Average Marks: {0}", avgMarks);
        Console.WriteLine("Result: {0}", result);
    }

    public void DisplayData()
    {
        Console.WriteLine("Student Details:");
        Console.WriteLine("Roll No: {0}", rollno);
        Console.WriteLine("Name: {0}", name);
        Console.WriteLine("Class: {0}", classname);
        Console.WriteLine("Semester: {0}", semester);
        Console.WriteLine("Branch: {0}", branch);
    }
    
        public static void Main()
        {
            Console.WriteLine("-----1st question output-----");
            // Create a new Student object
            Student student = new Student(103026, "chandan", "degree", "8", "CSE");

            // Get the marks for the student
            student.GetMarks();

            // Display the result of the student
            student.DisplayResult();
            
            // Display the details of the student.
            student.DisplayData();

           
            Console.WriteLine("--------------2nd question output-------------------");

            Accounts account = new Accounts(103367, "chandan", "Savings", "d", 1000, 0);

            // Deposit Rs. 500
            account.Credit(500);

            // Withdraw Rs. 200
            account.Debit(200);

            // Show the account details
            account.ShowData();
            Console.ReadLine();
        }
    }
}
