using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTraversal
{
    internal class Program
    {
        private static Tree[] _tree;
        static void Main(string[] args)
        {
            // TREE REPRESENTATION
            _tree = new Tree[]
            {
                new Tree(1, '+', 2),
                new Tree(3, '*', 4),
                new Tree(5, '/', 6),
                new Tree(-1, 'a', -1),
                new Tree(-1, 'b', -1),
                new Tree(-1, 'c', -1),
                new Tree(-1, 'd', -1)
            };

            Console.Write("Pre-order traversal: ");
            PreOrderTraversal(0);
            Console.Write("\nPost-order traversal: ");
            PostOrderTraversal(0);
            Console.Write("\nIn-order traversal: ");
            InOrderTraversal(0);

            Console.ReadKey();
        }
        
        static void PreOrderTraversal(int p)
        {
            Console.Write(_tree[p].Data + " ");
            if (_tree[p].Left != -1)
            {
                PreOrderTraversal(_tree[p].Left);
            }
            if (_tree[p].Right != -1)
            {
                PreOrderTraversal(_tree[p].Right);
            }
        }

        static void PostOrderTraversal(int p)
        {
            if (_tree[p].Left != -1)
            {
                PostOrderTraversal(_tree[p].Left);
            }
            if (_tree[p].Right != -1)
            {
                PostOrderTraversal(_tree[p].Right);
            }
            Console.Write(_tree[p].Data + " ");
        }

        static void InOrderTraversal(int p)
        {
            if (_tree[p].Left != -1)
            {
                InOrderTraversal(_tree[p].Left);
            }
            Console.Write(_tree[p].Data + " ");
            if (_tree[p].Right != -1)
            {
                InOrderTraversal(_tree[p].Right);
            }
        }
    }
}
