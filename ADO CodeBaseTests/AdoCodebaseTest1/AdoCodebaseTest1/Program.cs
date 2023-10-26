using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace AdoCodebaseTest1
{
    class Program
    {
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            Insertdata();
            SelectData();
            Console.ReadLine();

        }
        static void Insertdata()
        {
            con = GetConnection();
            Console.WriteLine("Enter employee name: ");
            string empName = Console.ReadLine();
            Console.WriteLine("Enter employee salary: ");
            decimal empSal = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter employee type(F or P): ");
            string empType = Console.ReadLine();
            
            cmd = new SqlCommand("AddEmployee", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@empname", empName));
            cmd.Parameters.Add(new SqlParameter("@empsal", empSal));
            cmd.Parameters.Add(new SqlParameter("@emptype", empType));

            int res = cmd.ExecuteNonQuery();
            if (res > 0)
                Console.WriteLine("Record Inserted");
            else
                Console.WriteLine("Not Inserted..");
        }

        static void SelectData()
        {
            con = GetConnection();
            cmd = new SqlCommand("select * from Code_Employee", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"Employee Number: {dr["empno"]}, Name: {dr["empname"]}, Salary:{dr["empsal"]}, Type:{dr["emptype"]}");
            }
        }
        static SqlConnection GetConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-FFRSBN3; Initial Catalog=CodeBaseTestdb; Integrated Security=True");
            con.Open();
            return con;
        }
    }
}
