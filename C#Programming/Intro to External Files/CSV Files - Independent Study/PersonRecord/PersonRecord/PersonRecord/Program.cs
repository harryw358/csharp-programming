using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PersonRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] record = EnterRecord();
            foreach(string str in record)
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }
        static string[] EnterRecord()
        {
            string[] record = new string[4];

            Console.Write("Name: "); record[0] = Console.ReadLine();
            Console.Write("Age: "); record[1] = Console.ReadLine();
            Console.Write("Street: "); record[2] = Console.ReadLine();
            Console.Write("Town: "); record[3] = Console.ReadLine();

            return record;
        }
    }
}
