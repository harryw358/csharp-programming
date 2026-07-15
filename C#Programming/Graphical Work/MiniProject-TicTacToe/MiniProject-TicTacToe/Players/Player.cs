using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;
using MiniProject_TicTacToe.Leaderboard;

namespace MiniProject_TicTacToe.Players
{
    public class Player
    {
        private string _name;
        private int _roundWins;
        private int _roundLosses;
        private int _roundDraws;
        private int _bestOfWins;
        private Label _scoreLabel;
        private LeaderboardDB leaderboardDB;
        
        public string Name { get => _name; set => _name = value; }
        public int RoundWins { get => _roundWins; set => _roundWins = value; }
        public int RoundLosses { get => _roundLosses; set => _roundLosses = value; }
        public int RoundDraws { get => _roundDraws; set => _roundDraws = value; }
        public int BestOfWins { get => _bestOfWins; set => _bestOfWins = value; }
        public Label ScoreLabel { get => _scoreLabel; set => _scoreLabel = value; }
        public Player(string Name, Label scoreLabel)
        {
            _name = Name;
            _roundWins = 0;
            _roundLosses = 0;
            _roundDraws = 0;
            _bestOfWins = 0;
            _scoreLabel = scoreLabel;
            leaderboardDB = new LeaderboardDB();
        }
        public void MakeMove(Game game)
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
        public void MakeRandomMove(Game game)
        { 
            Cell randomCell = game.Board.GetRandomEmptyCell();
            if (game.PlayerTurn == 0)
            {
                randomCell.State = CellState.Player01;
                game.btnGrid[randomCell.RowNumber, randomCell.ColumnNumber].Text = "X";
            }
            else if(game.PlayerTurn == 1)
            {
                randomCell.State = CellState.Player02;
                game.btnGrid[randomCell.RowNumber, randomCell.ColumnNumber].Text = "O";
            }
            game.btnGrid[randomCell.RowNumber, randomCell.ColumnNumber].Enabled = false;
            if (game.Board.CheckWin(game.PlayerTurn, game.btnGrid))
            {
                game.WinEvent(_name, game.GameScreen);
            }
            else if (game.Board.CheckDraw())
            {
                game.DrawEvent();
            }
        }
        public void UpdateWins()
        {
            _roundWins++;
            _scoreLabel.Text = _name + ": " + _roundWins; 
        }
        public void AddScoresToDatabase()
        {
            leaderboardDB.WriteData(_name, _roundWins, _roundLosses, _roundDraws, _bestOfWins);
        }
    }
}
