using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        //size of the board is typically 8x8
        public int Size { get; set; }

        //2D array of type cell
        public Cell[,] theGrid { get; set; }


        //constructor
        public Board(int s)
        {
            Size = s;

            theGrid = new Cell[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            //1: clear previous legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }
            //2: find and mark all legal moves
            switch (chessPiece)
            {
                case "Knight":
                    if (isSafe(currentCell, 2, 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell, 2, -1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell, -2, 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell, -2, -1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(currentCell, 1, 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if (isSafe(currentCell, 1, -2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    if (isSafe(currentCell, -1, 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if (isSafe(currentCell, -1, -2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;
                case "King":
                    if (isSafe(currentCell, 1, 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell, -1, -1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell, 1, -1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell, -1, 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell, 1, 0))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                    if (isSafe(currentCell, 0, 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell, -1, 0))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                    if (isSafe(currentCell, 0, -1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    break;
                case "Rook":
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell, i, 0))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                        if (isSafe(currentCell, 0, i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell, -i, 0))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                        if (isSafe(currentCell, 0, -i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    break;
                case "Bishop":
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell, i, i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell, -i, -i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        if (isSafe(currentCell, i, -i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        if (isSafe(currentCell, -i, i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }
                    break;
                case "Queen":
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell, i, i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell, -i, -i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        if (isSafe(currentCell, i, -i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        if (isSafe(currentCell, -i, i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell, i, 0))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                        if (isSafe(currentCell, 0, i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell, -i, 0))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                        if (isSafe(currentCell, 0, -i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    break;
                default:
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }
        bool isSafe(Cell currentCell, int x, int y)
        {
            try
            {
                if (!theGrid[currentCell.RowNumber + x, currentCell.ColumnNumber + y].CurrentlyOccupied)
                    return true;
            }
            catch { }
            return false;
        }
    }
}
