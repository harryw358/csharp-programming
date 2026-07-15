using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue circularQueue = new Queue();
            int menuChoice = 0;
            do
            {
                menuChoice = GetMenuChoice();
                switch (menuChoice)
                {
                    case 1:
                        {
                            circularQueue.DisplayQueue();
                            Console.WriteLine();
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        {
                            Console.Write("New item: ");
                            int newItem = int.Parse(Console.ReadLine());
                            if (!circularQueue.IsFull())
                            {
                                circularQueue.Enqueue(newItem);
                            }
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        {
                            circularQueue.Dequeue();
                            Console.ReadKey();
                        }
                        break;
                }
            }
            while (menuChoice == 1 || menuChoice == 2 || menuChoice == 3);
        }
        private static int GetMenuChoice()
        {
            Console.WriteLine("1. Display queue\n2. Add to queue\n3. Remove from queue\n4. Exit");
            Console.Write("\nYour choice: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
