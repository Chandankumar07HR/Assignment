using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CaseStudy
{
    class App
    {
        static void Main(string[] args)
        {
            new StudentManagementSystem().showFirstScreen();
            Console.ReadLine();
        }
    }
   
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
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Available Courses:");

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT id, name FROM Courses", con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            Console.WriteLine($"Course ID: {id}, Course Name: {name}");
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("---------------------------------------------");
        }

        public void showAdminScreen()
        {

            Console.WriteLine("Welcome, Admin!");

            while (true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Introduce new Student");
                Console.WriteLine("2. Register and Enroll Student for course");
                Console.WriteLine("3. Introduce Course");
                Console.WriteLine("4. View All Students");
                Console.WriteLine("5. View All Courses");
                Console.WriteLine("6. view Enrollment details");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");

                int choice;

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue; 
                }

                switch (choice)
                {
                    case 1:
                        introduceStudent();
                        break;
                    case 2:
                        showStudentRegistrationScreen();
                        break;
                    case 3:
                        introduceNewCourseScreen();
                        break;
                    case 4:
                        showAllStudentsScreen();
                        break;
                    case 5:
                        showAllCoursesScreen();
                        break;
                    case 6:
                        showEnrollments();
                        break;
                    case 7:
                        Console.WriteLine("Exiting Admin Menu.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, Please try again.");
                        break;
                }
            }
        }
        public void introduceStudent()
        {
            Console.WriteLine("Introduce a New Student:");

            Console.Write("Enter student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student Date Of Birth (YYYY-MM-DD): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Students (id, name, dateOfBirth) VALUES (@id, @name, @dateOfBirth)", con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Student introduced successfully!");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        public void showStudentRegistrationScreen()
        {
            Console.WriteLine("Student Registration:");

            Console.Write("Enter student ID: ");
            int studentID = int.Parse(Console.ReadLine());
            Console.Write("Enter student Name: ");
            string studentName = Console.ReadLine();
            //Console.Write("Enter Student Date Of Birth (YYYY-MM-DD): ");
            //DateTime studentDOB = DateTime.Parse(Console.ReadLine());


            Console.Write("Enter Course ID: ");
            int courseID = int.Parse(Console.ReadLine());
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();

            Console.WriteLine("Enter enrollment id");
            int EnrollId = Convert.ToInt32(Console.ReadLine());

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();

                    //using (SqlCommand studentCmd = new SqlCommand("INSERT INTO Students (id, name, dateOfBirth) VALUES (@studentID, @studentName, @studentDOB)", con))
                    //{
                    //    studentCmd.Parameters.AddWithValue("@studentID", studentID);
                    //    studentCmd.Parameters.AddWithValue("@studentName", studentName);
                    //    studentCmd.Parameters.AddWithValue("@studentDOB", studentDOB);
                    //    studentCmd.ExecuteNonQuery();
                    //}

                    //using (SqlCommand courseCmd = new SqlCommand("INSERT INTO Courses (id, name) VALUES (@courseID, @courseName)", con))
                    //{
                    //    courseCmd.Parameters.AddWithValue("@courseID", courseID);
                    //    courseCmd.Parameters.AddWithValue("@courseName", courseName);
                    //    courseCmd.ExecuteNonQuery();
                    //}

                    using (SqlCommand enrollCmd = new SqlCommand("INSERT INTO Enrollments (Enrollmentid, studentId, studentname, courseId, coursename, enrollmentDate) VALUES (@Enrollmentid, @studentID, @studentname, @courseID, @coursename, @enrollmentDate)", con))
                    {
                        enrollCmd.Parameters.AddWithValue("@Enrollmentid", EnrollId);
                        enrollCmd.Parameters.AddWithValue("@studentID", studentID);
                        enrollCmd.Parameters.AddWithValue("@studentname", studentName);
                        enrollCmd.Parameters.AddWithValue("@courseID", courseID);
                        enrollCmd.Parameters.AddWithValue("@coursename", courseName);
                        enrollCmd.Parameters.AddWithValue("@enrollmentDate", DateTime.Now);
                        enrollCmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Student registered successfully and enrolled for the course!");
                Console.WriteLine("------------------------------------");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        public void introduceNewCourseScreen()
        {
            Console.WriteLine("Course Introduction:");

            Console.Write("Enter Course ID: ");
            int courseID = int.Parse(Console.ReadLine());
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Courses (id, name) VALUES (@courseID, @courseName)", con))
                    {
                        cmd.Parameters.AddWithValue("@courseID", courseID);
                        cmd.Parameters.AddWithValue("@courseName", courseName);
                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Course introduced successfully!");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        public void showAllStudentsScreen()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Registered Students:");

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT id, name, dateOfBirth FROM Students", con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //int id = reader.GetInt32(0);
                            //string name = reader.GetString(1);
                            //DateTime dateOfBirth = reader.GetDateTime(2);
                            Console.WriteLine("Student ID: " + reader[0]);
                            Console.WriteLine("Student Name: " + reader[1]);
                            Console.WriteLine("Student Date of Birth: " + reader.GetDateTime(2));
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("------------------------");
        }

        public void showAllCoursesScreen()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("All Courses:");

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT id, name FROM Courses", con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //int id = reader.GetInt32(0);
                            //string name = reader.GetString(1);
                            Console.WriteLine("Course ID: " + reader[0]);
                            Console.WriteLine("Course Name: " + reader[1]);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("--------------------------");
        }
        public void showEnrollments()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Enrollments", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Enrollments:");
                            Console.WriteLine("Enrollment ID\tStudent ID\tStudent Name\tCourse ID\tCourse Name\tEnrollment Date");
                            while (reader.Read())
                            {
                                int enrollmentId = reader.GetInt32(0);
                                int studentId = reader.GetInt32(1);
                                string studentName = reader.GetString(2);
                                int courseId = reader.GetInt32(3);
                                string courseName = reader.GetString(4);
                                DateTime enrollmentDate = reader.GetDateTime(5);
                                Console.WriteLine($"{enrollmentId}\t\t{studentId}\t\t{studentName}\t\t{courseId}\t\t{courseName}\t\t{enrollmentDate}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No enrollments found.");
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
    }
    
}
