using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace GraphTowns
{
    class MapOfCoastalTowns
    {
        private CoastalTown[] CoastalTownList = new CoastalTown[5];
        private BinaryReader currentFileReader;
        private FileStream currentFile;
        private int[,] Graph;

        public MapOfCoastalTowns() // constructor initialises the graph with the weighted edges (distance) between the the nodes (the towns)
        {
                                                                                 //Berwick-upon-Tweed, Bideford, Bognor Regis, Bridlington, Bridport
            Graph = new int[5, 5] { { 0, 20, 10, 15, 0 },   //Berwick-upon-Tweed             0            20           10            15         0
                                    { 20, 0, 5,   5, 0 },   //Bideford                       20            0            5             5         0
                                    { 10, 5, 0,   0, 0 },   //Bognor Regis                   10            5            0             0         0
                                    { 15, 5, 0,   0, 5 },   //Bridlington                    15            5            0             0         5
                                    { 0,  0, 0,   5, 0 },}; //Bridport                       0             0            0             5         0
        }
      

        public void populateTowns() // creates instances of the coastaltown class and stores the objects in CoastalTownList array
        {
            int index = 0;
            string fileName = "data.bin";
            currentFile = new FileStream(fileName, FileMode.Open);
            currentFileReader = new BinaryReader(currentFile);
            do
            {
                CoastalTownList[index] = new CoastalTown(currentFileReader.ReadString(), currentFileReader.ReadString(), currentFileReader.ReadInt32(), currentFileReader.ReadInt32());
                index++;
            }
            while (currentFile.Position < currentFile.Length && index < CoastalTownList.Length);
            currentFileReader.Close();
            currentFile.Close();
        }

        public void DisplayNeighbouringTowns()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(CoastalTownList[i].Name + " is neighbours with: ");
                for (int j = 0; j < 5; j++)
                {
                    if (Graph[i, j] != 0)
                    {
                        Console.Write(CoastalTownList[j].Name + " " + Graph[i, j] + " ");
                    }
                }
                Console.WriteLine("\n");
            }
        }

        public void EditNeighbours()
        {
            bool town01Exists = false, town02Exists = false, townIsDifferent = true;
            do
            {
                Console.Write("Enter a town name to edit: ");
                string town01Name = Console.ReadLine();
                town01Exists = CheckTownExists(town01Name);

                if (town01Exists)
                {
                    do
                    {
                        Console.Write("Enter a second town to identify weight to edit: ");
                        string town02Name = Console.ReadLine();
                        town02Exists = CheckTownExists(town02Name);

                        if (town02Exists)
                        {
                            if(town02Name == town01Name)
                            {
                                townIsDifferent = false;
                                Console.WriteLine("This town must be different.");
                            }
                            else
                            {
                                townIsDifferent = true;
                                Console.Write("New weight: ");
                                int newWeight = int.Parse(Console.ReadLine());
                                // get index of row and columnn by searching through 1D array of towns
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int j = 0; j < 5; j++)
                                    { 
                                        if(CoastalTownList[i].Name == town01Name && CoastalTownList[j].Name == town02Name)
                                        {
                                            Graph[i, j] = newWeight;
                                            DisplayNeighbouringTowns();
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Town does not exist");
                        }
                    }
                    while (!town02Exists || !townIsDifferent);
                }
                else
                {
                    Console.WriteLine("Town does not exist.");
                }
            }
            while (!town01Exists);
        }
        private bool CheckTownExists(string townName)
        {
            foreach (CoastalTown town in CoastalTownList)
            {
                if (town.Name == townName)
                {
                    return true;
                }
            }
            return false;
        }
    }


    class CoastalTown
    {
        private string name, county;
        private int population, area;

        public CoastalTown(string name, string county, int population, int area)
        {
            this.name = name;
            this.county = county;
            this.population = population;
            this.area = area;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string County
        {
            get { return county; }
            set { county = value; }
        }

        public int Population
        {
            get { return population; }
            set { population = value; }
        }

        public int Area
        {
            get { return area; }
            set { area = value; }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MapOfCoastalTowns Map1 = new MapOfCoastalTowns(); //creates a new instance of MapOfCoastalTowns
            Map1.populateTowns(); //initialises the 1D array of coastal towns with the data stored in the binary file
            Map1.DisplayNeighbouringTowns();
            Map1.EditNeighbours();

            Console.ReadKey();
        }
    }

}






