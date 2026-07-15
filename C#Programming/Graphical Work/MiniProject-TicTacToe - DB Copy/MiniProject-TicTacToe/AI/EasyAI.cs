using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;

namespace MiniProject_TicTacToe.AI
{
    public class EasyAI : TemplateAI
    {
        public EasyAI() : base()
        {
            _name = "Easy AI";
        } 
        public override Cell CalculateMove(Game2 game)
        {
            // no logic at all, just return a random cell

            List<Cell> emptyCells = new List<Cell>();
            emptyCells = game.Board.GetEmptyCells();
            Random rnd = new Random();
            return emptyCells[rnd.Next(1, emptyCells.Count)];
        }
    }
}
