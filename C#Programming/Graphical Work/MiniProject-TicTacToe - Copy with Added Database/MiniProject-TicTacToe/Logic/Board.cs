using System.Collections.Generic;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;
using System.Drawing;
using System.Threading.Tasks;
using System;

namespace MiniProject_TicTacToe
{
    public class Board
    {
        private readonly int _size;
        private readonly Cell[,] _grid; 
        public int Size { get => _size; }
        public Cell[,] Grid { get => _grid; }

        public Board(int s)
        {
            _size = s;
            _grid = new Cell[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Cell(i, j, CellState.Empty);
                }
            }
        }
       public List<Cell> GetEmptyCells()
        {
            List<Cell> emptyCells = new List<Cell>();
            foreach(Cell cell in _grid)
            {
                if(cell.State == CellState.Empty)
                {
                    emptyCells.Add(cell);
                }
            }
            return emptyCells;
        }
        public Cell GetRandomEmptyCell()
        {
            List<Cell> emptyCells = GetEmptyCells();
            Random rnd = new Random();
            return emptyCells[rnd.Next(1, emptyCells.Count)];
        }
        public bool CheckWin(int playerTurn, Button[,] btnGrid)
        {

            string symbol;
            if(playerTurn == 0)
            {
                symbol = "X";
            }
            else
            {
                symbol = "O";
            }
            for(int i = 0; i < 3; i++)
            {
                if (btnGrid[i, 0].Text == symbol && btnGrid[i, 1].Text == symbol && btnGrid[i, 2].Text == symbol)
                {
                    HighlightWin(btnGrid, i, i, i, 0, 1, 2);
                    return true;
                }
                else if(btnGrid[0, i].Text == symbol && btnGrid[1, i].Text == symbol && btnGrid[2, i].Text == symbol)
                {
                    HighlightWin(btnGrid, 0, 1, 2, i, i, i);
                    return true;
                }
            }
            if (btnGrid[2, 0].Text == symbol && btnGrid[1, 1].Text == symbol && btnGrid[0, 2].Text == symbol)
            {
                HighlightWin(btnGrid, 2, 1, 0, 0, 1, 2);
                return true;
            }
            else if(btnGrid[0, 0].Text == symbol && btnGrid[1, 1].Text == symbol && btnGrid[2, 2].Text == symbol)
            {
                HighlightWin(btnGrid, 0, 1, 2, 0, 1, 2);
                return true;
            }
            return false;
        }
        public bool CheckDraw()
        {
            List<Cell> NonEmptyCells = new List<Cell>();
            foreach (Cell cell in _grid)
            {
                if (cell.State != CellState.Empty)
                {
                    NonEmptyCells.Add(cell);
                }
            }
            if (NonEmptyCells.Count == 9)
            {
                return true;
            }
            return false;
        }
        public void HighlightWin(Button[,] btnGrid, int i1, int i2, int i3, int j1, int j2, int j3)
        {
            btnGrid[i1, j1].BackColor = Color.Lime;
            btnGrid[i2, j2].BackColor = Color.Lime;
            btnGrid[i3, j3].BackColor = Color.Lime;
        }
    }
}
