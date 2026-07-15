using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksDatabase
{
    public partial class frmTitles : Form
    {
        OleDbConnection conn;
        OleDbCommand titlesCommand;
        OleDbDataAdapter titlesAdapter;
        DataTable titlesTable;
        CurrencyManager titlesManager;
        public frmTitles()
        {
            InitializeComponent();
        }

        private void frmTitles_Load(object sender, EventArgs e)
        {
            var connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\CS\C#Y1Programming\Introduction To SQL\Database (Connecting to a database)\1 Connecting to a database\2002 Books.mdb;";
            conn = new OleDbConnection(connString);
            conn.Open();
            titlesCommand = new OleDbCommand("Select * from Titles", conn);
            titlesAdapter = new OleDbDataAdapter();
            titlesAdapter.SelectCommand = titlesCommand;
            titlesTable = new DataTable();
            titlesAdapter.Fill(titlesTable);

            // bind controls
            txtTitle.DataBindings.Add("Text", titlesTable, "Title");
            txtYearPublished.DataBindings.Add("Text", titlesTable, "Year_published");
            txtISBN.DataBindings.Add("Text", titlesTable, "ISBN");
            txtPublisherID.DataBindings.Add("Text", titlesTable, "PubId");

            // establish currency manager
            titlesManager = (CurrencyManager)BindingContext[titlesTable];

            conn.Close();
            conn.Dispose();
            titlesAdapter.Dispose();
            titlesTable.Dispose();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            titlesManager.Position = 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            titlesManager.Position--;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            titlesManager.Position++;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            titlesManager.Position = titlesManager.Count - 1;
        }
    }
}
