    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTraversal
{
    public class Tree
    {
        private int _left, _right;
        private char _data;

        public int Left { get => _left; }
        public int Right { get => _right; }
        public char Data { get => _data; }

        public Tree(int left, char data, int right)
        {
            _left = left;
            _data = data;
            _right = right;
        }
    }
}
