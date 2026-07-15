using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEntered, num;

            Console.Write("Enter an integer: ");
            numEntered = int.Parse(Console.ReadLine());

            while (numEntered != 0)
            {
                num = numEntered;
                Console.WriteLine(numEntered + " squared = " + (num * num));
                Console.WriteLine(numEntered + " cubed = " + (num * num * num));

                Console.Write("Enter another integer: ");
                numEntered = int.Parse(Console.ReadLine());
            }
            Console.ReadKey();

        }
    }
}
