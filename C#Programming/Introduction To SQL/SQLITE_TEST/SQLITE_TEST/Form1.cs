using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace SQLITE_TEST
{
    public partial class Form1 : Form
    {
        // path of database
        string path = "data_table.db";
        string connectionString = @"URI=file:" + Application.StartupPath + "\\data_table.db";

        SQLiteConnection connection;
        SQLiteCommand command;
        SQLiteDataReader dataReader;
        public Form1()
        {
            InitializeComponent();
        }

        // show data in table
        private void DataShow()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();

            string stm = "SELECT * FROM test";
            var command = new SQLiteCommand(stm, connection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                dataGridView1.Rows.Insert(0, dataReader.GetString(0), dataReader.GetString(1));
            }   
        }

        // create database and table
        private void CreateDatabase()
        {
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "create table test(name varchar(20),id varchar(12))";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Database cannot be created.");
                return;
            }
        }

        //  insert data
        private void btnInsert_Click(object sender, EventArgs e)
        {
            var cnn = new SQLiteConnection(connectionString);
            cnn.Open();
            var command = new SQLiteCommand(cnn);

            try
            {
                command.CommandText = "INSERT INTO test(name,id) VALUES(@name,@id)";

                string NAME = txtName.Text;
                string ID = txtID.Text;

                command.Parameters.AddWithValue("@name", NAME);
                command.Parameters.AddWithValue("@id", ID);

                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Name";
                dataGridView1.Columns[1].Name = "Id";
                string[] row = new string[] { NAME, ID };
                dataGridView1.Rows.Add(row);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Could not insert data into database.");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDatabase();
            DataShow();
        }

        // update data
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var cnn = new SQLiteConnection(connectionString);
            cnn.Open();

            var command = new SQLiteCommand(cnn);

            try
            {
                command.CommandText = "UPDATE test Set id=@Id WHERE name=@NAME";
                command.Prepare();
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Id", txtID.Text);

                command.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
                DataShow();
            }
            catch (Exception)
            {
                Console.WriteLine("Could not update data in the database.");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();

            var command = new SQLiteCommand(connection);

            try
            {
                command.CommandText = "DELETE FROM test WHERE name=@Name";
                command.Prepare();
                command.Parameters.AddWithValue("@Name", txtName.Text);

                command.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
                DataShow();
            }
            catch (Exception)
            {
                Console.WriteLine("Could not delete data from database.");
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
            }
        }
    }
}
