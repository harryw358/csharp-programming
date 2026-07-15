using System;

namespace PyramindCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = GetN();
            Console.WriteLine(PyramidCount(n));

            Console.ReadLine();
        }

        static int GetN()
        {
            int n = 0;
            do
            {
                try
                {
                    Console.Write("Enter a number: ");
                    n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a number greater than 0.");
                }
            }
            while (n <= 0);

            return n;
        }

        static int PyramidCount(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                int num = 0;
                for (int i = 0; i < n; i++)
                {
                    num = n + PyramidCount(n - 1);
                }

                return num;
            }
        }
    }
}

