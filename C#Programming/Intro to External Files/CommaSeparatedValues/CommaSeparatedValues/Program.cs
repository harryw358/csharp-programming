using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CommaSeparatedValues
{
    class Program
    {
        static StreamWriter currentFileWriter;
        static void Main(string[] args)
        {
            currentFileWriter = new StreamWriter(@"school_record.txt", true);

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your street: ");
            string street = Console.ReadLine();
            Console.Write("Enter your town: ");
            string town = Console.ReadLine();

            string textString = name + "," + street + "," + town;
            currentFileWriter.WriteLine(textString);
            currentFileWriter.Close();
        }
    }
}
