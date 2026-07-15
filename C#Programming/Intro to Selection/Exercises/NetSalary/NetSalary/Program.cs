using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry Wray - Output net salary after tax

            string name;
            double grossSalary, taxPaid, netSalary;

            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter your gross salary: ");
            grossSalary = double.Parse(Console.ReadLine());

            if ((grossSalary >= 0000) && (grossSalary <= 10000))
            {
                taxPaid = 0;
            }
            else if ((grossSalary >= 10001) && (grossSalary <= 20000))
            {
                taxPaid = grossSalary * 0.2;
            }
            else if ((grossSalary >= 20001) && (grossSalary <= 40000))
            {
                taxPaid = grossSalary * 0.25;
            }
            else if (grossSalary >= 40001)
            {
                taxPaid = grossSalary * 0.4;
            }
            else
            {
                taxPaid = 0;
            }

            netSalary = grossSalary - taxPaid;

            Console.WriteLine(name);
            Console.WriteLine("Your gross salary is " + grossSalary.ToString("C"));
            Console.WriteLine("You have paid " + taxPaid.ToString("C") + " tax");
            Console.WriteLine("Your net salary is " + netSalary.ToString("C"));
            
            Console.ReadKey();
        }
    }
}
