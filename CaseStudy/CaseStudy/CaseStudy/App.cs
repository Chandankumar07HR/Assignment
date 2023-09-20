using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class Student
    {
        public int Id;
        public String Name;
        public DateTime DateOfBirth;

       public Student(int id, String name, DateTime dateofbirth)
       {
           Id = id;
           Name = name;
           DateOfBirth = dateofbirth;
       }
    }

    class Info
    {
        public void Display(Student student)
        {
            Console.WriteLine($"Student ID: {student.Id}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student DOB: {student.DateOfBirth}");
        }
    }

    class App
    {
        static void Main(string[] args)
        {
            App.scenario1();
            App.scenario2();
            Console.ReadLine();
        }

        static void scenario1()
        {
            Console.WriteLine("\n scenario1");
            Student student1 = new Student(01, "chandan", new DateTime(2000, 3, 10));
            Student student2 = new Student(02, "kumar", new DateTime(2001, 10, 5));
            Student student3 = new Student(03, "bharath", new DateTime(2002, 08, 07));
            Info info = new Info();
            info.Display(student1);
            info.Display(student2);
            info.Display(student3);
        }

        static void scenario2()
        {
            Student[] studentsArray = new Student[3];
            studentsArray[0]= new Student(03, "karthik", new DateTime(2003, 9, 09));
            studentsArray[1]= new Student(04, "kishore", new DateTime(2004, 7, 08));
            studentsArray[2] =new Student(05, "chethan", new DateTime(2005, 6, 20));

            Info info = new Info();
            Console.WriteLine(" " + " scenario2");
            foreach (Student student in studentsArray)
            {
                info.Display(student);
            }
        }

    }
}
