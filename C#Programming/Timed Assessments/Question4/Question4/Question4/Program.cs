using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The first few prime numbers are: ");
            for(int count1 = 2; count1 <= 50; count1++)
            {
                int count2 = 2;
                string prime = "Yes";
                while(count2 * count2 <= count1)
                {
                    if(count1 % count2 == 0)
                    {
                        prime = "No";
                    }
                    count2 = count2 + 1;
                }
                if(prime == "Yes")
                {
                    Console.WriteLine(count1);
                }
            }
            Console.ReadKey();
        }
    }
}
