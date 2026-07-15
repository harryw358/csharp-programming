using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;

namespace MiniProject_TicTacToe.Players.AI
{
    public class EasyAI : TemplateAI
    {
        public EasyAI() : base()
        {
            _name = "Easy AI";
        } 
        public override Cell CalculateMove(Game game)
        {
            // no logic at all, just return a random cell

            return game.Board.GetRandomEmptyCell();
        }
    }
}
