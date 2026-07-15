using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIISecret
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;
            string message = "";
            Console.Write("Enter an ASCII code: ");
            int asciiCode = int.Parse(Console.ReadLine());
            while(asciiCode >= 32)
            {
                character = (char)asciiCode;
                message = message + "" + character;
                Console.Write("Enter an ASCII code: ");
                asciiCode = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
