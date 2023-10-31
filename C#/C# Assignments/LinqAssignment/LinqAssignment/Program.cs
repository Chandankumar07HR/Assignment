using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
           {
           new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
           new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
           new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
           new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
           new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
           new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
           new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
           new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
           new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
           new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" }
           };

            // 1. Display employees who joined before 1/1/2015
            Console.WriteLine("-----------------employees who joined before 1/1/2015---------------------------------");
            var employeesJoinedBefore2015 = empList.FindAll(emp => emp.DOJ < DateTime.Parse("1/1/2015"));
            foreach (var emp in employeesJoinedBefore2015)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.DOJ}");
            }



            // 2. Display employees with DOB after 1/1/1990
            Console.WriteLine("----------------- employees with DOB after 1/1/1990-------------------------------");
            var employeesDOBAfter1990 = empList.FindAll(emp => emp.DOB > DateTime.Parse("1/1/1990"));
            foreach (var emp in employeesDOBAfter1990)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.DOB}");
            }


            // 3. Display employees with designation "Consultant" or "Associate"
            Console.WriteLine("---------------------  employees with designation Consultant or Associate  ---------------------------");
            var consultantsAndAssociates = empList.FindAll(emp => emp.Title == "Consultant" || emp.Title == "Associate");
            foreach (var emp in consultantsAndAssociates)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Title}");
            }

            // 4. Display the total number of employees.
            Console.WriteLine("--------------------The total number of employees------------------------------");
            Console.WriteLine($"Total number of employees: {empList.Count}");

            // 5. Display the total number of employees in "Chennai"
            Console.WriteLine("---------------------Total number of employees in Chennai-----------------------------");
            var chennaiEmployees = empList.Count(emp => emp.City == "Chennai");
            Console.WriteLine($"Total employees in Chennai: {chennaiEmployees}");

            // 6. Display the highest employee ID
            Console.WriteLine("-----------------------The highest employee ID---------------------------");
            var highestEmployeeID = empList.Max(emp => emp.EmployeeID);
            Console.WriteLine($"Highest Employee ID: {highestEmployeeID}");

            // 7. Display the total number of employees who joined after 1/1/2015
            Console.WriteLine("---------------------The total number of employees who joined after 1/1/2015-----------------------------");
            var employeesJoinedAfter2015 = empList.Count(emp => emp.DOJ > DateTime.Parse("1/1/2015"));
            Console.WriteLine($"Employees joined after 1/1/2015: {employeesJoinedAfter2015}");

            // 8. Display the total number of employees with designation other than "Associate"
            Console.WriteLine("--------------------Total number of employees with designation other than Associate------------------------------");
            var nonAssociateEmployees = empList.Count(emp => emp.Title != "Associate");
            Console.WriteLine($"Employees with designation other than Associate: {nonAssociateEmployees}");

            // 9. Display the total number of employees based on city
            Console.WriteLine("--------------------The total number of employees based on city------------------------------");
            var employeesByCity = empList.GroupBy(emp => emp.City).Select(group => new
            {
                City = group.Key,
                Count = group.Count()
            });
            foreach (var city in employeesByCity)
            {
                Console.WriteLine($"City: {city.City}, Total employees: {city.Count}");
            }

            // 10. Display the total number of employees based on city and title
            Console.WriteLine("------------------The total number of employees based on city and title--------------------------------");
            var employeesByCityAndTitle = empList.GroupBy(emp => new { emp.City, emp.Title }).Select(group => new
            {
                City = group.Key.City,
                Title = group.Key.Title,
                Count = group.Count()
            });
            foreach (var group in employeesByCityAndTitle)
            {
                Console.WriteLine($"City: {group.City}, Title: {group.Title}, Total employees: {group.Count}");
            }

            // 11. Display the youngest employee
            Console.WriteLine("------------------The youngest employee--------------------------------");
            var youngestEmployee = empList.OrderBy(emp => emp.DOB).First();
            Console.WriteLine($"Youngest employee: {youngestEmployee.FirstName} {youngestEmployee.LastName}");
            Console.ReadLine();
        }
    }
    
}
