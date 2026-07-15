using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;
using MiniProject_TicTacToe.Players;
using MiniProject_TicTacToe.Players.AI;
using MiniProject_TicTacToe.Logic;
using System.Drawing;

namespace MiniProject_TicTacToe
{
    public class Game
    {
        private Board _board;
        private Button[,] _btnGrid;
        private Player[] _players;
        private TemplateAI _AI;
        private Player _humanPlayer;
        private int _playerTurn;
        private Difficulty _difficulty;
        private string _mode;
        private int _currentRound;
        private int _numberOfRounds;
        private int _drawScore;
        private GameScreen _gameScreen;
        private Button _clickedButton;
        private Point _point;
        private TimeLimit _speedyMode;
        private Label _lblTimeLeft;

        public Board Board { get => _board; }
        public Button[,] btnGrid { get => _btnGrid; }
        public Player[] Players { get => _players; }
        public TemplateAI AI { get => _AI; }
        public Player HumanPlayer { get => _humanPlayer; }
        public int PlayerTurn { get => _playerTurn; }
        public string Mode { get => _mode; }
        public int CurrentRound { get => _currentRound; set => _currentRound = value; }
        public int NumberOfRounds { get => _numberOfRounds;}
        public int DrawScore { get => _drawScore; set => _drawScore = value; }
        public GameScreen GameScreen { get => _gameScreen; }
        public Button ClickedButton { get => _clickedButton; set => _clickedButton = value; }
        public Point Point { get => _point; set => _point = value; }
        public TimeLimit SpeedyMode { get => _speedyMode; set => _speedyMode = value; }
        public Label lblTimeLeft { get => _lblTimeLeft; set => _lblTimeLeft = value; }

