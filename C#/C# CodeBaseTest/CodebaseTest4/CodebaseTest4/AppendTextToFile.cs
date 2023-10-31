using System;

using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CodebaseTest4
{
    class AppendTextToFile
    {
        static void Main(string[] args)
        {
            program.writedata();
            Console.ReadLine();
        }
    }
    class program
    {
        public static void writedata()
        {
            FileStream fs = new FileStream(@"D:\DOTNET.ASSIGNMENT\CodeBaseTest\CodebaseTest4\txt.file", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("enter the data to file");
            string data = Console.ReadLine();
            sw.Write(data);
            Console.WriteLine("text added successfully");
            sw.Close();
            fs.Close();
        }
    }

}
