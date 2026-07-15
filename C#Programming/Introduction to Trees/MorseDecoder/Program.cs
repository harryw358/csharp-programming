using System;
using System.Xml.Linq;
using MorseDecoder.MorseCode;

namespace MorseDecoder
{
    class Program
    {
        private static TreeNode[] _tree;

        static void Main(string[] args)
        {
            _tree = new TreeNode[]
            {
                new TreeNode(' ', 1, 2),
                new TreeNode('E', 3, 4),
                new TreeNode('T', 5, 6),
                new TreeNode('I', 7, 8),
                new TreeNode('A', 9, 10),
                new TreeNode('N', 11, 12),
                new TreeNode('M', 13, 14),
                new TreeNode('S', 15, 16),
                new TreeNode('U', 17, 18),
                new TreeNode('R', 19, 20),
                new TreeNode('W', 21, 22),
                new TreeNode('D', 23, 24),
                new TreeNode('K', 25, 26),
                new TreeNode('G', 27, 28),
                new TreeNode('O', -1, -1),
                new TreeNode('H', -1, -1),
                new TreeNode('V', -1, -1),
                new TreeNode('F', -1, -1),
                new TreeNode('-', -1, -1),
                new TreeNode('L', -1, -1),
                new TreeNode('-', -1, -1),
                new TreeNode('P', -1, -1),
                new TreeNode('J', -1, -1),
                new TreeNode('B', -1, -1),
                new TreeNode('X', -1, -1),
                new TreeNode('C', -1, -1),
                new TreeNode('Y', -1, -1),
                new TreeNode('Z', -1, -1),
                new TreeNode('Q', -1, -1)
            };

            Console.Write("Enter a character: ");
            char c = char.Parse(Console.ReadLine());

            Decode(c);

            Console.ReadKey();
        }

        static char Decode(char c)
        {
            return c;
        }
    }
}

