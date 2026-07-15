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

        }

        public void EditNeighbours()
        {
           
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

            Console.ReadKey();
        }
    }

}






