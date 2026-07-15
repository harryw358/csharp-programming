using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    internal class Student
    {
        private string _studentID, _name, _address, _tutor;
        private int _yearGroup;

        public string StudentID { get => _studentID; set => _studentID = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Tutor { get => _tutor; set => _tutor = value; }
        public int YearGroup { get => _yearGroup; set => _yearGroup = value; }

        public Student(string studentID, string name, string address, string tutor, int yearGroup)
        {
            _studentID = studentID;
            _name = name;
            _address = address;
            _tutor = tutor;
            _yearGroup = yearGroup;
        }
        public void ShowInformation()
        {
            Console.Write($"Student ID: {_studentID}\nName: {_name}\nAddress: {_address}\nTutor: {_tutor}\nYear group: {_yearGroup}");
        }
    }
}
