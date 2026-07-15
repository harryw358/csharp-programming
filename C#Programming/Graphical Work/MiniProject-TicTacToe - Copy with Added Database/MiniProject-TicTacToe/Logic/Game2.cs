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
using System.Drawing;

namespace MiniProject_TicTacToe
{
    public class Game2
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
        private TextBox _txtTimeOutput;
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
        public TextBox txtTimeOutput { get => _txtTimeOutput; set => _txtTimeOutput = value; }

        public Game2(Difficulty difficulty, string mode, int numberOfRounds, GameScreen gameScreen, string player01Name, string player02Name)
        {
            _difficulty = difficulty;
            _mode = mode;
            _numberOfRounds = numberOfRounds;
            _gameScreen = gameScreen;

            _board = new Board(3);
            _btnGrid = new Button[_board.Size, _board.Size];
            gameScreen.DrawScore.Text = "Draws: " + _drawScore;

            if (mode == "PVP")
            {
                _players = new Player[2];
                _players = CreatePlayers_PVP(player01Name, player02Name);
                gameScreen.Player01Score.Text = player01Name + ": " + _players[0].Wins;
                gameScreen.Player02Score.Text = player02Name + ": " + _players[1].Wins;
            }
            else if (mode == "PVE")
            {
                _humanPlayer = CreatePlayer_PVE(player01Name);
                _AI = CreateAI_PVE();
                gameScreen.Player01Score.Text = player01Name + ": " + _humanPlayer.Wins;
                gameScreen.Player02Score.Text = _AI.Name + ": " + _AI.Wins;
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
                    btnGrid[i, j].Font = new Font("Arial", 50, FontStyle.Bold);
                    btnGrid[i, j].Click += HandleButtonClick;
                    btnGrid[i, j].Tag = new Point(i, j);
                    btnGrid[i, j].Location = new Point(i * btnSize, j * btnSize);
                    btnGrid[i, j].Text = "";
                    _gameScreen.GridPanel.Controls.Add(btnGrid[i, j]);
                }
            }
        }
        public async void HandleButtonClick(object sender, EventArgs e)
        {
            _clickedButton = (Button)sender;
            _point = (Point)_clickedButton.Tag;

            switch (_mode)
            {
                case "PVP":
                {
                    _players[_playerTurn].MakeMove(this);
                    UpdatePlayerTurn();
                }
                break;
                case "PVE":
                {
                    _humanPlayer.MakeMove(this);
                    UpdatePlayerTurn();
                    await Task.Delay(_AI.GetRandomThinkingTime());
                    _AI.MakeMove(this);
                    UpdatePlayerTurn();
                }
                break;
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
                case Difficulty.Expert:
                    return new ExpertAI();
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
            switch (_mode)
            {
                case "PVP":
                { 
                    _playerTurn = GenerateStartingPlayer(_players[0].Name, _players[1].Name);
                }
                break;
                case "PVE":
                {
                    _playerTurn = GenerateStartingPlayer(_humanPlayer.Name, _AI.Name);
                    if (_playerTurn == 1)
                    {
                        await Task.Delay(_AI.GetRandomThinkingTime());
                        _AI.MakeMove(this);
                        UpdatePlayerTurn();
                    }
                }
                break;
            }
        }
        public async void End()
        {
            await Task.Delay(1000);
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
                    ResetGridColor();
                }
            }
        }
        private void ResetGridColor()
        {
            for (int i = 0; i < _board.Size; i++)
            {
                for (int j = 0; j < _board.Size; j++)
                {
                    btnGrid[i, j].BackColor = Color.LightGray;
                }
            }
        }
        private int GenerateStartingPlayer(string name01, string name02)
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 2);
            if(num == 0)
            {
                _gameScreen.CurrentTurn.Text = name01 + "s turn";
            }
            else
            {
                _gameScreen.CurrentTurn.Text = name02 + "'s turn";
            }
            return num;   
        }
        public void UpdatePlayerTurn()
        {
            switch (_mode)
            {
                case "PVP":
                {
                    if(_playerTurn == 0)
                    {
                        _playerTurn = 1;
                        _gameScreen.CurrentTurn.Text = _players[1].Name + "'s turn";                    }
                    else if(_playerTurn == 1)
                    {
                        _playerTurn = 0;
                        _gameScreen.CurrentTurn.Text = _players[0].Name + "'s turm";
                    }
                }
                break;
                case "PVE":
                {
                    if(_playerTurn == 0)
                    {
                        _playerTurn = 1;
                        _gameScreen.CurrentTurn.Text = _AI.Name + "'s turn";
                    }
                    else if (_playerTurn == 1)
                    {
                        _playerTurn = 0;
                        _gameScreen.CurrentTurn.Text = _humanPlayer.Name + "'s turn";
                    }
                }
                break;
            }
        }
        private void StartNewRound()
        {
            _currentRound++;
            ResetBoardAndButtonGrid();
            _gameScreen.CurrentRound.Text = "Current round: " + _currentRound;
        }
        public void WinEvent(string name, GameScreen gameScreen)
        {
            MessageBox.Show(name + " has won!");
            switch (_mode)
            {
                case "PVP":
                {
                    _players[_playerTurn].UpdateWins();
                    if(_playerTurn == 0)
                    {
                        _players[_playerTurn + 1].Losses++;
                    }
                    else
                    {
                        _players[_playerTurn - 1].Losses++;
                    }
                }
                break;
                case "PVE":
                {
                    if (_playerTurn == 0)
                    {
                        _humanPlayer.UpdateWins();
                        _AI.Losses++;
                    }
                    else
                    {
                        _AI.UpdateWins(_gameScreen.Player02Score);
                        _humanPlayer.Losses++;
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
                CheckMatchWin();
            }
        }
        public void DrawEvent()
        {
            MessageBox.Show("It's a draw!");
            _drawScore++;
            _gameScreen.DrawScore.Text = "Draw: " + _drawScore;
            if(_currentRound != _numberOfRounds)
            {
                switch (_mode)
                {
                    case "PVP":
                        _players[_playerTurn].Draws++;
                        if (_playerTurn == 0)
                            _players[_playerTurn + 1].Draws++;
                        else
                            _players[_playerTurn - 1].Draws++;
                        break;
                    case "PVE":
                        _humanPlayer.Draws++;
                        _AI.Draws++;
                        break;
                }
                StartNewRound();
            }
            else
            {
                CheckMatchWin();
            }
        }
        private void CheckMatchWin()
        {
            switch (_mode)
            {
                case "PVP":
                {
                    if(_players[0].Wins > _players[1].Wins)
                    {
                        MatchWinEvent(_players[0].Name);
                    }
                    else if(_players[1].Wins > _players[0].Wins)
                    {
                        MatchWinEvent(_players[1].Name);
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
                    if(_humanPlayer.Wins > _AI.Wins)
                    {
                        MatchWinEvent(_humanPlayer.Name);
                    }
                    else if (_AI.Wins > _humanPlayer.Wins)
                    {
                        MatchWinEvent(_AI.Name);
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
        private void MatchWinEvent(string name)
        {
            MessageBox.Show(name + " has won this match!");
            End();
        }
    }
}
