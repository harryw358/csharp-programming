using System;
namespace MorseDecoder.MorseCode
{
    public class TreeNode
    {
        private char _data;
        private int _left;
        private int _right;

        public char Data { get => _data; set => _data = value; }
        public int Left { get => _left; set => _left = value; }
        public int Right { get => _right; set => _right = value; }

        public TreeNode(char data, int left, int right)
        {
            _data = data;
            _left = left;
            _right = right;
        }
    }
}

