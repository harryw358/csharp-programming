using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;

namespace MiniProject_TicTacToe
{
    public class Player
    {
        private string _name;
        private int _wins;
        private int _losses;
        private int _draws;
        private Label _scoreLabel;
        public string Name { get => _name; set => _name = value; }
        public int Wins { get => _wins; set => _wins = value; }
        public int Losses { get => _losses; set => _losses = value; }
        public int Draws { get => _draws; set => _draws = value; }
        public Label ScoreLabel { get => _scoreLabel; set => _scoreLabel = value; }
        public Player(string Name, Label scoreLabel)
        {
            _name = Name;
            _wins = 0;
            _losses = 0;
            _draws = 0;
            _scoreLabel = scoreLabel;
        }
        public void MakeMove(Game2 game)
        {
            if (game.PlayerTurn == 0)
            {
                game.ClickedButton.Text = "X";
                game.Board.Grid[game.Point.X, game.Point.Y].State = CellState.Player01;
            }
            else if (game.PlayerTurn == 1)
            {
                game.ClickedButton.Text = "O";
                game.Board.Grid[game.Point.X, game.Point.Y].State = CellState.Player02;
            }
            game.ClickedButton.Enabled = false;
            if (game.Board.CheckWin(game.PlayerTurn, game.btnGrid))
            {
                game.WinEvent(_name, game.GameScreen);
            }
            else if(game.Board.CheckDraw())
            {
                game.DrawEvent();
            }
        }
        public void UpdateWins()
        {
            _wins++;
            _scoreLabel.Text = _name + ": " + _wins; 
        }
    }
}
