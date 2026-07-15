using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_TicTacToe.Players.AI
{
    public class DifficultAI : TemplateAI
    {
        public DifficultAI() : base()
        {
            _name = "Difficult AI";
        }
        public override Cell CalculateMove(Game2 game)
        {
            // will block the player from making a winning move
            // if it detects one
            return null;
        }
    }
}
