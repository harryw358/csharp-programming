using MiniProject_TicTacToe.Enum;

namespace MiniProject_TicTacToe
{
    public class Cell
    {
        private int _rowNumber;
        private int _columnNumber;
        private CellState _state;
        public int RowNumber { get => _rowNumber; }
        public int ColumnNumber { get => _columnNumber; }
        public CellState State { get => _state; set => _state = value; }
        public Cell(int row, int col, CellState state)
        {
            _rowNumber = row;
            _columnNumber = col;
            _state = state;
        }
    }
}
