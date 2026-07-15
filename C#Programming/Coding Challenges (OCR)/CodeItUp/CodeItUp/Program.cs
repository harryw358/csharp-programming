using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeItUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            foreach (char c in str)
            {
                int num = (int)c;
                num = num + 25;
                Console.Write((char)num);
            }
            Console.ReadKey();
        }
    }
}
