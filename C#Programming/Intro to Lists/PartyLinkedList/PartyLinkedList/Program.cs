using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyLinkedList
{
    public class Program
    {
        class LinkedListNode
        {
            public Friend data;
            public LinkedListNode next;

            public LinkedListNode(Friend x)
            {
                data = x;
                next = null;
            }
        }
        class LinkedList
        {
            int count;
            LinkedListNode head;

            public LinkedList()
            {
                head = null;
                count = 0;
            }
            public void Add(Friend data)
            {
                LinkedListNode node = new LinkedListNode(data);
                node.next = head;
                head = node;
                count++;
            }
            public void PrintList()
            {
                LinkedListNode runner = head;
                int count = 0;
                while (runner != null)
                {
                    Console.WriteLine(runner.data.Name);
                    runner = runner.next;
                    count++;
                }
                Console.WriteLine(count + " friends on the party list.\n");
            }
            public void SearchByName()
            {
                string choice = null;
                do
                {
                    Console.Write("Search by name: ");
                    string name = Console.ReadLine();
                    LinkedListNode runner = head;
                    while (runner != null)
                    {
                        if (runner.data.Name == name)
                        {
                            Console.WriteLine(name + "'s invite status: " + runner.data.InviteStatus + "\n");
                        }
                        runner = runner.next;
                    }
                    Console.Write("Search again? (Y/N): ");
                    choice = Console.ReadLine();
                }
                while (choice.ToLower() == "y" || choice.ToLower() == "yes");
            }
            public void SearchByInviteStatus(bool inviteStatus)
            {
                LinkedListNode runner = head;
                int count = 0;
                while(runner != null)
                {
                    if(runner.data.InviteStatus == inviteStatus)
                    {
                        Console.WriteLine(runner.data.Name);
                        count++;
                    }
                    runner = runner.next;
                }
                if (inviteStatus)
                {
                    Console.WriteLine(count + " friends accepted their invite.");
                }
                else
                {
                    Console.WriteLine(count + " friends did not accept their invite.");
                }
            }
            public void DeleteFriend()
            {
                Console.Write("Delete by name: ");
                string name = Console.ReadLine();

                LinkedListNode temp = head;
                LinkedListNode prev = null;

                if(temp.data.Name == name)
                {
                    head = temp.next;
                    return;
                }
                while (temp != null && temp.data.Name != name)
                {
                    prev = temp;
                    temp = temp.next;
                }
                prev.next = temp.next;
            }
            static void Main(string[] args)
            {
                LinkedList partyList = new LinkedList();
                partyList = CreatePartyList();
                partyList.PrintList();
                Console.WriteLine();
                partyList.SearchByInviteStatus(true);
                Console.WriteLine();
                partyList.SearchByInviteStatus(false);
                Console.WriteLine();
                partyList.SearchByName();
                Console.WriteLine();
                partyList.DeleteFriend();
                Console.WriteLine();
                partyList.PrintList();
                Console.ReadKey();
            }
            static LinkedList CreatePartyList()
            {
                LinkedList partyList = new LinkedList();
                Console.WriteLine("Make your party list below, enter 'xxx' in name to stop:");
                string name = null;
                bool inviteStatus = false;
                int priority = 0;
                do
                {
                    Console.Write("\nName: ");
                    name = Console.ReadLine();
                    if (name != "xxx")
                    {
                        Console.Write("Invite status: ");
                        inviteStatus = Convert.ToBoolean(Console.ReadLine());
                        Console.Write("Priority: ");
                        priority = int.Parse(Console.ReadLine());

                        Friend f = new Friend(name, inviteStatus, priority);
                        partyList.Add(f);
                    }
                }
                while (name != "xxx");
                Console.Clear();
                return partyList;
            }
        }
    }
}
