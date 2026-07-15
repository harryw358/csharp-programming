using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MiniProject_TicTacToe.Logic
{
    public class TimeLimit
    {
        private System.Windows.Forms.Timer aTimer;
        private int _timeLeft;
        private Game _game;
        private Label _lblTimeLeft;

        public int TimeLeft { get => _timeLeft; set => _timeLeft = value; }
        public Label lblTimeLeft { get => _lblTimeLeft; set => _lblTimeLeft = value; }
        public TimeLimit(Game game)
        {
            _lblTimeLeft = game.lblTimeLeft;

            _game = game;

            aTimer = new Timer();
            aTimer.Interval = 1000;
            aTimer.Tick += HandleTimer;
        }

        private void HandleTimer(object sender, EventArgs e)
        {
            if (_timeLeft == 0)
            {
                MakeRandomMove();
                ResetTimer();
                _game.UpdatePlayerTurn();
            }
            else
            {
                _timeLeft--;
                _lblTimeLeft.Text = _lblTimeLeft.Text = _timeLeft + "s";
            }
        }
        public void StartTimer()
        {
            _timeLeft = 5;
            _lblTimeLeft.Text = _timeLeft + "s";
            aTimer.Start();
        }
        public void StopTimer()
        {
            aTimer.Stop();
        }
        public void ResetTimer()
        {
            _timeLeft = 5;
            _lblTimeLeft.Text = _timeLeft + "s";
            aTimer.Start();
        }
        private void MakeRandomMove()
        {
            if (_game.Mode == "PVP")
            {
                _game.Players[_game.PlayerTurn].MakeRandomMove(_game);
            }
            else
            {
                _game.HumanPlayer.MakeRandomMove(_game);
            }
            if (_game.Board.CheckWin(_game.PlayerTurn, _game.btnGrid))
            {
                _game.WinEvent(_game.Players[_game.PlayerTurn].Name, _game.GameScreen);
            }
            else if (_game.Board.CheckDraw())
            {
                _game.DrawEvent();
            }
        }
    }
}
