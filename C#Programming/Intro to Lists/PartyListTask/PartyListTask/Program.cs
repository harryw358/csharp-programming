using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyListTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Asks user to make there party list
            List<Friend> partyList = MakePartyList();

            // Prints all the names of people on the party list and the number of people
            PrintNames(partyList);
            Console.ReadKey();
            Console.WriteLine();

            // Prints all the names of people on the party list who accepted their invite and those who havent
            PrintNamesBasedOnInviteStatus(partyList, true);
            Console.WriteLine();
            PrintNamesBasedOnInviteStatus(partyList, false);
            Console.ReadKey();
            Console.WriteLine();

            // Allows user to search by name for invite status
            SearchByName(partyList);
            Console.ReadKey();
            Console.WriteLine();

            Console.ReadKey();
        }
        static List<Friend> MakePartyList()
        {
            List<Friend> partyList = new List<Friend>();
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
        static void PrintNames(List<Friend> partyList)
        {
            foreach(Friend f in partyList)
            {
                Console.WriteLine(f.Name);
            }
            Console.WriteLine("\n" + partyList.Count + " friends on the list.");
        }
        static void PrintNamesBasedOnInviteStatus(List<Friend> partyList, bool inviteStatus)
        {
            int count = 0;
            foreach (Friend f in partyList)
            {
                if (f.InviteStatus == inviteStatus)
                {
                    Console.WriteLine(f.Name);
                    count++;
                }
            }
            if (inviteStatus)
            {
                Console.WriteLine("\n" + count + " friends accepted their invite.");
            }
            else
            {
                Console.WriteLine("\n" + count + " friends did not accept their invite.");
            }
        }
        static void SearchByName(List<Friend> partyList)
        {
            string choice = null;
            bool nameFound = false;

            do
            {
                Console.Write("Search name: ");
                string name = Console.ReadLine();

                foreach(Friend f in partyList)
                {
                    if (f.Name == name)
                    {
                        Console.WriteLine("Invite status: " + f.InviteStatus);
                        nameFound = true;
                    }
                }
                if (!nameFound)
                {
                    Console.WriteLine("Name is not on the party list.");
                }

                Console.Write("Search again? Y/N: ");
                choice = Console.ReadLine();
            }
            while (choice.ToLower() == "y");
        }
    }
}
