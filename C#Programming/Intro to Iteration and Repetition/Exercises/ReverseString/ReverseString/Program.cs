using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word or sentence: ");
            string str = Console.ReadLine();

            int stringLength = str.Length - 1, i = 0;

            while(i < stringLength)
            {
                stringLength = str.Length - 1;
                str = str.Insert(i, str.Substring(stringLength));

                stringLength = str.Length - 1;
                str = str.Remove(stringLength);

                i++;
            }
            Console.WriteLine("That reversed is: " + str);
            Console.ReadKey();


        }
    }
}
