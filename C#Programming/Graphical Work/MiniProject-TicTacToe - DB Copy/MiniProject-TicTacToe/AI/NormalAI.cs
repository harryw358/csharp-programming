using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProject_TicTacToe.Enum;

namespace MiniProject_TicTacToe.AI
{
    public class NormalAI : TemplateAI
    {
        public NormalAI() : base()
        {
            _name = "Normal AI";
        }
        public override Cell CalculateMove(Game2 game)
        {
            // will make winning moves only if there
            // is one detected
            // add every empty square to a list
            // try each square to project a win and
            // if it results in a win return this
            // cell, if not return a random cell

            List<Cell> emptyCells = new List<Cell>();
            emptyCells = game.Board.GetEmptyCells();

            foreach(Cell cell in emptyCells)
            {
                if(SimulateMove(game, cell))
                {
                    return cell;
                }
            }
            Random rnd = new Random();
            return emptyCells[rnd.Next(1, emptyCells.Count)];
        }
        private bool SimulateMove(Game2 game, Cell currentCell)
        {
            currentCell.State = CellState.Player02; //AI is always player 2
            game.btnGrid[currentCell.RowNumber, currentCell.ColumnNumber].Text = "O";
            if (game.Board.CheckWin(game.PlayerTurn, game.btnGrid))
            {
                currentCell.State = CellState.Empty;
                game.btnGrid[currentCell.RowNumber, currentCell.ColumnNumber].Text = "";
                return true;
            }
            else
            {
                currentCell.State = CellState.Empty;
                game.btnGrid[currentCell.RowNumber, currentCell.ColumnNumber].Text = "";
            }
            return false;
        }
    }
}
