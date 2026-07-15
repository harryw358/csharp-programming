using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubroutinesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = menuChoice();
            while(option != 3)
            {
                if(option == 1)
                {
                    displayRules();
                }
                else
                {
                    playGame();
                }
                option = menuChoice();
            }
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }
        static int menuChoice()
        {
            Console.WriteLine("Option 1: Display rules\nOption 2: Start new game\nOption 3: Quit");
            int choice = 0;
            do
            {
                Console.Write("What would you like to do? ");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice < 1 || choice > 3)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("That is not a valid choice\nPlease enter a number between 1 and 3.");
                }
            }
            while (choice < 1);
            return choice;
        }
        static void displayRules()
        {
            Console.WriteLine("The rules of the game are as follows:\n");
        }
        static void playGame()
        {
            int score01 = 0, score02 = 0, totalScore;
            Console.Write("Player 1's name: ");
            string player01 = Console.ReadLine();
            Console.Write("Player 2's name: ");
            string player02 = Console.ReadLine();
            while(score01 < 25 && score02 < 25)
            {
                totalScore = playerTurn(player01, score01);
                score01 = totalScore;
                if(score01 >= 25)
                {
                    Console.WriteLine("You win!");
                }
                else
                {
                    totalScore = playerTurn(player02, score02);
                    score02 = totalScore;
                    if(score02 >= 25)
                    {
                        Console.WriteLine("You win!");
                    }
                }
            }
        }
        static int playerTurn(string player, int score)
        {
            Random rnd = new Random();
            int die01, die02, cumulativeScore = 0;
            Console.WriteLine("Your turn " + player);
            string anotherGo = "Y";
            int scoreThisTurn = 0;
            while(anotherGo == "Y" || anotherGo == "y")
            {
                die01 = rnd.Next(1, 7);
                die02 = rnd.Next(1, 7);
                Console.WriteLine("You rolled " + die01 + " and a " + die02);
                if(die01 == die02)
                {
                    scoreThisTurn = 0;
                    cumulativeScore = 0;
                    Console.WriteLine("Bad luck! Press any key to continue. . .");
                    Console.ReadKey();
                    anotherGo = "N";
                }
                else
                {
                    scoreThisTurn = scoreThisTurn + die01 + die02;
                    cumulativeScore = score + scoreThisTurn;
                    Console.WriteLine("Your score this turn is: " + scoreThisTurn);
                    Console.WriteLine(player + ", your cumulative score is " + cumulativeScore);
                    if(cumulativeScore >= 25)
                    {
                        anotherGo = "N";
                    }
                    else
                    {
                        Console.Write("Another go? (Answer Y or N) ");
                        anotherGo = Console.ReadLine();
                    }
                }
            }
            return cumulativeScore;
        }
    }
}
