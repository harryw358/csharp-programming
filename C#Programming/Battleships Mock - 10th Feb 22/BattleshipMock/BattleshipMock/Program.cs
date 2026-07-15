using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    class Program
    {
        public struct ShipType
        {
            public string Name;
            public int Size;
        }

        const string TrainingGame = "Training.txt";

    private static int EnterRowColumn(string typeString)
    {
        int type = -1;
        do
        {
            Console.Write("Please enter " + typeString + ": ");
            try
            {
                type = int.Parse(Console.ReadLine());
                if (type < 0 || type > 9)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("That is not a valid choice.");
            }
        }
        while (type < 0 || type > 9);
        return type;
    }
    private static void GetRowColumn(ref int Row, ref int Column)
    {
        Console.WriteLine();
        Column = EnterRowColumn("column");
        Row = EnterRowColumn("row");
        Console.WriteLine();
    }
    private static void CheckMove(ref char[,] Board, ref ShipType[] Ships, ref int moves, int row, int col)
    {
        if(Board[row, col] == 'm' || Board[row, col] == 'h')
        {
            Console.WriteLine("Sorry, you have already shot at the square (" + col + "," + row + "). Please try again.");
            Console.WriteLine("You have " + moves + " moves left.");
        }
        else if (Board[row, col] == '-')
        {
            Console.WriteLine("Sorry, (" + col + "," + row + ") is a miss.");
            Board[row, col] = 'm';
            moves--;
            Console.WriteLine("You have " + moves + " moves left.");
        }
        else
        {
            //char typeOfShipHit = ShipHitCheck(Board, row, col);
            Console.WriteLine("Hit at (" + col + "," + row + ").");
            Board[row, col] = 'h';
            moves--;
            Console.WriteLine("You have " + moves + " moves left.");
        }
    }
    private static char ShipHitCheck(char[,] Board, int row, int col)
    {
        if (Board[row, col] == 'P')
            return 'P';
        else if (Board[row, col] == 'A')
            return 'A';
        else if (Board[row, col] == 'B')
            return 'B';
        else if (Board[row, col] == 'D')
            return 'D';
        else
            return 'S';
    }

    private static void MakePlayerMove(ref char[,] Board, ref ShipType[] Ships, ref int moves, string moveType)
    {
        if (moveType == "single")
        {
            int Row = 0;
            int Column = 0;
            GetRowColumn(ref Row, ref Column);
            CheckMove(ref Board, ref Ships, ref moves, Row, Column);
        }
        else if (moveType == "salvo")
        {
            bool validSet;
            int col01;
            int row01;
            int col02;
            int row02;
            int col03;
            int row03;
            do
            {
                validSet = true;
                col01 = EnterRowColumn("column 1");
                row01 = EnterRowColumn("row 1");
                col02 = EnterRowColumn("column 2");
                row02 = EnterRowColumn("row 2");
                col03 = EnterRowColumn("column 3");
                row03 = EnterRowColumn("row 3");

                if (col01 == col02 || col02 == col03 || col01 == col03)
                {
                    if (row01 == row02 || row02 == row03 || row01 == row03)
                    {
                        Console.WriteLine("2 or more of your coordinates cannot be the same. Please enter them again.");
                        validSet = false;
                    }
                }
            }
            while (validSet == false);
            CheckMove(ref Board, ref Ships, ref moves, row01, col01);
            CheckMove(ref Board, ref Ships, ref moves, row02, col02);
            CheckMove(ref Board, ref Ships, ref moves, row03, col03);
        }
    }
        private static void SetUpBoard(ref char[,] Board)
        {
            for (int Row = 0; Row < 10; Row++)
            {
                for (int Column = 0; Column < 10; Column++)
                {
                    Board[Row, Column] = '-';
                }
            }
        }

        private static void LoadGame(string TrainingGame, ref char[,] Board)
        {
            string Line = "";
            StreamReader BoardFile = new StreamReader(TrainingGame);
            for (int Row = 0; Row < 10; Row++)
            {
                Line = BoardFile.ReadLine();
                for (int Column = 0; Column < 10; Column++)
                {
                    Board[Row, Column] = Line[Column];
                }
            }
            BoardFile.Close();
        }

        private static void PlaceRandomShips(ref char[,] Board, ShipType[] Ships)
        {
            Random RandomNumber = new Random();
            bool Valid;
            char Orientation = ' ';
            int Row = 0;
            int Column = 0;
            int HorV = 0;
            foreach (var Ship in Ships)
            {
                Valid = false;
                while (Valid == false)
                {
                    Row = RandomNumber.Next(0, 10);
                    Column = RandomNumber.Next(0, 10);
                    HorV = RandomNumber.Next(0, 2);
                    if (HorV == 0)
                    {
                        Orientation = 'v';
                    }
                    else
                    {
                        Orientation = 'h';
                    }
                    Valid = ValidateBoatPosition(Board, Ship, Row, Column, Orientation);
                }
                Console.WriteLine("Computer placing the " + Ship.Name);
                PlaceShip(ref Board, Ship, Row, Column, Orientation);
            }
        }

        private static void PlaceShip(ref char[,] Board, ShipType Ship, int Row, int Column, char Orientation)
        {
            if (Orientation == 'v')
            {
                for (int Scan = 0; Scan < Ship.Size; Scan++)
                {
                    Board[Row + Scan, Column] = Ship.Name[0];
                }
            }
            else if (Orientation == 'h')
            {
                for (int Scan = 0; Scan < Ship.Size; Scan++)
                {
                    Board[Row, Column + Scan] = Ship.Name[0];
                }
            }
        }

        private static bool ValidateBoatPosition(char[,] Board, ShipType Ship, int Row, int Column, char Orientation)
        {
            if (Orientation == 'v' && Row + Ship.Size > 10)
            {
                return false;
            }
            else if (Orientation == 'h' && Column + Ship.Size > 10)
            {
                return false;
            }
            else
            {
                if (Orientation == 'v')
                {
                    for (int Scan = 0; Scan < Ship.Size; Scan++)
                    {
                        if (Board[Row + Scan, Column] != '-')
                        {
                            return false;
                        }
                    }
                }
                else if (Orientation == 'h')
                {
                    for (int Scan = 0; Scan < Ship.Size; Scan++)
                    {
                        if (Board[Row, Column + Scan] != '-')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static bool CheckWin(char[,] Board)
        {
            for (int Row = 0; Row < 10; Row++)
            {
                for (int Column = 0; Column < 10; Column++)
                {
                    if (Board[Row, Column] == 'A' || Board[Row, Column] == 'B' || Board[Row, Column] == 'S' || Board[Row, Column] == 'D' || Board[Row, Column] == 'P')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void PrintBoard(char[,] Board)
        {
            Console.WriteLine();
            Console.WriteLine("The board looks like this: ");
            Console.WriteLine();
            Console.Write(" ");
            for (int Column = 0; Column < 10; Column++)
            {
                Console.Write(" " + Column + "  ");
            }
            Console.WriteLine();
            for (int Row = 0; Row < 10; Row++)
            {
                Console.Write(Row + " ");
                for (int Column = 0; Column < 10; Column++)
                {
                    if (Board[Row, Column] == '-')
                    {
                        Console.Write(" ");
                    }
                    else if (Board[Row, Column] == 'A' || Board[Row, Column] == 'B' || Board[Row, Column] == 'S' || Board[Row, Column] == 'D' || Board[Row, Column] == 'P')
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(Board[Row, Column]);
                    }
                    if (Column != 9)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("");
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Load training game");
            Console.WriteLine("9. Quit");
            Console.WriteLine();
        }

        private static int GetMainMenuChoice()
        {
        int Choice = 0;
        do
        {
            Console.Write("Please enter your choice: ");
            try
            {
                Choice = int.Parse(Console.ReadLine());
                if (Choice != 1 && Choice != 2 && Choice != 9)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("That is not a valid input.");
            }
        }
        while (Choice != 1 && Choice != 2 && Choice != 9);
        Console.WriteLine();
        return Choice;
        }

        private static void PlayGame(ref char[,] Board, ref ShipType[] Ships, ref int moves)
        {
            bool GameWon = false;
            while (GameWon == false)
            {
                PrintBoard(Board);
            string choice = " ";
            do
            {
                Console.Write("\nSingle shot or salvo? ");
                choice = Console.ReadLine();
                if (choice != "single" && choice != "salvo")
                {
                    Console.Write("Please enter \"single\" or \"salvo\".");
                }
            }
            while (choice != "single" && choice != "salvo");
            if (choice == "single")
            {
                MakePlayerMove(ref Board, ref Ships, ref moves, "single");
            }
            else
            {
                MakePlayerMove(ref Board, ref Ships, ref moves, "salvo");
            }
                GameWon = CheckWin(Board);
                if (GameWon == true)
                {
                    Console.WriteLine("All ships sunk! It took you " + (35 - moves) + " moves to win.");
                    Console.WriteLine();
                }
            }
        }

        private static void SetUpShips(ref ShipType[] Ships)
        {
            Ships[0].Name = "Aircraft Carrier";
            Ships[0].Size = 5;
            Ships[1].Name = "Battleship";
            Ships[1].Size = 4;
            Ships[2].Name = "Submarine";
            Ships[2].Size = 3;
            Ships[3].Name = "Destroyer";
            Ships[3].Size = 3;
            Ships[4].Name = "Patrol Boat";
            Ships[4].Size = 2;
        }

        static void Main(string[] args)
        {
            ShipType[] Ships = new ShipType[5];
            char[,] Board = new char[10, 10];
            int MenuOption = 0, moves = 35;
            while (MenuOption != 9)
            {
                SetUpBoard(ref Board);
                SetUpShips(ref Ships);
                DisplayMenu();
                MenuOption = GetMainMenuChoice();
                if (MenuOption == 1)
                {
                    PlaceRandomShips(ref Board, Ships);
                    PlayGame(ref Board, ref Ships, ref moves);
                }
                if (MenuOption == 2)
                {
                    LoadGame(TrainingGame, ref Board);
                    PlayGame(ref Board, ref Ships, ref moves);
                }
            }
        }
    }