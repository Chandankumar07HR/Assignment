using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CaseStudy
{
    public class LocalTime
    {
        public DateTime date { get; set; }
    }
    //creating Student class 
    class Student
    {
       public int Id { get; set;}
       public String Name { get; set; }
       public DateTime DateOfBirth { get; set; }

       public Student(int id, String name, DateTime dateofbirth)
       {
           Id = id;
           Name = name;
           DateOfBirth = dateofbirth;
       }
    }
   // creating Course class
    class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public Course(int courseid, string coursename)
        {
            CourseId = courseid;
            CourseName = coursename;
        }
    }

    // creating Enroll class
    class Enroll
    {
        public Student student;
        public Course course;
        public LocalTime enrollmentDate;

        public Enroll(Student student, Course course, LocalTime enrollmentDate)
        {
            this.student = student;
            this.course = course;
            this.enrollmentDate = enrollmentDate;
        }

    }
    class AppEngine
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        //private List<Enroll> enrollments = new List<Enroll>();
        public void introduce(Course course)
        {

            Info.Displayc(course);
        }
        public void register(Student student)
        {

            Info.Display(student);

        }

        public Student[] listofstudents()
        {   
            return students.ToArray();
        }
        public Course[] listOfCourses()
        {
            return courses.ToArray();
        }
        public void enroll(Student student, Course course)
        {
            Info.Displayenroll(student, course);
        }

    }



    class Info
    {
        public static void Display(Student student)
        {
            Console.WriteLine($"Student ID: {student.Id}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student DOB: {student.DateOfBirth}");
        }

        public static void Displayc(Course course)
        {
            Console.WriteLine($"Student ID: {course.CourseId}");
            Console.WriteLine($"Student Name: {course.CourseName}");
       
        }
        public static void Displayenroll(Student student1, Course course)
        {
            Console.WriteLine($"Student ID: {student1.Id}");
            Console.WriteLine($"Student Name: {student1.Name}");
            Console.WriteLine($"Student DOB: {student1.DateOfBirth}");
            Console.WriteLine($"Student ID: {course.CourseId}");
            Console.WriteLine($"Student Name: {course.CourseName}");
        }
    }

    class App
    {
        static void Main(string[] args)
        {
            App.scenario1();
            App.scenario2();

            AppEngine appEngine = new AppEngine();
            for(int i=0; i<3; i++)
            {
                Console.Write($"Enter student id :");
                int id = int.Parse(Console.ReadLine());
                Console.Write($"Enter student  name: ");
                string name = Console.ReadLine();
                Console.Write($"Enter student  birthdate (yyyy-MM-dd): ");
                DateTime birthdate = DateTime.Parse(Console.ReadLine());
                Student student1 = new Student(id, name, birthdate);
                Info.Display(student1);
               
            }

            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine("Enter Course details:");
                Console.Write("Course ID: ");
                int courseId1 = int.Parse(Console.ReadLine());
                Console.Write("Course Name: ");
                string courseName1 = Console.ReadLine();
                Course course1 = new Course(courseId1, courseName1);
                Info.Displayc(course1);
            }

            //appEngine.introduce();

            
            
            Console.ReadLine();


        }

        static void scenario1()
        {
            Console.WriteLine("\n scenario1");
            Console.WriteLine("Enter number of students:");
            int noOfStudents = int.Parse(Console.ReadLine());
            for(int i=0; i< noOfStudents; i++)
            {
                Console.WriteLine($"Enter student {i + 1} details:");
                Console.Write($"Enter student id :" );
                int id = int.Parse(Console.ReadLine());
                Console.Write($"Enter student name: ");
                string name = Console.ReadLine();
                Console.Write($"Enter student birthdate (yyyy-MM-dd): ");
                DateTime birthdate = DateTime.Parse(Console.ReadLine());

                Student student = new Student(id, name, birthdate);
                Console.WriteLine($"student {i + 1} information:");
                
                Info.Display(student);
                Console.WriteLine("------------------------------");
            }
            
            

        }

        static void scenario2()
        {
            Console.WriteLine("\n scenario2");
            Console.WriteLine("Enter the number of students:");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());
            Student[] studentsArray = new Student[numberOfStudents];

            for (int i = 0; i<numberOfStudents; i++)
            {
                Console.WriteLine($"Enter student{i+1} details:");
                Console.Write($"Enter student ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write($"Enter student name: ");
                string name = Console.ReadLine();
                Console.Write($"Enter student date-of-birth (yyyy-MM-dd): ");
                DateTime birthdate = DateTime.Parse(Console.ReadLine());

                studentsArray[i] = new Student(id, name, birthdate);
                
                
            }
            Console.WriteLine("Students Information:");
            foreach (Student student in studentsArray)
            {
                Info.Display(student);
            }

        }

    }
}
