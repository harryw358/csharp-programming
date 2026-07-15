using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structTStudent
{
    class Program
    {
        struct TStudent
        {
            public string name;
            public int marks;
        }
        static void Main(string[] args)
        {
            TStudent[] student = new TStudent[4];
            student[0].name = "Fred";
            student[0].marks = 35;
            student[1].name = "Jim";
            student[1].marks = 52;

            for(int index = 0; index < 2; index++)
            {
                Console.Write(student[index].name);
                Console.Write(" ");
                Console.WriteLine(student[index].marks);
            }
            Console.ReadKey();
        }
    }
}
