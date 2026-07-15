using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace BinaryVsLinearSearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] newList = new string[4945];
            string file = System.IO.File.ReadAllText(@"NamesList.txt");
            newList = file.Split("\r\n");

            Console.Write("Enter name: ");
            string itemSought = Console.ReadLine();

            bool found = false;
            var stopwatch = new Stopwatch();


            // linear search
            stopwatch.Start();
            for (int i = 0; i < 4945; i++)
            {
                if (newList[i] == itemSought)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                stopwatch.Stop();
                Console.WriteLine("Linear search: " + stopwatch.ElapsedTicks + " ticks");
            }

            // binary search
            stopwatch.Reset();
            stopwatch.Start();
            bool searchFailed = false;
            int mid, first = 0, last = 99;
            do
            {
                mid = (first + last) / 2;
                if (newList[mid] == itemSought)
                {
                    found = true;
                }
                else if (first >= last)
                {
                    searchFailed = true;
                }
                else if (string.Compare(newList[mid], itemSought) > 0)
                {
                    last = mid - 1;
                }
                else if (string.Compare(newList[mid], itemSought) < 0)
                {
                    first = mid + 1;
                }
            }
            while (!found || searchFailed);
            if (found)
            {
                stopwatch.Stop();
                Console.WriteLine("Binary search: " + stopwatch.ElapsedTicks + " ticks");
            }

            Console.ReadKey();
        }
    }
}