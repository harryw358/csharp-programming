using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data.SQLite;
using MiniProject_TicTacToe.Players;
using System.Collections.Generic;

namespace MiniProject_TicTacToe.Leaderboard
{
    public class LeaderboardDB
    {
        private const string PATH = "data_table.db";
        private string CONNECTION_STRING = @"URI=file:" + Application.StartupPath + "\\data_table.db";
        
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader dataReader;

        private DataGridView dataGrid;
        private List<Player> records;

        public LeaderboardDB()
        {
            // creates data grid view to display text
            CreateDataGrid();
            CreateTable();
            records = new List<Player>();
        }
        public void DisplayDataGrid(LeaderboardScreen leaderboardScreen)
        {
            leaderboardScreen.Controls.Add(dataGrid);

            // creates table in database and shows data
            ShowData();
            SortHighestToLowest();
        }
        private void CreateDataGrid()
        {
            dataGrid = new DataGridView();
            dataGrid.Width = 693;
            dataGrid.Height = 350;
            dataGrid.Location = new Point(12, 70); //12, 93
            dataGrid.AllowUserToAddRows = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewTextBoxColumn NameColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn RoundWinsColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn RoundLossesColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn RoundDrawsColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn BestOfWinsColumn = new DataGridViewTextBoxColumn();

            NameColumn.HeaderText = "Name";
            RoundWinsColumn.HeaderText = "Wins";
            RoundLossesColumn.HeaderText = "Losses";
            RoundDrawsColumn.HeaderText = "Draws";
            BestOfWinsColumn.HeaderText = "Best of Wins:";

            var headerCellStyle = new DataGridViewCellStyle();
            headerCellStyle.Font = new Font("Segoe Print", 12, FontStyle.Bold);
            var cellStyle = new DataGridViewCellStyle();
            cellStyle.Font = new Font("Segoe Print", 10);

            dataGrid.Columns.AddRange(NameColumn, RoundWinsColumn, RoundLossesColumn, RoundDrawsColumn, BestOfWinsColumn);
            dataGrid.ColumnHeadersDefaultCellStyle = headerCellStyle;
            dataGrid.DefaultCellStyle = cellStyle;

            for(int i = 0; i < 5; i++)
            {
                dataGrid.Columns[i].Width = 130;
                dataGrid.ColumnHeadersHeight = 50;
            }
        }
        private void ShowData()
        {
            // creates a new connection to the database
            connection = new SQLiteConnection(CONNECTION_STRING);
            connection.Open();

            // this is the query that will run
            string query = "SELECT * FROM scores";
            command = new SQLiteCommand(query, connection);
            dataReader = command.ExecuteReader();

            // fills in the data grid view with the data in the database
            while (dataReader.Read())
            {
                dataGrid.Rows.Insert(0, dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));
            }
        }
        private void FillList()
        {
            // creates a new connection to the database
            connection = new SQLiteConnection(CONNECTION_STRING);
            connection.Open();

            // this is the query that will run
            string query = "SELECT * FROM scores";
            command = new SQLiteCommand(query, connection);
            dataReader = command.ExecuteReader();

            // fills in the list with the data in the database
            while (dataReader.Read())
            {
                Player player = new Player(null, null);
                player.Name = dataReader.GetString(0);
                player.RoundWins = Convert.ToInt32(dataReader.GetString(1));
                player.RoundLosses = Convert.ToInt32(dataReader.GetString(2));
                player.RoundDraws = Convert.ToInt32(dataReader.GetString(3));
                player.BestOfWins = Convert.ToInt32(dataReader.GetString(4));
                records.Add(player);
            }
        }
        private void CreateTable()
        {
            // if a database file does not already exist it 
            // will create a new one and make a table with
            // the required fields. If a file does exist it
            // will return nothing as the ShowData method will
            // find it

            if (!File.Exists(PATH))
            {
                try
                {
                    SQLiteConnection.CreateFile(PATH);
                    using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                    {
                        connection.Open();
                        string commandText = "create table scores(name varchar(15), roundWins varchar(15), roundLosses varchar(15), roundDraws varchar(15), bestOfWins varchar(15))";
                        command = new SQLiteCommand(commandText, connection);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Database cannot be created.");
                    return;
                }
            }
            else
            {   
                return;
            }
        }
        public void InsertData(string name, int roundWins, int roundLosses, int roundDraws, int bestOfWins)
        {
            // This will insert a single record
            // at a time, including the fields
            // name, wins, losses and draws

            connection = new SQLiteConnection(CONNECTION_STRING);
            connection.Open();
            command = new SQLiteCommand(connection);

            try
            {
                command.CommandText = "INSERT INTO scores(name, roundWins, roundLosses, roundDraws, bestOfWins) VALUES(@name, @roundWins, @roundLosses, @roundDraws, @bestOfWins)";

                string NAME = name;
                string ROUNDWINS = Convert.ToString(roundWins);
                string ROUNDLOSSES = Convert.ToString(roundLosses);
                string ROUNDDRAWS = Convert.ToString(roundDraws);
                string BESTOFWINS = Convert.ToString(bestOfWins);

                command.Parameters.AddWithValue("@name", NAME);
                command.Parameters.AddWithValue("@roundWins", ROUNDWINS);
                command.Parameters.AddWithValue("@roundLosses", ROUNDLOSSES);
                command.Parameters.AddWithValue("@roundDraws", ROUNDDRAWS);
                command.Parameters.AddWithValue("@bestofWins", BESTOFWINS);

                dataGrid.ColumnCount = 5;
                dataGrid.Columns[0].Name = "Name";
                dataGrid.Columns[1].Name = "Round Wins";
                dataGrid.Columns[2].Name = "Round Losses";
                dataGrid.Columns[3].Name = "Round Draws";
                dataGrid.Columns[4].Name = "Best of Wins:";
                string[] row = new string[] { NAME, ROUNDWINS, ROUNDLOSSES, ROUNDDRAWS, BESTOFWINS };
                dataGrid.Rows.Add(row);
                command.ExecuteNonQuery();
                            
            }
            catch (Exception)
            {
                MessageBox.Show("Could not insert data into database.");
                return;
            }
        }
        public void SortHighestToLowest()
        {
            // get the latest update of the leaderboard in data grid form
            // add any scores that need to be added
            // get all the wins from each row
            // sort the wins from highest to lowest and keep track of entire record
            // place these into a temporary array and redraw the datagrid

            for(int i = 0; i < dataGrid.RowCount; i++)
            {
                // for every row in data grid
                for(int j = i + 1; j < dataGrid.RowCount; j++)
                {
                    if (Convert.ToInt32(dataGrid[1, i].Value) > Convert.ToInt32(dataGrid[1, j].Value))
                    {
                        // switches positions of names
                        var temp = dataGrid[0, j].Value;
                        dataGrid[0, j].Value = dataGrid[0, i].Value;
                        dataGrid[0, i].Value = temp;
                        // switches position of wins
                        temp = dataGrid[1, j].Value;
                        dataGrid[1, j].Value = dataGrid[1, i].Value;
                        dataGrid[1, i].Value = temp;
                        // switches positions of losses
                        temp = dataGrid[2, j].Value;
                        dataGrid[2, j].Value = dataGrid[2, i].Value;
                        dataGrid[2, i].Value = temp;
                        // switches positions of draws
                        temp = dataGrid[3, j].Value;
                        dataGrid[3, j].Value = dataGrid[3, i].Value;
                        dataGrid[3, i].Value = temp;
                        // switches positions of whole game wins
                        temp = dataGrid[4, j].Value;
                        dataGrid[4, j].Value = dataGrid[4, i].Value;
                        dataGrid[4, i].Value = temp;
                    }
                }
            }
        }
        public bool CheckForExistingRecord(string name)
        {
            FillList();
            for (int currentRecord = 0; currentRecord < records.Count; currentRecord++)
            {
                if(records[currentRecord].Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void WriteData(string name, int roundWins, int roundLosses, int roundDraws, int bestOfWins)
        {
            if (CheckForExistingRecord(name))
            {
                // Updates existing record
                connection = new SQLiteConnection(CONNECTION_STRING);
                connection.Open();
                command = new SQLiteCommand(connection);

                int[] existingScores = new int[4]; // { WINS, LOSSES, DRAWS, BEST OF WINS }
                for(int currentRecord = 0; currentRecord < records.Count; currentRecord++)
                {
                    if (records[currentRecord].Name == name)
                    {
                        existingScores[0] = records[currentRecord].RoundWins;
                        existingScores[1] = records[currentRecord].RoundLosses;
                        existingScores[2] = records[currentRecord].RoundDraws;
                        existingScores[3] = records[currentRecord].BestOfWins;
                    }
                }

                string NAME = name;
                string ROUNDWINS = (roundWins + existingScores[0]).ToString();
                string ROUNDLOSSES = (roundLosses + existingScores[1]).ToString();
                string ROUNDDRAWS = (roundDraws + existingScores[2]).ToString();
                string BESTOFWINS = (bestOfWins + existingScores[3]).ToString();

                try
                {
                    command.CommandText = "UPDATE scores SET name=@NAME, roundWins=@ROUNDWINS, roundLosses=@ROUNDLOSSES, roundDraws=@ROUNDDRAWS, bestOfWins=@BESTOFWINS WHERE name=@NAME";
                    command.Parameters.AddWithValue("@name", NAME);
                    command.Parameters.AddWithValue("@roundWins", ROUNDWINS);
                    command.Parameters.AddWithValue("@roundLosses", ROUNDLOSSES);
                    command.Parameters.AddWithValue("@roundDraws", ROUNDDRAWS);
                    command.Parameters.AddWithValue("@bestOfWins", BESTOFWINS);

                    command.ExecuteNonQuery();
                    dataGrid.Rows.Clear();
                    ShowData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not update data in database.");
                    return;
                }
            }
            else
            {
                // Uses insert data method
                InsertData(name, roundWins, roundLosses, roundDraws, bestOfWins);
            }
        }
    }
}
