using System;
using System.Collections.Generic;

class Student
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

class Course
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
    private Student student;
    private Course course;
    private DateTime enrollmentDate;

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

interface UserInterface
{
    void showFirstScreen();
    void showStudentScreen();
    void showAdminScreen();
    void showAllStudentsScreen();
    void showStudentRegistrationScreen();
    void introduceNewCourseScreen();
    void showAllCoursesScreen();
}

class ConsoleUserInterface : UserInterface
{
    private AppEngine appEngine;

    public ConsoleUserInterface(AppEngine appEngine)
    {
        this.appEngine = appEngine;
    }

    public void showFirstScreen()
    {
        Console.WriteLine("Welcome to SMS(Student Mgmt. System) v1.0");
        Console.WriteLine("Tell us who you are : \n1. Student\n2. Admin");
        Console.WriteLine("Enter your choice ( 1 or 2 ) : ");
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
        //Console.WriteLine("Student details: ");
        //Console.Write("Enter student 1 Id: ");
        //int ID1 = int.Parse(Console.ReadLine());
        //Console.Write("Enter student 1 Name: ");
        //string Name1 = Console.ReadLine();
        //Console.Write("Enter Student Date Of Birth: ");
        //DateTime DOB1 = Convert.ToDateTime(Console.ReadLine());


        //Console.Write("Enter student 2 Id: ");
        //int ID2 = int.Parse(Console.ReadLine());
        //Console.Write("Enter student 2 Name: ");
        //string Name2 = Console.ReadLine();
        //Console.Write("Enter Student Date Of Birth: ");
        //DateTime DOB2 = Convert.ToDateTime(Console.ReadLine());

        //Student s1 = new Student(ID1, Name1, DOB1);
        //Student s2 = new Student(ID2, Name2, DOB2);
        //appEngine.register(s1);
        //appEngine.register(s2);
    }

    public void showAdminScreen()
    {
        // Implement admin screen
    }

    public void showAllStudentsScreen()
    {
        // Implement all students screen
    }

    public void showStudentRegistrationScreen()
    {
       //
    }

    public void introduceNewCourseScreen()
    {
        // Implement introduce new course screen
    }

    public void showAllCoursesScreen()
    {
        // Implement all courses screen
    }
}

class AppEngine
{
    private List<Student> students;
    private List<Course> courses;
    private List<Enroll> enrollments;

    public AppEngine()
    {
        students = new List<Student>();
        courses = new List<Course>();
        enrollments = new List<Enroll>();
    }

    public void register(Student student)
    {
        students.Add(student);
    }
}

class App
{
    static void Main(string[] args)
    {
        AppEngine appEngine = new AppEngine();
        UserInterface userInterface = new ConsoleUserInterface(appEngine);
        userInterface.showFirstScreen();
        Console.ReadLine();
    }
}