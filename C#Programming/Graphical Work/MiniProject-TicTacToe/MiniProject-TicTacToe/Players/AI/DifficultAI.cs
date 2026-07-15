using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProject_TicTacToe.Enum;

namespace MiniProject_TicTacToe.Players.AI
{
    public class DifficultAI : TemplateAI
    {
        public DifficultAI() : base()
        {
            _name = "Difficult AI";
        }
        public override Cell CalculateMove(Game game)
        {
            // will block the player from making a winning move
            // only if it can see such a move. If no such move
            // is detected, it will return a random empty cell

            List<Cell> emptyCells = game.Board.GetEmptyCells();

            foreach (Cell cell in emptyCells)
            {
                if (SimulateMove(game, cell, CellState.Player01, "X", 0))
                {
                    game.Board.ResetGridColor(game.btnGrid);
                    return cell;
                }
            }
            return game.Board.GetRandomEmptyCell();
        }
    }
}
