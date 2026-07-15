using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            string test;
            int done;
            Console.Write("Enter a number - not really ");
            test = Console.ReadLine();

            try
            {
                done = int.Parse(test);
            }
            catch
            {
                Console.WriteLine("that was not an integer");
            }
            Console.ReadLine();
        }
    }
}
