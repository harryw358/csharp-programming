using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MiniProject_TicTacToe.Enum;

namespace MiniProject_TicTacToe
{
    public partial class GameScreen : Form
    {
        private Game2 game;
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
            DisableControls();
            game = new Game2(Difficulty.None, "PVP", Convert.ToInt32(numberOfRounds_control.Value), this, txtPlayer01Name.Text.ToString(), txtPlayer02Name.Text.ToString());
            game.Start();
        }

        private void btnPlayPVE_Click(object sender, EventArgs e)
        {
            if (!rdoEasy.Checked && !rdoNormal.Checked && !rdoDifficult.Checked && !rdoExpert.Checked)
            {
                MessageBox.Show("Please choose a difficulty.");
            }
            if (numberOfRounds_control.Value < 3)
            {
                MessageBox.Show("Please select a number of rounds greater than 3.");
            }
            else
            {
                DisableControls();
                Difficulty chosenDifficulty = Difficulty.None;
                if (rdoEasy.Checked) chosenDifficulty = Difficulty.Easy;
                else if (rdoNormal.Checked) chosenDifficulty = Difficulty.Normal;
                else if (rdoDifficult.Checked) chosenDifficulty = Difficulty.Difficult;
                else if (rdoExpert.Checked) chosenDifficulty = Difficulty.Expert;
                game = new Game2(chosenDifficulty, "PVE", Convert.ToInt32(numberOfRounds_control.Value), this, txtHumanName.Text.ToString(), null);
                game.Start();
            }
        }
        private void DisableControls()
        {
            //makes controls unncessary for gameplay unusable
            label2.Visible = false;
            btnPlayPVP.Enabled = false;
            btnPlayPVE.Enabled = false;
            txtPlayer01Name.Enabled = false;
            txtPlayer02Name.Enabled = false;
            txtHumanName.Enabled = false;
            rdoEasy.Enabled = false;
            rdoNormal.Enabled = false;
            rdoDifficult.Enabled = false;
            rdoExpert.Enabled = false;
            rdoExpert.BackColor = Color.DarkGray;
            chkSpeedyMode.Enabled = false;
            numberOfRounds_control.Enabled = false;
        }
        public void EnableControls()
        {
            btnPlayPVP.Enabled = true;
            btnPlayPVE.Enabled = true;
            txtPlayer01Name.Enabled = true;
            txtPlayer02Name.Enabled = true;
            txtHumanName.Enabled = true;
            rdoEasy.Enabled = true;
            rdoNormal.Enabled = true;
            rdoDifficult.Enabled = true;
            rdoExpert.Enabled = true;
            rdoExpert.BackColor = Color.Black;
            chkSpeedyMode.Enabled = true;
            numberOfRounds_control.Enabled = true;
        }
        private void MakeLabels()
        {
            _currentTurn = new Label();
            _currentTurn.Location = new Point(5, 10);
            _currentTurn.Width = 270;
            _currentTurn.Height = 30;
            _currentTurn.ForeColor = Color.LightGray;
            _currentTurn.Font = new Font("Arial", 18, FontStyle.Bold);
            _currentTurn.Text = "PLAYER TURN";
            Controls.Add(_currentTurn);

            _player01Score = new Label();
            _player01Score.Location = new Point(8, 487);
            _player01Score.Width = 366;
            _player01Score.Height = 26;
            _player01Score.ForeColor = Color.LightGray;
            _player01Score.Font = new Font("Arial", 18);
            _player01Score.Text = "P1: ";
            Controls.Add(_player01Score);

            _player02Score = new Label();
            _player02Score.Location = new Point(8, 518);
            _player02Score.Width = 366;
            _player02Score.Height = 26;
            _player02Score.ForeColor = Color.LightGray;
            _player02Score.Font = new Font("Arial", 18);
            _player02Score.Text = "P2: ";
            Controls.Add(_player02Score);

            _drawScore = new Label();
            _drawScore.Location = new Point(6, 548);
            _drawScore.Width = 366;
            _drawScore.Height = 26;
            _drawScore.ForeColor = Color.LightGray;
            _drawScore.Font = new Font("Arial", 18);
            _drawScore.Text = "Draw: ";
            Controls.Add(_drawScore);

            _currentRound = new Label();
            _currentRound.Location = new Point(6, 576);
            _currentRound.Width = 366;
            _currentRound.Height = 26;
            _currentRound.ForeColor = Color.LightGray;
            _currentRound.Font = new Font("Arial", 18);
            _currentRound.Text = "Current round: ";
            Controls.Add(_currentRound);
        }
        public void ResetScoreLabelsText()
        {
            _player01Score.Text = "P1:";
            _player02Score.Text = "P2:";
            _drawScore.Text = "Draw:";
            _currentRound.Text = "Current round:";
            _currentTurn.Text = "PLAYER TURN";
        }
        public void ResetControls()
        {
            txtPlayer01Name.Text = "";
            txtPlayer02Name.Text = "";
            txtHumanName.Text = "";
            rdoEasy.Checked = false;
            rdoNormal.Checked = false;
            rdoDifficult.Checked = false;
            rdoExpert.Checked = false;
            chkSpeedyMode.Checked = false;
            numberOfRounds_control.Value = 3;
        }
    }
}
