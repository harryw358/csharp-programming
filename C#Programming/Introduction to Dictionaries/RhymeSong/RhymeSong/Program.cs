using System.ComponentModel;
using System.Net.Sockets;

namespace RhymeSong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var message = new Dictionary<int, string>()
            {
                { 1, "Hickory" },
                { 2, "Dickory" },
                { 3, "Dock" },
                { 4, "The" },
                { 5, "Mouse" },
                { 6, "Ran" },
                { 7, "Up" },
                { 8, "Clock" },
                { 9, "Struck" },
                { 10, "One" },
                { 11, "And" },
                { 12, "Down" },
                { 13, "he" },
                { 14, "ran" }
             };

            // manual
            Console.WriteLine("Manual");

            PrintValueAtKey(message, 1);
            PrintValueAtKey(message, 2);
            PrintValueAtKey(message, 3);
            PrintValueAtKey(message, 4);
            PrintValueAtKey(message, 5);
            PrintValueAtKey(message, 6);
            PrintValueAtKey(message, 7);
            PrintValueAtKey(message, 4);
            PrintValueAtKey(message, 8);
            PrintValueAtKey(message, 4);
            PrintValueAtKey(message, 8);
            PrintValueAtKey(message, 9);
            PrintValueAtKey(message, 10);
            PrintValueAtKey(message, 11);
            PrintValueAtKey(message, 12);
            PrintValueAtKey(message, 13);
            PrintValueAtKey(message, 14);
            PrintValueAtKey(message, 1);
            PrintValueAtKey(message, 2);
            PrintValueAtKey(message, 3);

            Console.WriteLine();

            // using int array for numbers
            Console.WriteLine("Using int array for numbers");

            var numbers = new int[20] { 1, 2, 3, 4, 5, 6, 7, 4, 8, 4, 8, 9, 10, 11, 12, 13, 14, 1, 2, 3 };

            foreach(int n in numbers)
            {
                Console.WriteLine(message[n]);
            }

            Console.ReadKey();
        }

        static void PrintValueAtKey(Dictionary<int, string> dictionary, int key)
        {
            Console.WriteLine(dictionary[key]);
        }
    }
}