using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] scores = new int[3, 5];
            double[] studentTotal = new double[5];
            int score = 0;
            double totalClassScore = 0;

            for (int student = 0; student < 5; student++)
            {
                Console.WriteLine("Student " + (student + 1));
                for (int assignment = 0; assignment < 3; assignment++)
                {
                    do
                    {
                        Console.Write("Assignment " + (assignment + 1) + " score out of 10: ");
                        try 
                        {
                            score = -1;
                            score = int.Parse(Console.ReadLine());
                            if ((score < 0) || (score > 10))
                            {
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please enter a whole number between 1 and 10.");
                        }
                    }
                    while ((score < 0) || (score > 10));

                    scores[assignment, student] = score;
                    studentTotal[student] += score;
                    totalClassScore += score;
                }
                Console.WriteLine("Student " + (student + 1) + " average score: " + Math.Round((studentTotal[student] / 3), 1));
                Console.WriteLine();
            }
            Console.WriteLine("\nThe class average was " + Math.Round((totalClassScore / 15), 1));
            Console.ReadKey();
        }
    }
}
