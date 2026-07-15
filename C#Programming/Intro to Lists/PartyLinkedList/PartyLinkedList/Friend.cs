using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyLinkedList
{
    class Friend
    {
        private string _name;
        private bool _inviteStatus;
        private int _priority;

        public string Name { get => _name; set => _name = value; }
        public bool InviteStatus { get => _inviteStatus; set => _inviteStatus = value; }
        public int Priority { get => _priority; set => _priority = value; }

        public Friend(string name, bool inviteStatus, int priority)
        {
            _name = name;
            _inviteStatus = inviteStatus;
            _priority = priority;
        }
    }
}
