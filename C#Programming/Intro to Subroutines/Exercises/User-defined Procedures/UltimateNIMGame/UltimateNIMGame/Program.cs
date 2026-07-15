using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateNIMGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = " ";
            do
            {
                Console.Clear();
                int numOfCounters = GenerateRandomNumberOfCounters(numOfCounters = 0);
                DisplayCounters(numOfCounters);

                int removeCounters = 0, playerScore = 0, computerScore = 0;
                bool move = true;

                while (numOfCounters > 1)
                {
                    if (move == true)
                    {
                        numOfCounters = PlayerMove(removeCounters, numOfCounters);
                        DisplayCounters(numOfCounters);
                        move = false;
                        if (numOfCounters == 1)
                        {
                            Console.WriteLine("\nPlayer wins!");
                            playerScore++;
                        }
                    }
                    else if (move == false)
                    {
                        numOfCounters = ComputerMove(removeCounters, numOfCounters);
                        DisplayCounters(numOfCounters);
                        move = true;
                        if (numOfCounters == 1)
                        {
                            Console.WriteLine("\nComputer wins!");
                            computerScore++;
                        }
                    }
                }
                Console.Write("\nDo you want to play again? (Y/N) ");
                choice = Console.ReadLine();
            }
            while (choice.ToUpper() == "Y");
            Console.ReadKey();
        }
        static int GenerateRandomNumberOfCounters(int numOfCounters)
        {
            Random rnd = new Random();
            return rnd.Next(1, 21);
        }
        static void DisplayCounters(int numOfCounters)
        {
            Console.WriteLine();
            for(int i = 1; i <= numOfCounters; i++)
            {
                Console.Write("* ");
            }
        }
        static int PlayerMove(int removeCounters, int numOfCounters)
        {
            do
            {
                Console.Write("\n\nHow many counters do you want to remove? ");
                try
                {
                    removeCounters = int.Parse(Console.ReadLine());
                    if (removeCounters < 1 || removeCounters > 3)
                    {
                        throw new Exception();
                    }
                    if(removeCounters >= numOfCounters)
                    {
                        Console.WriteLine("There's only " + numOfCounters + " left, you can't remove that many.");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a whole number, you can only remove up to 3 counters at a time.");
                    Console.ReadKey();
                    Console.Clear();
                    DisplayCounters(numOfCounters);
                }
            }
            while (removeCounters < 1 || removeCounters > 3 || removeCounters >= numOfCounters);
            Console.WriteLine("You have chosen to remove " + removeCounters + " counters.\n\nPress enter to continue . . .");
            Console.ReadKey();
            Console.Clear();
            numOfCounters = numOfCounters - removeCounters;
            return numOfCounters;
        }
        static int ComputerMove(int removeCounters, int numOfCounters)
        {
            Random rnd = new Random();
            int rndNum = 0;
            do
            {
                rndNum = rnd.Next(1, 4);
                if(rndNum >= numOfCounters)
                {
                    Console.WriteLine("\nOops! Computer has chosen a number too large.");
                    Console.ReadKey();
                }
            }
            while (rndNum >= numOfCounters);
            Console.WriteLine("\n\nComputer has chosen to remove " + rndNum + " counters.\n\nPress enter to continue . . .");
            Console.ReadKey();
            Console.Clear();
            numOfCounters -= rndNum;
            return numOfCounters;
        }
    }
}
