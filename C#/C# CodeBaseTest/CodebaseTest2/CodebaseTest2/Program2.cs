using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseTest2
{
    // creating abstract class student.
    public abstract class Student
    {
        // Members
        public string Name {get;set;}
        public int StudentId {get;set;}
        public double Grade {get;set;}

        // Abstract method
        public abstract bool IsPassed(double grade);
    }

    // creating a sub class Undergraduate which inherit all members of student.
    public class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        // Override IsPassed method
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    // creating a Subclass Graduate which inherit all members from student
    public class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        // overriding the Ispassed method 
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Program2
    {
        static void Main()
        {
            // Creating object of class Undergraduate 
            Undergraduate undergradStudent = new Undergraduate("chandan", 1030336, 60.0);

            //Creating object of class Graduate.
            Graduate gradStudent = new Graduate("kumar", 1030448, 70.0);

            // checking if they passed or not
            Console.WriteLine(undergradStudent.Name + " Passed: " + undergradStudent.IsPassed(undergradStudent.Grade));
            Console.WriteLine(gradStudent.Name + " Passed: " + gradStudent.IsPassed(gradStudent.Grade));

            Console.ReadLine();
        }
    }
    
}
