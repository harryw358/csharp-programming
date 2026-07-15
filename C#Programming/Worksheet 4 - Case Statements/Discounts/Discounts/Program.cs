using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discounts
{
    class Program
    {
        static void Main(string[] args)
        {
            double orderValue, discountedValue;

            Console.WriteLine("Discounted Orders");
            Console.Write("Enter the value of the order: ");
            orderValue = double.Parse(Console.ReadLine());

            if ((orderValue > 0) && (orderValue <= 1000))
            {
                discountedValue = orderValue;
            }
            else if ((orderValue > 1000) && (orderValue <= 2500))
            {
                discountedValue = orderValue * 0.95;
            }
            else if ((orderValue > 2500) && (orderValue <= 5000))
            {
                discountedValue = orderValue * 0.9;
            }
            else if ((orderValue > 5000) && (orderValue <= 10000))
            {
                discountedValue = orderValue * 0.85;
            }
            else if ((orderValue > 10000) && (orderValue < 25000))
            {
                discountedValue = orderValue * 0.8;
            }
            else if (orderValue > 25000)
            {
                Console.WriteLine("Order value too high, sorry.");
                discountedValue = orderValue;
            }
            else
            {
                discountedValue = orderValue;
            }

            Console.WriteLine("The discounted price is " + discountedValue.ToString("C"));
            Console.ReadKey();
            

        }
    }
}
