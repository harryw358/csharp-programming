using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Exercise4
{
    public partial class frmViewTyreStock : Form
    {
        public frmViewTyreStock()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Hide();
            var tyreFittings = new frmTyreFitting();
            tyreFittings.FormClosed += (s, args) => Close();
            tyreFittings.Show();
        }

        private void frmViewTyreStock_Load(object sender, EventArgs e)
        {
            var connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = TyresDatabase.mdb;";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            OleDbCommand command = null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable table = new DataTable();

            try
            {
                command = new OleDbCommand("SELECT * FROM TyreStockDb", conn);
                adapter.SelectCommand = command;
                adapter.Fill(table);

                grdRecord.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            command.Dispose();
            adapter.Dispose();
            table.Dispose();
        }
    }
}
