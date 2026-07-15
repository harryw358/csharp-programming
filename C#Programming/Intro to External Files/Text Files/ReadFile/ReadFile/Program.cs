using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadFile
{
    class Program
    {
        static StreamReader currentFileReader;
        static void Main(string[] args)
        {
            string fileName = "D:/CS/C#Y1Programming/Intro to External Files/Text Files/test1.txt";
            currentFileReader = new StreamReader(fileName);

            while (!currentFileReader.EndOfStream)
            {
                string textString = currentFileReader.ReadLine();
                Console.WriteLine(textString);
            }
            currentFileReader.Close();
            Console.ReadKey();
        }
    }
}
