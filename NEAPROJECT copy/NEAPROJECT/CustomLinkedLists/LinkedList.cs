using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace NEAPROJECT.CustomLinkedLists
{
    public class CustomLinkedList
    {
        private int _count;
        private LinkedListNode _head;

        public int Count { get => _count; set => _count = value; }
        public LinkedListNode Head { get => _head; set => _head = value; }

        public CustomLinkedList()
        {
            _count = 0;
            _head = null;
        }

        public void AddNodeToFront(Component data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            newNode.Next = _head;
            _head = newNode;
            _count++;
            newNode.Index = _count;
        }

        public Component SearchList(int index)
        {
            LinkedListNode runner = _head;
            while (runner != null)
            {
                if (runner.Index == index)
                {
                    return runner.Data;
                }
                else
                {
                    runner = runner.Next;
                }
            }
            return null;
        }

        public Component SearchListByName(string name)
        {
            for (int i = 1; i <= _count; i++)
            {
                var currentComponent = SearchList(i);
                if (currentComponent.Name == name)
                {
                    return currentComponent;
                }
            }

            return null;
        }
    }
}
