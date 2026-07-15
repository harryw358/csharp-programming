using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game_UltimateNIM
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerScore = 0, computerScore = 0;
            DateTime date = DateTime.Today;
            string filepath = "@Scores_UltimateNIM.txt";
            int option = Menu();

            while (option != 4)
            {
                if (option == 1)
                {
                    DisplayRules();
                }
                else if (option == 2)
                {
                    string playAgain = " ";
                    do
                    {
                        int removeCounters = 0, stackChoice = 0, numOfCounters = 0;
                        int[] stacks = new int[6];
                        stacks = InitializeStacks(stacks);
                        numOfCounters = NumberOfCounters(stacks, numOfCounters);
                        DisplayStacks(stacks);
                        bool move = true;

                        while (numOfCounters > 1)
                        {
                            if (move == true)
                            {
                                Console.WriteLine();
                                stacks = PlayerMove(stackChoice, removeCounters, stacks, numOfCounters);
                                DisplayStacks(stacks);
                                numOfCounters = 0;
                                numOfCounters = NumberOfCounters(stacks, numOfCounters);
                                if (numOfCounters == 1)
                                {
                                    Console.WriteLine("Player wins!");
                                    playerScore++;
                                }
                                else if (numOfCounters == 0)
                                {
                                    Console.WriteLine("Computer wins!");
                                    computerScore++;
                                }
                                move = false;
                            }
                            else if (move == false)
                            {
                                Console.WriteLine();
                                stacks = ComputerMove(stackChoice, removeCounters, stacks, numOfCounters);
                                DisplayStacks(stacks);
                                numOfCounters = 0;
                                numOfCounters = NumberOfCounters(stacks, numOfCounters);
                                if (numOfCounters == 1)
                                {
                                    Console.WriteLine("Computer wins!");
                                    computerScore++;
                                }
                                else if (numOfCounters == 0)
                                {
                                    Console.WriteLine("Player wins!");
                                    playerScore++;
                                }
                                move = true;
                            }
                        }
                        Console.Write("Do you want to play again? Y/N  ");
                        playAgain = Console.ReadLine();
                    }
                    while (playAgain.ToUpper() == "Y");
                }
                else if (option == 3)
                {
                    Console.WriteLine();
                    readScore(filepath);
                    Console.ReadKey();
                }
                option = Menu();
            }
            if (computerScore > 0 || playerScore > 0)
            {
                addScore(playerScore, computerScore, date, filepath);
            }
        }
        static int Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ultimate NIM Menu\nOption 1: Rules\nOption 2: New game\nOption 3: Scores\nOption 4: Quit");
            int num = 0;
            do
            {
                Console.Write("\nChoose an option: ");
                try
                {
                    num = int.Parse(Console.ReadLine());
                    if (num < 1 || num > 4)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Please choose a valid option.");
                }
            }
            while (num < 1 || num > 4);
            return num;
        }
        static void DisplayRules()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You are up against the computer. You can remove any amount of counters\nat a time. The last player who is forced to remove the last counter loses the game.\nGood luck!\n\nPress enter to return back to the menu. . .");
            Console.ReadKey();
        }
        static int[] InitializeStacks(int[] stacks)
        {
            Random rnd = new Random();
            for (int i = 1; i < 6; i++)
            {
                stacks[i] = rnd.Next(1, 21);
            }
            return stacks;
        }
        static int NumberOfCounters(int[] stacks, int numOfCounters)
        {
            for (int i = 1; i < 6; i++)
            {
                numOfCounters += stacks[i];
            }
            return numOfCounters;
        }
        static void DisplayStacks(int[] stacks)
        {
            Console.Clear();
            for (int i = 1; i < 6; i++)
            {
                Console.Write(i + ". ");
                for (int j = 0; j < stacks[i]; j++)
                {
                    if (stacks[i] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("█ ");
                    }
                }
                Console.Write(stacks[i]);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static int[] PlayerMove(int stackChoice, int removeCounters, int[] stacks, int numOfCounters)
        {
            do
            {
                Console.Write("Which stack do you want to remove counters from? ");
                try
                {
                    stackChoice = int.Parse(Console.ReadLine());
                    if (stackChoice < 1 || stackChoice > 5)
                    {
                        throw new Exception();
                    }
                    if (stacks[stackChoice] == 0)
                    {
                        Console.WriteLine("There aren't any counters left on that stack, please choose another.");
                        Console.ReadKey();
                        Console.Clear();
                        DisplayStacks(stacks);
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a whole number 1-5.");
                    Console.ReadKey();
                    Console.Clear();
                    DisplayStacks(stacks);
                    Console.WriteLine();
                }
            }
            while (stackChoice < 1 || stackChoice > 5 || stacks[stackChoice] == 0);
            Console.WriteLine("There are " + stacks[stackChoice] + " counters on that stack.");
            do
            {
                Console.Write("How many counters do you want to remove from stack " + stackChoice + " ? ");
                try
                {
                    removeCounters = int.Parse(Console.ReadLine());
                    if (removeCounters < 1 || removeCounters > stacks[stackChoice])
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("There are only " + stacks[stackChoice] + " left, please enter a valid number.");
                    Console.ReadKey();
                    Console.Clear();
                    DisplayStacks(stacks);
                    Console.WriteLine();
                }
            }
            while (removeCounters < 1 || removeCounters > stacks[stackChoice]);
            stacks[stackChoice] -= removeCounters;
            stackChoice = 1;
            removeCounters = 0;
            return stacks;
        }
        static int[] ComputerMove(int stackChoice, int removeCounters, int[] stacks, int numOfCounters)
        {
            Random rnd = new Random();
            do
            {
                stackChoice = rnd.Next(1, 6);
                removeCounters = rnd.Next(1, stacks[stackChoice] + 1);
            }
            while (stacks[stackChoice] == 0 || removeCounters > stacks[stackChoice]);
            Console.WriteLine("Computer has chosen to remove " + removeCounters + " counters from stack " + stackChoice + "\nPress enter to continue . . .");
            Console.ReadKey();
            stacks[stackChoice] -= removeCounters;
            stackChoice = 1;
            removeCounters = 0;
            return stacks;
        }
        public static void addScore(int playerScore, int computerScore, DateTime date, string filepath)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filepath, true))
                {
                    file.WriteLine(date.ToString("d"));
                    file.WriteLine("Player: " + playerScore);
                    file.WriteLine("Computer: " + computerScore);
                    file.WriteLine();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("That didn't work! :", ex);
            }
        }
        public static void readScore(string filepath)
        {
            Console.Clear();
            Console.WriteLine("Ultimate NIM Scores:\n");
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("That didn't work! :", ex);
            }
            Console.WriteLine("\nPress enter to return back to the menu. . .");
        }
    }
}
