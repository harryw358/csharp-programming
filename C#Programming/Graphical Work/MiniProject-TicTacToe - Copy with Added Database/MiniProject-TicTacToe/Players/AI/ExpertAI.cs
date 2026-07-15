using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_TicTacToe.Players.AI
{
    public class ExpertAI : TemplateAI
    {
        public ExpertAI() : base()
        {
            _name = "Expert AI";
        }
        public override Cell CalculateMove(Game2 game)
        {
            return null; 
        }
    }
}