        public Game(Difficulty difficulty, string mode, int numberOfRounds, GameScreen gameScreen, string player01Name, string player02Name)
        {
            _difficulty = difficulty;
            _mode = mode;
            _numberOfRounds = numberOfRounds;
            _gameScreen = gameScreen;
            if (_gameScreen.EnabledSpeedyMode)
            {
                _lblTimeLeft = CreateTimeLeftLabel();
                _gameScreen.Controls.Add(_lblTimeLeft);
                _speedyMode = new TimeLimit(this);
                _speedyMode.StartTimer();
            }

            _board = new Board(3);
            _btnGrid = new Button[_board.Size, _board.Size];
            gameScreen.DrawScore.Text = "Draws: " + _drawScore;

            if (mode == "PVP")
            {
                _players = new Player[2];
                _players = CreatePlayers_PVP(player01Name, player02Name);
                gameScreen.UpdateScoreLabels(player01Name, _players[0].RoundWins, player02Name, _players[1].RoundWins);
            }
            else
            {
                _humanPlayer = CreatePlayer_PVE(player01Name);
                _AI = CreateAI_PVE();
                gameScreen.UpdateScoreLabels(player01Name, _humanPlayer.RoundWins, _AI.Name, _AI.RoundWins);
            }
        }
        private void PopulateGrid()
        {
            int btnSize = _gameScreen.GridPanel.Width / _board.Size;
            for (int i = 0; i < _board.Size; i++)
            {
                for (int j = 0; j < _board.Size; j++)
                {
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].TabStop = false;
                    btnGrid[i, j].BackColor = Color.LightGray;
                    btnGrid[i, j].Height = btnSize;
                    btnGrid[i, j].Width = btnSize;
                    btnGrid[i, j].Font = new Font("Segoe Print", 50, FontStyle.Bold);
                    btnGrid[i, j].Click += HandleButtonClick;
                    btnGrid[i, j].Tag = new Point(i, j);
                    btnGrid[i, j].Location = new Point(i * btnSize, j * btnSize);
                    btnGrid[i, j].Text = "";
                    _gameScreen.GridPanel.Controls.Add(btnGrid[i, j]);
                }
            }
        }
        private async void HandleButtonClick(object sender, EventArgs e)
        {
            _clickedButton = (Button)sender;
            _point = (Point)_clickedButton.Tag;

            if(_mode == "PVE")
            {
                _humanPlayer.MakeMove(this);
                UpdatePlayerTurn();
                if (_gameScreen.EnabledSpeedyMode)
                {
                    _speedyMode.ResetTimer();
                    _speedyMode.lblTimeLeft.Text = _speedyMode.TimeLeft + "s";
                }
                await Task.Delay(_AI.GetRandomThinkingTime());
                _AI.MakeMove(this);
                UpdatePlayerTurn();
            }
            else
            {
                _players[_playerTurn].MakeMove(this);
                UpdatePlayerTurn();
            }
            if (_gameScreen.EnabledSpeedyMode)
            {
                _speedyMode.ResetTimer();
                _speedyMode.lblTimeLeft.Text = _speedyMode.TimeLeft + "s";
            }
        }
        public Player[] CreatePlayers_PVP(string player01Name, string player02Name)
        {
            Player[] players = new Player[2];
            players[0] = new Player(player01Name, _gameScreen.Player01Score);
            players[1] = new Player(player02Name, _gameScreen.Player02Score);
            return players;
        }
        public Player CreatePlayer_PVE(string name)
        {
            return new Player(name, _gameScreen.Player01Score);
        }
        public TemplateAI CreateAI_PVE()
        {
            switch (_difficulty)
            {
                case Difficulty.Easy:
                    return new EasyAI();
                case Difficulty.Normal:
                    return new NormalAI();
                case Difficulty.Difficult:
                    return new DifficultAI();
                default:
                    return null;
            }
        }
        public async void Start()
        {
            _currentRound = 1;
            _gameScreen.CurrentRound.Text = "Current round: " + _currentRound.ToString();
            _gameScreen.GridPanel.Visible = true;
            PopulateGrid();

            if(_mode == "PVE")
            {
                _playerTurn = GenerateStartingPlayer(_humanPlayer.Name, _AI.Name);
                if (_playerTurn == 1)
                {
                    await Task.Delay(_AI.GetRandomThinkingTime());
                    _AI.MakeMove(this);
                    UpdatePlayerTurn();
                }
            }
            else
            {
                _playerTurn = GenerateStartingPlayer(_players[0].Name, _players[1].Name);
            }
        }
        public async void End()
        {
            if(_mode == "PVE")
            {
                _humanPlayer.AddScoresToDatabase();
                _AI.AddScoresToDatabase();
            }
            else
            {
                _players[0].AddScoresToDatabase();
                _players[1].AddScoresToDatabase();
            }
            await Task.Delay(500);
            DestroyGame();
        }
        private void DestroyGame()
        {
            Application.Restart();
        }
        private void ResetBoardAndButtonGrid()
        {
            for (int i = 0; i < _board.Size; i++)
            {
                for (int j = 0; j < _board.Size; j++)
                {
                    _board.Grid[i, j].State = CellState.Empty;
                    _btnGrid[i, j].Text = "";
                    _btnGrid[i, j].Enabled = true;
                    _board.ResetGridColor(_btnGrid);
                }
            }
        }
        private int GenerateStartingPlayer(string name01, string name02)
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 2);
            string[] names = new string[2] { name01, name02 };
            _gameScreen.CurrentTurn.Text = names[num] + "'s turn";
            return num;   
        }
        public void UpdatePlayerTurn()
        {
            if (_playerTurn == 0)
            {
                _playerTurn = 1;
                if (_mode == "PVE")
                {
                    _gameScreen.CurrentTurn.Text = _AI.Name + "'s turn";
                }
                else
                {
                    _gameScreen.CurrentTurn.Text = _players[1].Name + "'s turn";
                }
            }
            else
            {
                _playerTurn = 0;
                if (_mode == "PVE")
                {
                    _gameScreen.CurrentTurn.Text = _humanPlayer.Name + "'s turn";
                }
                else
                {
                    _gameScreen.CurrentTurn.Text = _players[0].Name + "'s turn";
                }
            }
        }
        private void StartNewRound()
        {
            if (_gameScreen.EnabledSpeedyMode)
            {
                _speedyMode.ResetTimer();
            }
            _currentRound++;
            ResetBoardAndButtonGrid();
            _gameScreen.CurrentRound.Text = "Current round: " + _currentRound;
        }
        public void WinEvent(string name, GameScreen gameScreen)
        {
            if (_gameScreen.EnabledSpeedyMode)
            {
                _speedyMode.StopTimer();
            }
            MessageBox.Show(name + " has won!");
            switch (_mode)
            {
                case "PVP":
                {
                    _players[_playerTurn].UpdateWins();
                    if(_playerTurn == 0)
                    {
                        _players[_playerTurn + 1].RoundLosses++;
                    }
                    else
                    {
                        _players[_playerTurn - 1].RoundLosses++;
                    }
                }
                break;
                case "PVE":
                {
                    if (_playerTurn == 0)
                    {
                        _humanPlayer.UpdateWins();
                        _AI.RoundLosses++;
                    }
                    else
                    {
                        _AI.UpdateWins(_gameScreen.Player02Score);
                        _humanPlayer.RoundLosses++;
                    }
                }
                break;
            }
            if (_currentRound != _numberOfRounds)
            {
                StartNewRound();
            }
            else
            {
                CheckWholeGameWin();
            }
        }
        public void DrawEvent()
        {
            if (_gameScreen.EnabledSpeedyMode)
            {
                _speedyMode.StopTimer();
            }
            MessageBox.Show("It's a draw!");
            _drawScore++;
            _gameScreen.DrawScore.Text = "Draw: " + _drawScore;
            if(_currentRound != _numberOfRounds)
            {
                switch (_mode)
                {
                    case "PVP":
                        _players[_playerTurn].RoundDraws++;
                        if (_playerTurn == 0)
                            _players[_playerTurn + 1].RoundDraws++;
                        else
                            _players[_playerTurn - 1].RoundDraws++;
                        break;
                    case "PVE":
                        _humanPlayer.RoundDraws++;
                        _AI.RoundDraws++;
                        break;
                }
                StartNewRound();
            }
            else
            {
                CheckWholeGameWin();
            }
        }
        private void CheckWholeGameWin()
        {
            switch (_mode)
            {
                case "PVP":
                {
                    if(_players[0].RoundWins > _players[1].RoundWins)
                    {
                        BestOfWinEvent(_players[0].Name);
                    }
                    else if(_players[1].RoundWins > _players[0].RoundWins)
                    {
                        BestOfWinEvent(_players[1].Name);
                    }
                    else
                    {
                        MessageBox.Show("Neither player has won this match.");
                        End();
                    }
                }
                break;
                case "PVE":
                {
                    if(_humanPlayer.RoundWins > _AI.RoundWins)
                    {
                        BestOfWinEvent(_humanPlayer.Name);
                    }
                    else if (_AI.RoundWins > _humanPlayer.RoundWins)
                    {
                        BestOfWinEvent(_AI.Name);
                    }
                    else
                    {
                        MessageBox.Show("Neither player has won this match.");
                        End();
                    }
                }
                break;
            }
        }
        private void BestOfWinEvent(string name)
        {
            MessageBox.Show(name + " is the big winner!");
            if(_mode == "PVP")
            {
                if(_players[0].RoundWins > _players[1].RoundWins)
                {
                    _players[0].BestOfWins++;
                }
                else if(_players[1].RoundWins > _players[0].RoundWins)
                {
                    _players[1].BestOfWins++;
                }
            }
            else
            {
                if(_humanPlayer.RoundWins > _AI.RoundWins)
                {
                    _humanPlayer.BestOfWins++;
                }
                else if(_AI.RoundWins > _humanPlayer.RoundWins)
                {
                    _AI.BestOfWins++;
                }
            }
            End();
        }
        private Label CreateTimeLeftLabel()
        {
            Label lblTimeLeft = new Label();
            lblTimeLeft.Location = new Point(300, 3);
            lblTimeLeft.Height = 50;
            lblTimeLeft.Font = new Font("Segoe Print", 20, FontStyle.Bold);
            lblTimeLeft.ForeColor = Color.LightGray;
            return lblTimeLeft;
        }
    }
}
