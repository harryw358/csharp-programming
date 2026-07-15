using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramString3
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W*/
            /* using Concat function to join 2 strings */

            string start, end, concat;

            start = "This is a ";
            end = "concatenated string!";

            concat = string.Concat(start, end);
            Console.WriteLine(concat);

            Console.ReadKey();
        }
    }
}
