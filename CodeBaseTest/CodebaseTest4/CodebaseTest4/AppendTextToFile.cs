using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodebaseTest4
{
    public class AppendTextToFile
    {
        public static void Main()
        {
            // Get the path of the file to append text to.
            string filePath = @"D:\DOTNET.ASSIGNMENT\CodeBaseTest\CodebaseTest4\txt.file";

            // Check if the file exists.
            if (!File.Exists(filePath))
            {
                // Create a new file.
                File.Create(filePath);
            }

            StreamWriter writer = new StreamWriter(File.Open(filePath, FileMode.Append));

            // Append the text to the file.
            writer.WriteLine("This is the text to append to the file.");
            Console.WriteLine("The text is added to the file");
            // Close the file.
            writer.Close();
            
            Console.ReadLine();
        }
    }
}
