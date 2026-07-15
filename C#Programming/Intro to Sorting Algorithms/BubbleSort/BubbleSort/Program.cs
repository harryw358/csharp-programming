using System.Runtime.ExceptionServices;

namespace BubbleSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] items = new int[5] { 13, 16, 10, 11, 4 };
            Console.Write("Unsorted items: ");
            PrintItems(items);
            Console.WriteLine();
            Console.WriteLine();

            bool sorted = false;

            while (!sorted)
            {
                sorted = true;
                for (int j = 0; j < items.Length - 1; j++)
                {
                    if (items[j] > items[j + 1])
                    {
                        int temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        sorted = false;
                        PrintItems(items);
                        Console.WriteLine();
                    }
                }
            }

            Console.Write("\nSorted items: ");
            PrintItems(items);
            Console.WriteLine();
            Console.ReadKey();
        }

        static void PrintItems(int[] items)
        {
            foreach (int item in items)
            {
                Console.Write(item + " ");
            }
        }
    }
}