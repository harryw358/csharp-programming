using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProject_TicTacToe.Enum;

namespace MiniProject_TicTacToe.Players.AI
{
    public class NormalAI : TemplateAI
    {
        public NormalAI() : base()
        {
            _name = "Normal AI";
        }
        public override Cell CalculateMove(Game game)
        {
            // will make winning moves only if there
            // is one detected add every empty square
            // to a list try each square and if it
            // results in a win an if it results in
            // a win return this cell. If no cells
            // in the list result in a win return a
            // random empty cell

            List<Cell> emptyCells = game.Board.GetEmptyCells();

            foreach(Cell cell in emptyCells)
            {
                if (SimulateMove(game, cell, CellState.Player02, "O", game.PlayerTurn))
                {
                    return cell;
                }
            }
            return game.Board.GetRandomEmptyCell();
        }
    }
}
