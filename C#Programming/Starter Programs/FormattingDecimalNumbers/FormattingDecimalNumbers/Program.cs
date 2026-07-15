using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingDecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal d = 1234.5678m;
            Console.WriteLine("Before: {0}", d); // This would print the number 1234.5678
            d = decimal.Round(d, 2);
            Console.WriteLine("After: {0}", d); // This would print 1234.57
            Console.ReadKey();

            /* -- Rounding doubles (64 bit)
            double d = 1234.5678;
            Console.WriteLine("Before: {0}", d); // This would print the number 1234.5678
            d = Math.Round(d, 2);
            Console.WriteLine("After: {0}", d); // This would print 1234.57
            Console.ReadKey();
            */

            /* -- Rounding Floats (32 bit)
            float d = 1234.5678;
            Console.WriteLine("Before: {0}", d); // This would print the number 1234.5678
            d = (float(Math.Round(d, 2));
            Console.WriteLine("After: {0}", d); // This would print 1234.57
            Console.ReadKey();
            */
        }
    }
}
