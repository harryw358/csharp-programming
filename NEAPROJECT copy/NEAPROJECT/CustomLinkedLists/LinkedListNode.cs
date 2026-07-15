using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NEAPROJECT.CustomLinkedLists
{
    public class LinkedListNode
    {
        private Component _data;
        private int _index;
        private LinkedListNode _next;

        public Component Data { get => _data; set => _data = value; }
        public int Index { get => _index; set => _index = value; }
        public LinkedListNode Next { get => _next; set => _next = value; }

        public LinkedListNode(Component data)
        {
            _data = data;
            _next = null;
        }
    }
}
