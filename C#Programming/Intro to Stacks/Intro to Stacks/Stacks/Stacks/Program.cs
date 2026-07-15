using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            Console.Write("1. Display stack\n2. Push\n3. Pop\n4. Peek\n5. Exit\n\nYour choice: ");
            int menuChoice = int.Parse(Console.ReadLine());
            do
            {
                switch (menuChoice)
                {
                    case 1:
                        stack.Display();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("New item: ");
                        int newItem = int.Parse(Console.ReadLine());
                        stack.Push(newItem);
                        break;
                    case 3:
                        int poppedItem = stack.Pop();
                        Console.WriteLine("Popped: " + poppedItem);
                        break;
                    case 4:
                        stack.Peek();
                        break;
                }
                Console.Write("\n\n1. Display stack\n2. Push\n3. Pop\n4. Peek\n5. Exit\n\nYour choice: ");
                menuChoice = int.Parse(Console.ReadLine());
            }
            while (menuChoice < 3 || menuChoice > 1);
        }
    }
}
