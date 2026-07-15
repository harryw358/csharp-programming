using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    class Stack
    {
        private int[] stack;
        private int topItem;
        public Stack()
        {
            stack = new int[5];
            topItem = -1;
        }
        public void Display()
        {
            if (!IsEmpty())
            {
                foreach (int item in stack)
                {
                    Console.Write(item + " ");
                }
            }
            else
            {
                Console.WriteLine("Stack is empty!");
            }
        }
        public void Push(int newItem)
        {
            if (!IsFull())
            {
                topItem++;
                stack[topItem] = newItem;
            }
            else
            {
                Console.WriteLine("Stack is full!");
            }
        }
        public int Pop()
        {
            if (!IsEmpty())
            {
                int poppedItem = stack[topItem];
                topItem--;
                return poppedItem;
            }
            else
            {
                Console.WriteLine("Stack is empty!");
            }
            return 0;
        }
        private bool IsFull()
        {
            if(topItem == stack.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsEmpty()
        {
            if (topItem == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Peek()
        {
            if (!IsEmpty())
            {
                Console.WriteLine(stack[topItem]);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Stack is empty!");
            }
        }
    }
}
