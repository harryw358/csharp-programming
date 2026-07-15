using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            //basic calculator using switchcase
            double num1, num2; ;
            char chosenOperator;

            Console.WriteLine("Enter a number: ");
            num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter another number: ");
            num2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter an operator: ");
            chosenOperator = char.Parse(Console.ReadLine());

            switch (chosenOperator)
            {
                case '+':
                    Console.WriteLine(num1 + " + " + num2 + " = " + (num1 + num2));
                 break;
                case '-':
                    Console.WriteLine(num1 + " - " + num2 + " = " + (num1 - num2) + " or " + num2 + " - " + num1 + " = " + (num2 - num1));
                    break;
                case '*':
                    Console.WriteLine(num1 + " x " + num2 + " = " + (num1 * num2));
                    break;
                case '/':
                    Console.WriteLine(num1 + " / " + num2 + " = " + (num1 / num2) + " or " + num2 + " / " + num1 + " = " + (num2 / num1));
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    break;
            }
            Console.ReadKey();
            //menu
            Console.WriteLine("What would you like to eat? We have a limited menu of burgers, fries, sandwiches and pizza.");
            string item = Console.ReadLine();
            switch (item.ToLower())
            {
                case "burger":
                    Console.WriteLine("That will be £1.30");
                    break;
                case "fries":
                    Console.WriteLine("That will be 75p.");
                    break;
                case "sandwich":
                    Console.WriteLine("That will be £2");
                    break;
                case "pizza":
                    Console.WriteLine("That will be £1.50");
                    break;
                default:
                    Console.WriteLine("Did you not read the menu? We don't have that here.");
                    break;
            }
            Console.WriteLine("Cash or card?");
            string paymentType = Console.ReadLine();
            switch (paymentType.ToLower())
            {
                case "cash":
                    Console.WriteLine("Sorry, we aren't taking change, we don't want coronavirus.");
                    break;
                case "card":
                    Console.WriteLine("Please enter your pin: ");
                    int pin = int.Parse(Console.ReadLine());
                    Console.WriteLine("Thank you, see you next time!");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.ReadLine();
            
            
            

            
        }
    }
}
