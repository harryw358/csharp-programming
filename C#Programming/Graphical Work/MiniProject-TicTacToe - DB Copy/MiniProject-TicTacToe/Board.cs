using System.Collections.Generic;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;
using System.Drawing;
using System.Threading.Tasks;

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
            if(btnGrid[0,0].Text != "")
            {
                if(btnGrid[0, 0].Text == symbol && btnGrid[1, 0].Text == symbol && btnGrid[2, 0].Text == symbol)
                {
                    HighlightWin(btnGrid, 0, 1, 2, 0, 0, 0);
                    return true;
                }
                else if(btnGrid[0, 0].Text == symbol && btnGrid[0, 1].Text == symbol && btnGrid[0, 2].Text == symbol)
                {
                    HighlightWin(btnGrid, 0, 0, 0, 0, 1, 2);
                    return true;
                }
                else if(btnGrid[0, 0].Text == symbol && btnGrid[1, 1].Text == symbol && btnGrid[2, 2].Text == symbol)
                {
                    HighlightWin(btnGrid, 0, 1, 2, 0, 1, 2);
                    return true;
                }
            }
            if(btnGrid[2, 0].Text != "")
            {
                if(btnGrid[2, 0].Text == symbol && btnGrid[2, 1].Text == symbol && btnGrid[2, 2].Text == symbol)
                {
                    HighlightWin(btnGrid, 2, 2, 2, 0, 1, 2);
                    return true;
                }
                else if(btnGrid[2, 0].Text == symbol && btnGrid[1, 1].Text == symbol && btnGrid[0, 2].Text == symbol)
                {
                    HighlightWin(btnGrid, 2, 1, 0, 0, 1, 2);
                    return true;
                }
            }
            if(btnGrid[1, 0].Text != "")
            {
                if(btnGrid[1, 0].Text == symbol && btnGrid[1, 1].Text == symbol && btnGrid[1, 2].Text == symbol)
                {
                    HighlightWin(btnGrid, 1, 1, 1, 0, 1, 2);
                    return true;
                }
            }
            if(btnGrid[0, 1].Text != "")
            {
                if(btnGrid[0, 1].Text == symbol && btnGrid[1, 1].Text == symbol && btnGrid[2,1].Text == symbol)
                {
                    HighlightWin(btnGrid, 0, 1, 2, 1, 1, 1);
                    return true;
                }
            }
            if (btnGrid[0, 2].Text != "")
            {
                if (btnGrid[0, 2].Text == symbol && btnGrid[1, 2].Text == symbol && btnGrid[2, 2].Text == symbol)
                {
                    HighlightWin(btnGrid, 0, 1, 2, 2, 2, 2);
                    return true;
                }
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
