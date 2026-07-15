using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintArrayElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 0;
            do
            {
                Console.Write("Enter size of array up to 10: ");
                try
                {
                    arraySize = int.Parse(Console.ReadLine());
                    if(((arraySize < 1) || (arraySize > 10)))
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a whole number up to 10.");
                }
            }
            while ((arraySize < 1) || (arraySize > 10));
            Console.WriteLine("\nEnter " + arraySize + " numbers.");
            int[] arr = new int[arraySize];
            for(int count = 0; count < arraySize; count++)
            {
                Console.Write("Number " + (count + 1) + ": ");
                arr[count] = int.Parse(Console.ReadLine());
            }
            Console.Write("\nThe numbers in the array are: ");
            for (int count = 0; count < arraySize; count++)
            {
                Console.Write(arr[count] + " ");
            }
            Console.ReadKey();
        }
    }
}
