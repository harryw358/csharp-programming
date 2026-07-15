using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTest
{
    class Program
    {
      
        static void Main(string[] args)
        {
            //Q1
            Console.Write("2 + 3 = ");
            int answer1 = int.Parse(Console.ReadLine());
            if (answer1 == 5)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            //Q2
            Console.Write("16 + 4 = ");
            int answer2 = int.Parse(Console.ReadLine());
            if (answer2 == 20)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            //Q3
            Console.Write("5 - 2 = ");
            int answer3 = int.Parse(Console.ReadLine());
            if (answer3 == 3)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            //Q4
            Console.Write("34 - 15 = ");
            int answer4 = int.Parse(Console.ReadLine());
            if (answer4 == 19)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            //Q5
            Console.Write("4 x 5 = ");
            int answer5 = int.Parse(Console.ReadLine());
            if (answer5 == 20)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }//Q6
            Console.Write("23 x 6 = ");
            int answer6 = int.Parse(Console.ReadLine());
            if (answer6 == 138)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            //Q7
            Console.Write("25 / 5 = ");
            int answer7 = int.Parse(Console.ReadLine());
            if (answer7 == 5)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            //Q8
            Console.Write("50 - 32");
            int answer8 = int.Parse(Console.ReadLine());
            if (answer8 == 18)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            //Q9
            Console.Write("154 + 19 - 35 = ");
            int answer9 = int.Parse(Console.ReadLine());
            if (answer9 == 138)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            //Q10
            Console.Write("19 x 3 = ");
            int answer10 = int.Parse(Console.ReadLine());
            if (answer10 == 57)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }

            Console.ReadKey();
        }
    }
}
