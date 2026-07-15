using System;
using NEAPROJECT.States;
using NEAPROJECT.UI;

namespace NEAPROJECT.CustomStacks
{
    public class StateStack
    {
        private State[] _stack;
        private int _topItem;

        public StateStack()
        {
            _stack = new State[10];
            _topItem = -1;
        }

        public void Push(State newItem)
        {
            if (!IsFull())
            {
                _topItem++;
                _stack[_topItem] = newItem;
            }
        }

        public State Pop()
        {
            if (!IsEmpty())
            {
                _topItem--;
                return _stack[_topItem];
            }
            return null;
        }

        private bool IsFull()
        {
            if (_topItem == _stack.Length)
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
            if (_topItem == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

