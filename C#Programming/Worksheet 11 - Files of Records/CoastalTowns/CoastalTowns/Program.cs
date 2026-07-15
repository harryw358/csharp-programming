using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoastalTowns
{
    class Program
    {
        struct TownType
        {
            public string Name, County;
            public int Population, Area;
        }
        static void Main(string[] args)
        {
            string filepath = @"data.bin";
            List<TownType> listOfTowns = GetCoastalTowns(filepath);

            int menuChoice = Menu();

            while (menuChoice != 6)
            {
                if (menuChoice == 1)
                {
                    //code for list all towns
                    Console.Clear();
                    Console.WriteLine("Town                County           Pop        Area\n");
                    for (int count = 0; count < listOfTowns.Count; count++)
                    {
                        DisplayTown(listOfTowns[count]);
                    }
                    Console.ReadKey();
                }
                else if (menuChoice == 2)
                {
                    //code for enter new town
                    EnterNewTown(filepath, listOfTowns);
                    Console.ReadKey();
                }
                else if (menuChoice == 3)
                {
                    //code for search by population
                    Console.Clear();
                    Console.Write("Enter lower value: ");
                    int lowerValue = EnterNumber();
                    Console.Write("Enter upper value: ");
                    int upperValue = EnterNumber();
                    SearchByPopulation(listOfTowns, lowerValue, upperValue);
                    Console.ReadKey();
                }
                else if (menuChoice == 4)
                {
                    //code for delete a town
                    Console.Clear();
                    Console.Write("Which town do you want to remove? ");
                    string townToRemove = Console.ReadLine();
                    bool townFound = TownFound(townToRemove, listOfTowns);
                    if (townFound)
                    {
                        RemoveTown(townToRemove, listOfTowns, filepath);
                    }
                    else if(townFound == false)
                    {
                        Console.WriteLine("That town is not in the file.\n\nPress enter to continue. . .");
                        Console.ReadKey();
                    }
                }
                else if (menuChoice == 5)
                {
                    //code for update a town
                    Console.Clear();
                    Console.Write("Which town do you want to update? ");
                    string townToUpdate = Console.ReadLine();
                    bool townFound = TownFound(townToUpdate, listOfTowns);
                    if (townFound)
                    {
                        UpdateTown(townToUpdate, listOfTowns, filepath);
                    }
                    else if(townFound == false)
                    {
                        Console.WriteLine("That town is not in the file.\n\nPress enter to continue. . .");
                        Console.ReadKey();
                    }
                }
                Console.Clear();
                menuChoice = Menu();
            }
        }
        static int Menu()
        {
            int menuChoice = 0;
            Console.Write("Choose an option:\n\n1: List all towns\n2: Enter new town\n3: Search by population\n4: Delete a town\n5: Update a town\n6: Exit\n");
            do
            {
                Console.Write("\nYour choice: ");
                try
                {
                    menuChoice = int.Parse(Console.ReadLine());
                    if (menuChoice < 1 || menuChoice > 6)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Please choose a valid option. Press enter to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Choose an option:\n\n1: List all towns\n2: Enter new town\n3: Search by population\n4: Delete a town\n5: Update a town\n6: Exit\n");
                }
            }
            while (menuChoice < 1 || menuChoice > 6);
            return menuChoice;
        }
        static List<TownType> GetCoastalTowns(string filepath)
        {
            FileStream currentFile = new FileStream(filepath, FileMode.Open);
            BinaryReader currentFileReader = new BinaryReader(currentFile);

            List<TownType> listOfTowns = new List<TownType>();

            do
            {
                TownType town = new TownType();

                town.Name = currentFileReader.ReadString();
                town.County = currentFileReader.ReadString();
                town.Population = currentFileReader.ReadInt32();
                town.Area = currentFileReader.ReadInt32();

                listOfTowns.Add(town);
            }
            while (currentFile.Position < currentFile.Length);

            currentFileReader.Close();
            currentFile.Close();
            return listOfTowns;
        }
        static void WriteSpaces(int numOfSpaces)
        {
            for (int i = 0; i < numOfSpaces; i++)
            {
                Console.Write(" ");
            }
        }
        static void DisplayTown(TownType town)
        {
            Console.Write(town.Name); WriteSpaces(20 - town.Name.Length);
            Console.Write(town.County); WriteSpaces(17 - town.County.Length);
            Console.Write(town.Population); WriteSpaces(11 - Convert.ToString(town.Population).Length);
            Console.Write(town.Area);
            Console.WriteLine();
        }
        static void EnterNewTown(string filepath, List<TownType> towns)
        {
            FileStream currentFile = new FileStream(filepath, FileMode.Append);
            BinaryWriter currentFileWriter = new BinaryWriter(currentFile);

            Console.Clear();

            TownType town = new TownType();

            Console.Write("Name: "); town.Name = Console.ReadLine();
            Console.Write("County: "); town.County = Console.ReadLine();
            Console.Write("Population: "); town.Population = EnterNumber();
            Console.Write("Area: "); town.Area = EnterNumber();
            towns.Add(town);

            currentFileWriter.Write(town.Name);
            currentFileWriter.Write(town.County);
            currentFileWriter.Write(town.Population);
            currentFileWriter.Write(town.Area);

            currentFileWriter.Close();
            currentFile.Close();
        }
        static int EnterNumber()
        {
            int num = 0;
            do
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                    if (num < 0)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.Write("Please enter a valid number.");
                }
            }
            while (num < 1);
            return num;
        }
        static void SearchByPopulation(List<TownType> listOfTowns, int lowerValue, int upperValue)
        {
            for (int i = 0; i < listOfTowns.Count; i++)
            {
                TownType town = listOfTowns[i];
                if (town.Population >= lowerValue && town.Population <= upperValue)
                {
                    DisplayTown(listOfTowns[i]);
                }
            }
        }
        static void RemoveTown(string townToRemove, List<TownType> listOfTowns, string filepath)
        {
            string tempFilepath = @"temp.bin";
            FileStream currentFile = new FileStream(tempFilepath, FileMode.Append);
            BinaryWriter currentFileWriter = new BinaryWriter(currentFile);

            for(int i = 0; i < listOfTowns.Count; i++)
            {
                if (listOfTowns[i].Name == townToRemove)
                {
                    listOfTowns.Remove(listOfTowns[i]);
                    Console.WriteLine(townToRemove + " has been removed from the file.\n\nPress enter to continue. . .");
                    Console.ReadKey();
                }
                else
                {
                    currentFileWriter.Write(listOfTowns[i].Name);
                    currentFileWriter.Write(listOfTowns[i].County);
                    currentFileWriter.Write(listOfTowns[i].Population);
                    currentFileWriter.Write(listOfTowns[i].Area);
                }
            }
            
            currentFileWriter.Close();
            currentFile.Close();

            File.Delete(filepath);
            File.Move(@"temp.bin", @"data.bin");
        }
        static bool TownFound(string townName, List<TownType> listOfTowns)
        {
            for(int i = 0; i < listOfTowns.Count; i++)
            {
                if(listOfTowns[i].Name == townName)
                {
                    return true;
                }
            }
            return false;
        }
        static void UpdateTown(string townToUpdate, List<TownType> listOfTowns, string filepath)
        {
            FileStream currentFile = new FileStream(filepath, FileMode.Open);
            BinaryWriter currentFileWriter = new BinaryWriter(currentFile);
            TownType newTown = new TownType();

            for(int i = 0; i < listOfTowns.Count; i++)
            {
                if(listOfTowns[i].Name == townToUpdate)
                {
                    newTown.Name = townToUpdate;
                    Console.Write("New county: "); newTown.County = Console.ReadLine();
                    Console.Write("New population: "); newTown.Population = EnterNumber();
                    Console.Write("New area: "); newTown.Area = EnterNumber();

                    listOfTowns.RemoveAt(i);
                    listOfTowns.Insert(i, newTown);
                }

                currentFileWriter.Write(listOfTowns[i].Name);
                currentFileWriter.Write(listOfTowns[i].County);
                currentFileWriter.Write(listOfTowns[i].Population);
                currentFileWriter.Write(listOfTowns[i].Area);
            }

            currentFileWriter.Close();
            currentFile.Close();
        }
    }
}
