using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    internal class Program
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

            var q = new Queue<int>();
            q.Enqueue(0);

            int nextNode;

            for (int i = 0; i < v.Length; i++)
            {
                v[i] = false;
            }

            v[0] = true;

            while (q.Count != 0)
            {
                nextNode = q.Dequeue();
                Console.WriteLine((char)('A' + nextNode));

                for (int x = 0; x < v.Length; x++)
                {
                    if (c[nextNode, x] == 1 && !v[x])
                    {
                        v[x] = true;
                        q.Enqueue(x);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
