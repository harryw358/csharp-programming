using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallByRef
{
    class Program
    {
        static void Main(string[] args)
        {
            int num01 = 5, num02 = 7;
            Console.WriteLine("Original numbers");
            Console.WriteLine(" First: {0}, Second: {1}", num01, num02);
            Console.WriteLine();
            Console.WriteLine("This will not swap globally.");

            Console.WriteLine();
            noSwap(num01, num02);
            Console.WriteLine("Global variables are: ");
            Console.WriteLine(" First: {0}, Second: {1}", num01, num02);
            Console.WriteLine();
            Console.WriteLine("This will swap globally");
            Console.WriteLine();

            swap(ref num01, ref num02);
            Console.WriteLine("Global variables are: ");
            Console.WriteLine(" First: {0}, Second: {1}", num01, num02);

            Console.ReadKey();
        }
        static void noSwap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("Inside the procedure");
            Console.WriteLine(" First: {0}, Second: {1}", a, b);
        }
        static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("Inside the procedure");
            Console.WriteLine(" First: {0}, Second: {1}", a, b);
        }
    }
}
