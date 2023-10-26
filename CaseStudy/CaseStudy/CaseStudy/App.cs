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

    }

    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal fees { get; set; }

    }
    class Enrollment
    {
        public Student student { get; set; }
        public Course course { get; set; }
        public DateTime enrollmentDate { get; set; }

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

                    using (SqlCommand cmd = new SqlCommand("SELECT id, name, fees FROM Courses", con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            decimal fees = reader.GetDecimal(2);
                            Console.WriteLine($"Course ID: {id}, Course Name: {name}, Course Fees: {fees}");
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
                Console.WriteLine("2. Introduce Course");
                Console.WriteLine("3. View All Students");
                Console.WriteLine("4. View All Courses");
                Console.WriteLine("5. Register and Enroll Student for course");
                Console.WriteLine("6. view Enrollment details");
                Console.WriteLine("7. Update enrollment details");
                Console.WriteLine("8. Exit");

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
                        introduceNewCourseScreen();
                        break;
                    case 3:
                        showAllStudentsScreen();
                        break;
                    case 4:
                        showAllCoursesScreen();
                        break;
                    case 5:
                        showStudentRegistrationScreen();
                        break;
                    case 6:
                        showEnrollments();

                        break;
                    case 7:
                        updateEnrollmentDetails();

                        break;
                    case 8:
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
       
        public void introduceNewCourseScreen()
        {
            Console.WriteLine("Course Introduction:");

            Console.Write("Enter Course ID: ");
            int courseID = int.Parse(Console.ReadLine());
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();
            Console.Write("Enter the Course fee: ");
            decimal coursefee = Convert.ToDecimal(Console.ReadLine());

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Courses (id, name, fees) VALUES (@courseID, @courseName, @courseFee)", con))
                    {
                        cmd.Parameters.AddWithValue("@courseID", courseID);
                        cmd.Parameters.AddWithValue("@courseName", courseName);
                        cmd.Parameters.AddWithValue("@courseFee", coursefee);
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

                    using (SqlCommand cmd = new SqlCommand("SELECT id, name, fees FROM Courses", con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //int id = reader.GetInt32(0);
                            //string name = reader.GetString(1);
                            Console.WriteLine("Course ID: " + reader[0]);
                            Console.WriteLine("Course Name: " + reader[1]);
                            Console.WriteLine("Course Fees: "+ reader[2]);
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
        public void showStudentRegistrationScreen()
        {
            Console.WriteLine("Student Registration:");

            Console.Write("Enter student ID: ");
            int studentID = int.Parse(Console.ReadLine());
            Console.Write("Enter student Name: ");
            string studentName = Console.ReadLine();



            Console.Write("Enter Course ID: ");
            int courseID = int.Parse(Console.ReadLine());
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();
            Console.Write("Enter Course Fees: ");
            decimal courseFees = Convert.ToDecimal(Console.ReadLine());



            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();


                    using (SqlCommand enrollCmd = new SqlCommand("INSERT INTO Enrollments (studentId, studentname, courseId, coursename, coursefees, enrollmentDate) VALUES (@studentID, @studentname, @courseID, @coursename, @coursefees, @enrollmentDate)", con))

                    //using (SqlCommand enrollCmd = new SqlCommand("INSERT INTO Enrollments (Enrollmentid, studentId, studentname, courseId, coursename, coursefees, enrollmentDate) VALUES (@Enrollmentid, @studentID, @studentname, @courseID, @coursename, @coursefees, @enrollmentDate)", con))

                    {


                        //enrollCmd.Parameters.AddWithValue("@Enrollmentid", EnrollId);
                        enrollCmd.Parameters.AddWithValue("@studentID", studentID);
                        enrollCmd.Parameters.AddWithValue("@studentname", studentName);
                        enrollCmd.Parameters.AddWithValue("@courseID", courseID);
                        enrollCmd.Parameters.AddWithValue("@coursename", courseName);
                        enrollCmd.Parameters.AddWithValue("@coursefees", courseFees);
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
                            Console.WriteLine("{0,-15}{1,-10}{2,-20}{3,-10}{4,-20}{5,-15}{6,-20}", "Enrollment ID", "Student ID", "Student Name", "Course ID", "Course Name", "Course Fees", "Enrollment Date");

                            while (reader.Read())
                            {
                                int enrollmentId = reader.GetInt32(0);
                                int studentId = reader.GetInt32(1);
                                string studentName = reader.GetString(2);
                                int courseId = reader.GetInt32(3);
                                string courseName = reader.GetString(4);
                                decimal courseFees = reader.GetDecimal(5);
                                DateTime enrollmentDate = reader.GetDateTime(6);
                                Console.WriteLine("{0,-15}{1,-10}{2,-20}{3,-10}{4,-20}{5,-15}{6,-20}", enrollmentId, studentId, studentName, courseId, courseName, courseFees, enrollmentDate);
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
        public void updateEnrollmentDetails()
        {
            Console.WriteLine("Update Enrollment Details:");
            Console.Write("Enter Enrollment ID: ");
            int enrollmentID = int.Parse(Console.ReadLine());
            Console.Write("Enter new Student ID: ");
            int newStudentID = int.Parse(Console.ReadLine());
            Console.Write("Enter new Student Name: ");
            string newStudentName = Console.ReadLine();
            Console.Write("Enter new Course ID: ");
            int newCourseID = int.Parse(Console.ReadLine());
            Console.Write("Enter new Course Name: ");
            string newCourseName = Console.ReadLine();
            Console.Write("Enter new Course Fees: ");
            decimal newCourseFees = Convert.ToDecimal(Console.ReadLine());
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CasestudyDB; Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand updateCmd = new SqlCommand("UPDATE Enrollments SET studentId = @newStudentID, studentname=@newStudentName, courseId = @newCourseID, coursename = @newCourseName, coursefees = @newCourseFees WHERE Enrollmentid = @enrollmentID", con))
                    {
                        updateCmd.Parameters.AddWithValue("@enrollmentID", enrollmentID);
                        updateCmd.Parameters.AddWithValue("@newStudentID", newStudentID);
                        updateCmd.Parameters.AddWithValue("@newStudentName", newStudentName);
                        updateCmd.Parameters.AddWithValue("@newCourseID", newCourseID);
                        updateCmd.Parameters.AddWithValue("@newCourseName", newCourseName);
                        updateCmd.Parameters.AddWithValue("@newCourseFees", newCourseFees);
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Enrollment details updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("No enrollment found with the provided Enrollment ID.");
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
