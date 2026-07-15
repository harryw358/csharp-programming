using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;
using System.Timers;
using MiniProject_TicTacToe.Leaderboard;

namespace MiniProject_TicTacToe.Players.AI
{
    public abstract class TemplateAI
    {
        protected string _name;
        private int _roundWins;
        private int _roundLosses;
        private int _roundDraws;
        private int _bestOfWins;
        private LeaderboardDB leaderboardDB;

        public string Name { get => _name; set => _name = value; }
        public int RoundWins { get => _roundWins; set => _roundWins = value; }
        public int RoundLosses { get => _roundLosses; set => _roundLosses = value; }
        public int RoundDraws { get => _roundDraws; set => _roundDraws = value; }
        public int BestOfWins { get => _bestOfWins; set => _bestOfWins = value; }

        public TemplateAI()
        {
            _name = null;
            _roundWins = 0;
            _roundLosses = 0;
            _roundDraws = 0;
            _bestOfWins = 0;
            leaderboardDB = new LeaderboardDB();
        }
        public abstract Cell CalculateMove(Game game);
        public void MakeMove(Game game)
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
            if (game.GameScreen.EnabledSpeedyMode)
            {
                game.SpeedyMode.ResetTimer();
                game.SpeedyMode.lblTimeLeft.Text = game.SpeedyMode.TimeLeft + "s";
            }
        }
        protected bool SimulateMove(Game game, Cell currentCell, CellState state, string symbol, int playerTurn)
        {
            // Pretends to be the human player or tries to win itself

            currentCell.State = state;
            game.btnGrid[currentCell.RowNumber, currentCell.ColumnNumber].Text = symbol;
            if (game.Board.CheckWin(playerTurn, game.btnGrid))
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
        public void UpdateWins(Label scoreLabel)
        {
            _roundWins++;
            scoreLabel.Text = _name + ": " + _roundWins;
        }
        public int GetRandomThinkingTime()
        {
            // returns a random number between 2000 and 4000 (2 seconds - 4 seconds) to simulate real thinking

            Random rnd = new Random();
            return rnd.Next(2000, 4001);
        }
        public void AddScoresToDatabase()
        {
            leaderboardDB.WriteData(_name, _roundWins, _roundLosses, _roundDraws, _bestOfWins);
        }
    }
}
