using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WriteFile
{
    class Program
    {
        static StreamWriter currentFileWriter;
        static void Main(string[] args)
        {
            string fileName = "D:/CS/C#Y1Programming/Intro to External Files/Text Files/test1.txt";
            currentFileWriter = new StreamWriter(fileName);

            for(int count = 1; count <= 5; count++)
            {
                Console.Write("Input line number " + count + ": ");
                string textString = Console.ReadLine();
                currentFileWriter.WriteLine(textString);
            }
            currentFileWriter.Close();
            Console.ReadKey();
        }
    }
}
