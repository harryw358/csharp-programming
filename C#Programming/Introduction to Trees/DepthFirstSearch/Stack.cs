using System;
namespace DepthFirstSearch
{
    public class Stack
    {
        int[] _stack;
        int _topItem;
        int _size;

        public int Size { get => _size; }

        public Stack(int size)
        {
            _topItem = -1;
            _stack = new int[size];
            _size = size;
        }
        
        public void Push(int newItem)
        {
            _topItem++;
            _stack[_topItem] = newItem;
        }

        public int Pop()
        {
            int poppedItem = _stack[_topItem];
            _topItem--;
            _size--;
            return poppedItem;
        }
    }
}

