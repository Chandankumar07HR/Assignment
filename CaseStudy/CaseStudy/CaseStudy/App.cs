using System;
using System.Collections.Generic;

public class Student
{
    public int id { get; set; }
    public string name { get; set; }
    public DateTime dateOfBirth { get; set; }

    public Student(int id, string name, DateTime dateOfBirth)
    {
        this.id = id;
        this.name = name;
        this.dateOfBirth = dateOfBirth;
    }
}

public class Course
{
    public int id { get; set; }
    public string name { get; set; }

    public Course(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}

class Enroll
{
    public Student student;
    public Course course;
    public DateTime enrollmentDate;
    public Enroll(Student student, Course course, DateTime enrollmentDate)
    {
        this.student = student;
        this.course = course;
        this.enrollmentDate = enrollmentDate;
    }

    public Student GetStudent()
    {
        return student;
    }

    public Course GetCourse()
    {
        return course;
    }

    public DateTime GetEnrollmentDate()
    {
        return enrollmentDate;
    }
}

class Info
{
    public void display(Student student)
    {
        Console.WriteLine("Student ID: " + student.id);
        Console.WriteLine("Student Name: " + student.name);
        Console.WriteLine("Student Date of Birth: " + student.dateOfBirth);
    }

    public void display(Enroll enrollment)
    {
        Student student = enrollment.GetStudent();
        Course course = enrollment.GetCourse();
        DateTime enrollmentDate = enrollment.GetEnrollmentDate();
        Console.WriteLine("-------------------");
        Console.WriteLine("Enrollment Details:");
        Console.WriteLine("Student ID: " + student.id);
        Console.WriteLine("Student Name: " + student.name);
        Console.WriteLine("Course ID: " + course.id);
        Console.WriteLine("Course Name: " + course.name);
        Console.WriteLine("Enrollment Date: " + enrollmentDate);
    }
}

class AppEngine
{
    private List<Student> students = new List<Student>();
    private List<Course> courses = new List<Course>();
    private List<Enroll> enrollments = new List<Enroll>();

    public void introduce(Course course)
    {
        courses.Add(course);
    }

    public void register(Student student)
    {
        students.Add(student);
    }

    public Student[] listOfStudents()
    {
        return students.ToArray();
    }

    public Course[] listOfCourses()
    {
        return courses.ToArray();
    }

    public void enroll(Student student, Course course)
    {
        enrollments.Add(new Enroll(student, course, DateTime.Now));
    }

    public Enroll[] listOfEnrollments()
    {
        return enrollments.ToArray();
    }
}

public interface UserInterface
{
    void showFirstScreen();
    void showStudentScreen();
    void showAdminScreen();
    void showAllStudentsScreen();
    void showStudentRegistrationScreen();
    void introduceNewCourseScreen();
    void showAllCoursesScreen();
}

public class StudentManagementSystem : UserInterface
{
     AppEngine appEngine = new AppEngine();
     Info info = new Info();

    public void showFirstScreen()
    {
        Console.WriteLine("Welcome to SMS(Student Mgmt. System) v1.0");
        Console.WriteLine("Tell us who you are: \n1. Student\n2. Admin");
        Console.WriteLine("Enter your choice (1 or 2): ");
        int op = Convert.ToInt32(Console.ReadLine());

        switch (op)
        {
            case 1:
                showStudentScreen();
                break;
            case 2:
                showAdminScreen();
                break;
        }
    }

    public void showStudentScreen()
    {
        Console.WriteLine("Welcome, Student!");
        Console.WriteLine("1. Scenario 1");
        Console.WriteLine("2. Scenario 2");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                scenario1Screen();
                break;
            case 2:
                scenario2Screen();
                break;
        }
    }

    public void showAdminScreen()
    {
 
        Console.WriteLine("Welcome, Admin!");

        while(true)
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. Introduce Course");
            Console.WriteLine("3. View All Students");
            Console.WriteLine("4. View All Courses");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    showStudentRegistrationScreen();
                    break;
                case 2:
                    introduceNewCourseScreen();
                    break;
                case 3:
                    showAllStudentsScreen();
                    break;
                case 4:
                    showAllCoursesScreen();
                    break;
                case 5:
                    Console.WriteLine("Exiting Admin Menu.");
                    return;
                default:
                    Console.WriteLine("Invalid choice, Please try again.");
                    break;
            }
        }
    }

    public void showAllStudentsScreen()
    {
        Console.WriteLine("All Students:");
        foreach (Student student in appEngine.listOfStudents())
        {
            info.display(student);
        }
    }

    public void showStudentRegistrationScreen()
    {
        Console.WriteLine("Student Registration:");

        Console.Write("Enter student ID: ");
        int ID = int.Parse(Console.ReadLine());
        Console.Write("Enter student Name: ");
        string Name = Console.ReadLine();
        Console.Write("Enter Student Date Of Birth: ");
        DateTime DOB = Convert.ToDateTime(Console.ReadLine());

        Student newStudent = new Student(ID, Name, DOB);
        appEngine.register(newStudent);

        Console.WriteLine("Student registered successfully!");
    }

    public void introduceNewCourseScreen()
    {
        Console.WriteLine("Course Introduction:");

        Console.Write("Enter Course ID: ");
        int CID = int.Parse(Console.ReadLine());
        Console.Write("Enter Course Name: ");
        string CName = Console.ReadLine();

        Course newCourse = new Course(CID, CName);
        appEngine.introduce(newCourse);

        Console.WriteLine("Course introduced successfully!");
    }

    public void showAllCoursesScreen()
    {
        Console.WriteLine("All Courses:");

        foreach (Course course in appEngine.listOfCourses())
        {
            Console.WriteLine("Course ID: " + course.id);
            Console.WriteLine("Course Name: " + course.name);
        }
    }

    public void scenario1Screen()
    {
        Console.WriteLine("\n scenario1");
        Console.WriteLine("Enter number of students:");
        int noOfStudents = int.Parse(Console.ReadLine());
        for (int i = 0; i < noOfStudents; i++)
        {
            Console.WriteLine($"Enter student {i + 1} details:");
            Console.Write($"Enter student id :");
            int id = int.Parse(Console.ReadLine());
            Console.Write($"Enter student name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter student birthdate (yyyy-MM-dd): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            Student student = new Student(id, name, birthdate);
            appEngine.register(student);
            Console.WriteLine("------------------------------");

            Console.WriteLine("Enter number of course:");
            int noOfcourse = int.Parse(Console.ReadLine());
            for (int j = 0; j < noOfcourse; j++)
            {
                Console.WriteLine($"Enter course {j + 1} details:");
                Console.Write($"Enter course id :");
                int cid = int.Parse(Console.ReadLine());
                Console.Write($"Enter course name: ");
                string cname = Console.ReadLine();

                Course course = new Course(cid, cname);


                appEngine.introduce(course);
                appEngine.enroll(student, course);
            }    
        }
        foreach (Enroll enrollment in appEngine.listOfEnrollments())
        {
            info.display(enrollment);
        }
    }

    public void scenario2Screen()
    {
        Console.WriteLine("Scenario 2");

        // Display all students
         showAllStudentsScreen();
        // Display all courses
        showAllCoursesScreen();
    }
}

class App
{
    static void Main(string[] args)
    {
        //StudentManagementSystem studentmanagementsystem = new StudentManagementSystem();
        //studentmanagementsystem.showFirstScreen();

        new StudentManagementSystem().showFirstScreen();
        Console.ReadLine();
    }
}
