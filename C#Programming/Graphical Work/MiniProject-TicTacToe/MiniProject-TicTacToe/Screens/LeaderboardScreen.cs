using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniProject_TicTacToe.Leaderboard;

namespace MiniProject_TicTacToe
{
    public partial class LeaderboardScreen : Form
    {
        private DataGridView _dataGrid;
        public DataGridView _DataGrid { get => _dataGrid; set => _dataGrid = value; }
        public LeaderboardScreen()
        {
            InitializeComponent();
            LeaderboardDB leaderboard = new LeaderboardDB();
            leaderboard.DisplayDataGrid(this);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Hide();
            var gameScreen = new GameScreen();
            gameScreen.FormClosed += (s, args) => Close();
            gameScreen.Show();
        }
    }
}
