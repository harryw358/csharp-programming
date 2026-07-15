using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            //show empty chess board
            printBoard(myBoard);

            //ask user x and y coordinates where we will place a piece
            Cell currentCell = setCurrentCell();
            currentCell.CurrentlyOccupied = true;

            //calculate legal moves for piece
            myBoard.MarkNextLegalMoves(currentCell, "Knight");

            //print chess board using an X for occupied squares and + for legal move and . for empty cell
            printBoard(myBoard);

            //wait for another enter key press before ending program
            Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            //get x and y coordinates then return location of cell
            Console.WriteLine("Enter the current row number");
            int currentRow = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the current column number");
            int currentCol = int.Parse(Console.ReadLine());

            return myBoard.theGrid[currentRow, currentCol];
        }

        private static void printBoard(Board myBoard)
        {
            //print chess board to console
            for(int i = 0; i < myBoard.Size; i++)
            {
                for(int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];
                    if (c.CurrentlyOccupied)
                    {
                        Console.Write("X ");
                    }
                    else if (c.LegalNextMove)
                    {
                        Console.Write("+ ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("================");
        }
    }
}
