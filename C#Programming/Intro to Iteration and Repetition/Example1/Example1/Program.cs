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
            //difference between DO & WHILE loops

            /*
            string name;
            int count = 0;

            do
            {
                Console.Write("Enter a name, X to finish: ");
                name = Console.ReadLine();
                count = count + 1;
                Console.WriteLine(count + " " + name);
            }
            while (name != "X");
            {
                Console.WriteLine("Number of names entered = " + (count - 1));
                Console.ReadKey();
            }
            */

            string name;
            int count = 0;

            Console.Write("Enter a name, X to finish: ");
            name = Console.ReadLine();

            while (name != "X")
            {
                count = count + 1;
                Console.WriteLine(count + " " + name);
                Console.Write("Enter a name, X to finish: ");
                name = Console.ReadLine();
            }
            Console.WriteLine("Number of names entered = " + count);
            Console.ReadKey();
        }
    }
}
