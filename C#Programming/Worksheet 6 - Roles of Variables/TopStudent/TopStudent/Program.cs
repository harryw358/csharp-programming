using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, highestMarkStudentName = "";
            int mark, studentCount = 1, highestMark = 0;

            do
            {
                Console.Write("Enter the name of student " + studentCount + ": ");
                name = Console.ReadLine();
                studentCount++;
                Console.Write("Enter this student's mark: ");
                mark = int.Parse(Console.ReadLine());
                if (mark > highestMark)
                {
                    highestMark = mark;
                    highestMarkStudentName = name;
                }
            }
            while (studentCount <= 5);
            Console.WriteLine(highestMarkStudentName + " scored the highest mark with " + highestMark);
         
            Console.ReadKey();
        }
    }
}
