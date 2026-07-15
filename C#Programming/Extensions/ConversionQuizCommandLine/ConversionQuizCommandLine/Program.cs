using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionQuizCommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number Conversion Practice.");
            Console.WriteLine();

            //makes a random denary value
            Random denary = new Random();
            //initialises score
            int score = 0;

            //QUESTION 1 DENARY > BINARY
            int denaryQuestion = denary.Next(256), denaryValue = denaryQuestion;
            string binaryString = "";
            while(denaryValue > 0)
            {
                binaryString = Convert.ToString(denaryValue % 2) + binaryString;
                denaryValue = denaryValue / 2;
            }
            Console.Write("Convert " + denaryQuestion + " (denary) to binary: ");
            string binaryAnswer = Console.ReadLine();
            if(binaryAnswer == binaryString)
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            //QUESTION 2 BINARY > DENARY
            denaryQuestion = denary.Next(256);
            denaryValue = denaryQuestion;
            binaryString = "";
            while(denaryValue > 0)
            {
                binaryString = Convert.ToString(denaryValue % 2) + binaryString;
                denaryValue = denaryValue / 2;
            }
            Console.Write("Convert " + binaryString + " (binary) to denary: ");
            int denaryAnswer;
            try
            {
                denaryAnswer = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Write("Please enter a whole number: ");
                denaryAnswer = int.Parse(Console.ReadLine());
            }
            if(denaryAnswer == denaryQuestion)
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            //QUESTION 3 BINARY > HEX
            denaryQuestion = denary.Next(256);
            denaryValue = denaryQuestion;
            binaryString = "";
            while(denaryValue > 0)
            {
                binaryString = Convert.ToString(denaryValue % 2) + binaryString;
                denaryValue = denaryValue / 2;
            }
            Console.Write("Convert " + binaryString + " (binary) to Hex: ");
            string hexAnswer = Console.ReadLine();
            if(hexAnswer == denaryQuestion.ToString("X"))
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            //QUESTION 4 HEX > BINARY
            denaryQuestion = denary.Next(256);
            denaryValue = denaryQuestion;
            binaryString = "";
            while (denaryValue > 0)
            {
                binaryString = Convert.ToString(denaryValue % 2) + binaryString;
                denaryValue = denaryValue / 2;
            }
            Console.Write("Convert " + denaryQuestion.ToString("X") + " (Hex) to binary: ");
            binaryAnswer = Console.ReadLine();
            if (binaryAnswer == binaryString)
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            //QUESTION 5 HEX > DENARY
            denaryQuestion = denary.Next(256);
            Console.Write("Convert " + denaryQuestion.ToString("X") + " (Hex) to denary: ");
            try
            {
                denaryAnswer = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Write("Please enter a whole number: ");
                denaryAnswer = int.Parse(Console.ReadLine());
            }
            if(denaryAnswer == denaryQuestion)
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            //QUESTION 6 DENARY > HEX
            denaryQuestion = denary.Next(256);
            Console.Write("Convert " + denaryQuestion + " (denary) to Hex: ");
            hexAnswer = Console.ReadLine();
            if (hexAnswer == denaryQuestion.ToString("X"))
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            Console.WriteLine("Your score is: " + score + "/6");
            Console.ReadKey();
        }
    }
}
