using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1ExamGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int score;
            char grade;

            Console.Write("Enter the test score out of 100: ");
            try
            {
                score = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid entry");
                score = int.Parse(Console.ReadLine());
            }

            if ((score >= 0) && (score < 40))
            {
                grade = 'U';
            }
            else if ((score > 40) && (score <= 49))
            {
                grade = 'E';
            }
            else if ((score > 50) && (score <= 59))
            {
                grade = 'D';
            }
            else if ((score > 60) && (score <= 69))
            {
                grade = 'C';
            }
            else if ((score > 70) && (score <= 79))
            {
                grade = 'B';
            }
            else if ((score > 80) && (score <= 100))
            {
                grade = 'A';
            }
            else if  ((score < 0) || (score > 100))
            {
                grade = '@';
            }
            else
            {
                grade = ':';
            }

            switch (grade)
            {
                case 'A':
                    Console.WriteLine("You got an A! That's amazing!");
                    break;
                case 'B':
                    Console.WriteLine("You got a B! That's good!");
                    break;
                case 'C':
                    Console.WriteLine("You got a C. That's a good effort!");
                    break;
                case 'D':
                    Console.WriteLine("You got a D. Try harder next time.");
                    break;
                case 'E':
                    Console.WriteLine("That's awful, you failed the test!");
                    break;
                case 'U':
                    Console.WriteLine("A U is terrible, you failed the test!!!");
                    break;
                case '@':
                    Console.WriteLine("That score is invalid.");
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}
