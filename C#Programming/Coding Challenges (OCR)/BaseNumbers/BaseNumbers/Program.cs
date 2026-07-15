using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a denary number: ");
            int denary = int.Parse(Console.ReadLine());
            Console.Write("What base do you want to convert it to? ");
            int baseNum = int.Parse(Console.ReadLine());

            switch (baseNum.ToString())
            {
                case "2": //binary
                    int denaryValue = denary;
                    string binaryString = "";
                    while(denaryValue > 0)
                    {
                        binaryString = Convert.ToString(denaryValue % 2) + binaryString;
                        denaryValue = denaryValue / 2;
                    }
                    Console.WriteLine(denary + " = " + binaryString);
                    break;
                case "16": //hex
                    Console.WriteLine(denary + " = " + denary.ToString("X"));
                    break;
                default:
                    Console.WriteLine("This program only supports base 2 and base 16.");
                    break;
            }
            Console.ReadKey();
        }
    }
}
