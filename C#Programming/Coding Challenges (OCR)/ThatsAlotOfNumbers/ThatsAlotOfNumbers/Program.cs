using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatsAlotOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = "3710728753";
            int result = 0;
            foreach(char num in numbers)
            {
                result += int.Parse(num.ToString());
                
            }
            Console.Write(result);
            Console.ReadKey();
        }
    }
}
