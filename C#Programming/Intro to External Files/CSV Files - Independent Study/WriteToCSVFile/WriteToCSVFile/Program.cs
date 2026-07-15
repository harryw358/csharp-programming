using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WriteToCSVFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "D:/CS/C#Y1Programming/Intro to External Files/CSV Files - Independent Study/cake.txt";
            //addRecord("124", "Mercy", "56", filepath);
            Console.WriteLine(string.Join("", readRecord("124", filepath, 1)));
            Console.ReadKey();
        }
        public static void addRecord(string ID, string name, string age, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(ID + "," + name + "," + age);
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("This program did an oopsie :", ex);
            }
        }
        public static string[] readRecord(string searchTerm, string filepath, int positionOfSearchTerm)
        {
            positionOfSearchTerm--;
            string[] recordNotFound = { "Record not found" };

            try
            {
                string[] lines = System.IO.File.ReadAllLines(@filepath);

                for(int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if(recordMatches(searchTerm, fields, positionOfSearchTerm))
                    {
                        Console.WriteLine("Record found");
                        return fields;
                    }
                }   
                return recordNotFound;
            }
            catch(Exception ex)
            {
                Console.WriteLine("This program did an oopsie");
                return recordNotFound;
                throw new ApplicationException("This program did an oopsie: ", ex);
            }
        }
        public static bool recordMatches(string searchTerm, string[] record, int positionOfSearchTerm)
        {
            if (record[positionOfSearchTerm].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }
    }
}
