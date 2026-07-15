using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FittingsStacks
{
    public class Stack
    {
        private Fitting[] stack;
        private int topFitting;

        public Stack()
        {
            stack = new Fitting[5];
            topFitting = -1;
        }
        private bool IsFull()
        {
            if (topFitting == stack.Length - 1)
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
            if(topFitting == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Push(Fitting newFitting)
        {
            if (IsFull())
            {
                MessageBox.Show("Stack is full!");
                return;
            }
            else
            {
                topFitting++;
                stack[topFitting] = newFitting;
            }
        }
        public Fitting Pop()
        {
            if (IsEmpty())
            {
                MessageBox.Show("Stack is empty!");
                return null;
            }
            else
            {
                Fitting poppedFitting = stack[topFitting];
                topFitting--;
                return poppedFitting;
            }
        }
        public Fitting Peek()
        {
            if (IsEmpty())
            {
                MessageBox.Show("Stack is empty!");
                return null;
            }
            else
            {
                return stack[topFitting];
            }
        }
    }
}
