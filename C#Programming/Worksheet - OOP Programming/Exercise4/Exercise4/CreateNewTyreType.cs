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
    public partial class frmCreateNewTyreType : Form
    {
        public frmCreateNewTyreType()
        {
            InitializeComponent();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            var connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = TyresDatabase.mdb;";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            OleDbCommand command = new OleDbCommand("INSERT into TyreStockDb (Type,StockLeft,Price) values('" + txtType.Text + "','" + nudStockLeft.Value + "','" + txtPrice.Text + "')", conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("The new type has been recorded.");

            Hide();
            var tyreFittings = new frmTyreFitting();
            tyreFittings.FormClosed += (s, args) => Close();
            tyreFittings.Show();
        }
    }
}
