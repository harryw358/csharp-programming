using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenaryToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a denary number: ");
            int denaryValue;
            try
            {
                denaryValue = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a whole number.");
                Console.Write("Enter a denary number: ");
                denaryValue = int.Parse(Console.ReadLine());
            }
            string binaryString = "";
            while(denaryValue > 0)
            {
                binaryString = Convert.ToString(denaryValue % 2) + binaryString;
                denaryValue = denaryValue / 2;
            }
            Console.WriteLine("The binary equivalent is " + binaryString);
            Console.ReadKey();
        }
    }
}
