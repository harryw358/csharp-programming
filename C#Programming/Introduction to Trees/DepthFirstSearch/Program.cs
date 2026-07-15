using System;

namespace DepthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] v = new bool[7]; // visited

            int[,] c = new int[7, 7]
            {
                 { 0, 1, 0, 1, 1, 0, 0 },
                 { 1, 0, 1, 1, 0, 0, 0 },
                 { 0, 1, 0, 0, 0, 0, 1 },
                 { 1, 1, 0, 0, 1, 1, 0 },
                 { 1, 0, 0, 1, 0, 0, 0 },
                 { 0, 0, 0, 1, 0, 0, 0 },
                 { 0, 0, 1, 0, 0, 0, 0 }
            }; // adjacency matrix

            var s = new Stack(7);

            int nextNode;

            for (int i = 0; i < v.Length; i++)
            {
                v[i] = false;
            }

            s.Push(0);

            while(s.Size != 0)
            {
                nextNode = s.Pop();
                if (!v[nextNode])
                {
                    v[nextNode] = true;
                    Console.WriteLine("Next node is: " + nextNode);

                    for (int x = 6; x >= 1; x--)
                    {
                        if (c[nextNode, x] > 0 && !v[x])
                        {
                            s.Push(x);
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}

