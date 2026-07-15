using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionProgrammingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, answer;
            char yesOrNo;

            Console.WriteLine("Hello Student!");
            Console.Write("What is your name? ");
            name = Console.ReadLine();

            Console.Write("Hello " + name + " do you like Computing? Y/N ");
            yesOrNo = char.Parse(Console.ReadLine());
            
            if ((yesOrNo == 'y') || (yesOrNo == 'Y'))
            {
                Console.WriteLine("Of course you do!");
                Console.WriteLine("Please tell me what you like about Computing?");
                answer = Console.ReadLine();
                Console.WriteLine(name + " said: " + answer);
                Console.WriteLine("Goodbye " + name);
            }
            else if ((yesOrNo == 'n') || (yesOrNo == 'N'))
            {
                Console.WriteLine("Oh dear I am sad!");
                Console.WriteLine("Please tell me what you do not like about Computing?");
                answer = Console.ReadLine();    
                Console.WriteLine(name + " said " + answer);
                Console.WriteLine("Goodbye " + name);
            }
            else
            {
                Console.WriteLine("I said Y/N - can't you read?");
                Console.WriteLine("Goodbye " + name);
            }

            Console.ReadKey();
        }
    }
}
