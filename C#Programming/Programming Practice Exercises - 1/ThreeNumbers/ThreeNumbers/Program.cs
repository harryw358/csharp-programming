using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 real numbers.");
            Console.WriteLine();

            double num1, num2, num3, sum, product;
            Console.Write("Number 1: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Number 2: ");
            num2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Number 3: ");
            num3 = Convert.ToDouble(Console.ReadLine());

            sum = num1 + num2 + num3;
            product = num1 * num2 * num3;

            Console.WriteLine("The sum of " + num1 + ", " + num2 + " & " + num3 + " is: " + sum);
            Console.WriteLine("The product of " + num1 + ", " + num2 + " & " + num3 + " is: " + product);
            Console.ReadKey();
            
        }
    }
}
