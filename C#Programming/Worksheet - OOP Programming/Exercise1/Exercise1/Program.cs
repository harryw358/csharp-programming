using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter student ID: ");
            string studentID = Console.ReadLine();
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter tutor: ");
            string tutor = Console.ReadLine();
            Console.Write("Enter year group: ");
            int yearGroup = int.Parse(Console.ReadLine());


            // Instantiates a new student using local variables above
            Student student01 = new Student(studentID, name, address, tutor, yearGroup);

            Console.WriteLine("\nThis is the information about that student:\n");

            // Method 1 - Calls procedure that uses 
            // private attributes WITHIN class

            student01.ShowInformation();

            Console.ReadKey();

            // Method 2 - Uses public attributes

            Console.WriteLine("\n\nThis is the information about that student:\n");
            Console.WriteLine("Student ID: " + student01.StudentID);
            Console.WriteLine("Name: " + student01.Name);
            Console.WriteLine("Address: " + student01.Address);
            Console.WriteLine("Tutor: " + student01.Tutor);
            Console.WriteLine("Year group: " + student01.YearGroup);

            Console.ReadKey();
        }
    }
}
