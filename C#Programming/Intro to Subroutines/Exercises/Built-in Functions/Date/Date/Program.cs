using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter todays date: ");
            string str = Console.ReadLine();

            DateTime date = Convert.ToDateTime(str);
            date = date.AddDays(1);

            Console.WriteLine("Tomorrows date is: " + date.ToString("d"));
            Console.ReadKey();
        }
    }
}
