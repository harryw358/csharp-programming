using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;

namespace MiniProject_TicTacToe
{
    public partial class GameScreen : Form
    {
        private Game game;
        private Panel _gridPanel;
        private Label _currentTurn;
        private Label _player01Score;
        private Label _player02Score;
        private Label _drawScore;
        private Label _currentRound;
        private bool _enabledSpeedyMode = false;
        public Panel GridPanel { get => _gridPanel; }
        public Label CurrentTurn { get => _currentTurn; }
        public Label Player01Score { get => _player01Score; }
        public Label Player02Score { get => _player02Score; }
        public Label DrawScore { get => _drawScore; }
        public Label CurrentRound { get => _currentRound; }
        public bool EnabledSpeedyMode { get => _enabledSpeedyMode; set => _enabledSpeedyMode = value; }
        public GameScreen()
        {
            InitializeComponent();
            _gridPanel = new Panel();
            _gridPanel.Width = 370;
            _gridPanel.Height = 370;
            _gridPanel.Location = new Point(8, 62);
            Controls.Add(_gridPanel);
            MakeLabels();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPlayPVP_Click(object sender, EventArgs e)
        {
            if (chkSpeedyMode.Checked)
            {
                _enabledSpeedyMode = true;
            }
            if (txtPlayer01Name.Text == txtPlayer02Name.Text || CheckNameIsValid(txtPlayer01Name.Text) || CheckNameIsValid(txtPlayer02Name.Text))
            {
                MessageBox.Show("You must enter usernames! Make sure that they are unique and contain no punctuation.");
                txtPlayer01Name.Text = "";
                txtPlayer02Name.Text = "";
                return;
            }
            else
            {
                _currentTurn.Visible = true;
                DisableControls();
                game = new Game(Difficulty.None, "PVP", Convert.ToInt32(numberOfRounds_control.Value), this, txtPlayer01Name.Text.ToString(), txtPlayer02Name.Text.ToString());
                game.Start();
            }
        }

        private void btnPlayPVE_Click(object sender, EventArgs e)
        {
            if (chkSpeedyMode.Checked)
            {
                _enabledSpeedyMode = true;
            }
            if (!rdoEasy.Checked && !rdoNormal.Checked && !rdoDifficult.Checked)
            {
                MessageBox.Show("Please choose a difficulty.");
                return;
            }
            if (CheckNameIsValid(txtHumanName.Text))
            {
                MessageBox.Show("You must enter usernames! Make sure that they are unique and contain no punctuation.");
                txtHumanName.Text = "";
                return;
            }
            else
            {
                _currentTurn.Visible = true;
                DisableControls();
                Difficulty chosenDifficulty = Difficulty.None;
                if (rdoEasy.Checked) chosenDifficulty = Difficulty.Easy;
                else if (rdoNormal.Checked) chosenDifficulty = Difficulty.Normal;
                else if (rdoDifficult.Checked) chosenDifficulty = Difficulty.Difficult;
                game = new Game(chosenDifficulty, "PVE", Convert.ToInt32(numberOfRounds_control.Value), this, txtHumanName.Text.ToString(), null);
                game.Start();
            }
        }
        private void DisableControls()
        {
            //makes controls unncessary for gameplay unusable
            label2.Visible = false;
            btnPlayPVP.Enabled = false;
            btnPlayPVE.Enabled = false;
            btnShowLeaderboard.Enabled = false;
            txtPlayer01Name.Enabled = false;
            txtPlayer02Name.Enabled = false;
            txtHumanName.Enabled = false;
            rdoEasy.Enabled = false;
            rdoNormal.Enabled = false;
            rdoDifficult.Enabled = false;
            chkSpeedyMode.Enabled = false;
            numberOfRounds_control.Enabled = false;
        }
        public void EnableControls()
        {
            btnPlayPVP.Enabled = true;
            btnPlayPVE.Enabled = true;
            btnShowLeaderboard.Enabled = true;
            txtPlayer01Name.Enabled = true;
            txtPlayer02Name.Enabled = true;
            txtHumanName.Enabled = true;
            rdoEasy.Enabled = true;
            rdoNormal.Enabled = true;
            rdoDifficult.Enabled = true;
            chkSpeedyMode.Enabled = true;
            numberOfRounds_control.Enabled = true;
        }
        private void MakeLabels()
        {
            _currentTurn = new Label();
            _currentTurn.Visible = false;
            _currentTurn.Location = new Point(5, 10);
            _currentTurn.Width = 270;
            _currentTurn.Height = 50;
            _currentTurn.ForeColor = Color.LightGray;
            _currentTurn.Font = new Font("Segoe Print", 16, FontStyle.Bold);
            _currentTurn.Text = "PLAYER TURN";
            Controls.Add(_currentTurn);

            _player01Score = new Label();
            _player01Score.Location = new Point(8, 487);
            _player01Score.Width = 366;
            _player01Score.Height = 26;
            _player01Score.ForeColor = Color.LightGray;
            _player01Score.Font = new Font("Segoe Print", 14);
            _player01Score.Text = "P1: ";
            Controls.Add(_player01Score);

            _player02Score = new Label();
            _player02Score.Location = new Point(8, 518);
            _player02Score.Width = 366;
            _player02Score.Height = 26;
            _player02Score.ForeColor = Color.LightGray;
            _player02Score.Font = new Font("Segoe Print", 14);
            _player02Score.Text = "P2: ";
            Controls.Add(_player02Score);

            _drawScore = new Label();
            _drawScore.Location = new Point(6, 548);
            _drawScore.Width = 366;
            _drawScore.Height = 26;
            _drawScore.ForeColor = Color.LightGray;
            _drawScore.Font = new Font("Segoe Print", 14);
            _drawScore.Text = "Draw: ";
            Controls.Add(_drawScore);

            _currentRound = new Label();
            _currentRound.Location = new Point(6, 576);
            _currentRound.Width = 366;
            _currentRound.Height = 26;
            _currentRound.ForeColor = Color.LightGray;
            _currentRound.Font = new Font("Segoe Print", 14);
            _currentRound.Text = "Current round: ";
            Controls.Add(_currentRound);
        }

        private void btnShowLeaderboard_Click(object sender, EventArgs e)
        {
            Hide();
            var leaderboardScreen = new LeaderboardScreen();
            leaderboardScreen.FormClosed += (s, args) => Close();
            leaderboardScreen.Show();
        }
        private bool CheckNameIsValid(string name)
        {
            int charCount = 0;
            foreach(char c in name)
            {
                charCount++;
                if (char.IsPunctuation(c))
                {
                    return true;
                }
            }
            if(charCount == 0)
            {
                return true;
            }
            return false;
        }
        public void UpdateScoreLabels(string player01Name, int player01Wins, string player02Name, int player02Wins)
        {
            _player01Score.Text = player01Name + ": " + player01Wins; 
            _player02Score.Text = player02Name + ": " + player02Wins;
        }
    }
}
