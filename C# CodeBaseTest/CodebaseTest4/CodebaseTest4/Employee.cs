using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseTest4
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }


        static void Main()
        {
            List<Employee> empList = new List<Employee>
            {
              new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984,11,16), DOJ = new DateTime(2011,6,8), City = "Mumbai" },
              new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984,08,20), DOJ = new DateTime(2012,07,07), City = "Mumbai" },
              new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB =new DateTime(1987,11,14), DOJ = new DateTime(2015,04,12), City = "Pune" },
              new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB =new DateTime(1990,06,03), DOJ = new DateTime(2016,02,02), City = "Pune" },
              new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991,03,08), DOJ = new DateTime(2016,02,02), City = "Mumbai" },
              new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989,11,07), DOJ = new DateTime(2014,08,08), City = "Chennai" },
              new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB =new DateTime(1989,12,02), DOJ = new DateTime(2015,06,01), City = "Mumbai" },
              new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993,11,11), DOJ = new DateTime(2014,11,06), City = "Chennai" },
              new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992,08,12), DOJ = new DateTime(2014,12,03), City = "Chennai" },
              new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991,04,12), DOJ =new DateTime(2016,01,02), City = "Pune" }
            };

            //using LINQ Queries
            // a. Display details of all employees
            Console.WriteLine("Display details of all employees");
            var allEmployees = empList;
            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"{employee.EmployeeID} {employee.FirstName} {employee.LastName} {employee.Title} {employee.DOB} {employee.DOJ} {employee.City}");
            }
            Console.WriteLine("--------------------------------------------------------------");

            // b. Display details of employees whose location is not Mumbai
            Console.WriteLine(" Display details of employees whose location is not Mumbai");
            var EmployeesNotInMumbai = empList.Where(e => e.City != "Mumbai");
            foreach (var employee in EmployeesNotInMumbai)
            {
                Console.WriteLine($"{employee.EmployeeID} {employee.FirstName} {employee.LastName} {employee.Title} {employee.DOB} {employee.DOJ} {employee.City}");
            }
            Console.WriteLine("--------------------------------------------------------------");

            // c. Display details of employees whose title is AsstManager
            Console.WriteLine(" Display details of employees whose title is AsstManager");
            var AsstManagers = empList.Where(e => e.Title == "AsstManager");
            foreach (var employee in AsstManagers)
            {
                Console.WriteLine($"{employee.EmployeeID} {employee.FirstName} {employee.LastName} {employee.Title} {employee.DOB} {employee.DOJ} {employee.City}");
            }
            Console.WriteLine("--------------------------------------------------------------");

            // d. Display details of employees whose Last Name starts with 'S'
            Console.WriteLine("Display details of employees whose Last Name starts with 'S'");
            var LastNameStartsWithS = empList.Where(e => e.LastName.StartsWith("S"));
            foreach (var employee in LastNameStartsWithS)
            {
                Console.WriteLine($"{employee.EmployeeID} {employee.FirstName} {employee.LastName} {employee.Title} {employee.DOB} {employee.DOJ} {employee.City}");
            }
            Console.WriteLine("--------------------------------------------------------------");

            Console.ReadLine();
        }
    }


}
