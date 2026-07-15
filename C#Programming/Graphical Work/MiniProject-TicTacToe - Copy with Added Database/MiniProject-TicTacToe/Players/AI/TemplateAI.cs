using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;
using System.Timers;

namespace MiniProject_TicTacToe.Players.AI
{
    public abstract class TemplateAI
    {
        protected string _name;
        private int _wins;
        private int _losses;
        private int _draws;
        public string Name { get => _name; set => _name = value; }
        public int Wins { get => _wins; set => _wins = value; }
        public int Losses { get => _losses; set => _losses = value; }
        public int Draws { get => _draws; set => _draws = value; }

        public TemplateAI()
        {
            _name = null;
            _wins = 0;
            _losses = 0;
            _draws = 0;
        }
        public abstract Cell CalculateMove(Game2 game);
        public void MakeMove(Game2 game)
        {
            Cell randomCell = CalculateMove(game);
            randomCell.State = CellState.Player02;
            game.btnGrid[randomCell.RowNumber, randomCell.ColumnNumber].Text = "O";
            game.btnGrid[randomCell.RowNumber, randomCell.ColumnNumber].Enabled = false;
            if (game.Board.CheckWin(game.PlayerTurn, game.btnGrid))
            {
                game.WinEvent(_name, game.GameScreen);
            }
            else if(game.Board.CheckDraw())
            {
                game.DrawEvent();
            }
        }
        public void UpdateWins(Label scoreLabel)
        {
            _wins++;
            scoreLabel.Text = _name + ": " + _wins;
        }
        public int GetRandomThinkingTime()
        {
            //returns a random number between 2000 and 4000 (2 seconds - 4 seconds) to simulate real thinking
            Random rnd = new Random();
            return rnd.Next(2000, 4001);
        }
    }
}
