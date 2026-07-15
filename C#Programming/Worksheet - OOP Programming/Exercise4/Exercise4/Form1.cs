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
    public partial class frmTyreFitting : Form
    {
        Tyre[] tyres;
        int currentTyre = 0;
        public frmTyreFitting()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tyres = GetTyreStock();
            //tyres[0] = new Tyre("T100", 10, 36d);
            //tyres[1] = new Tyre("D800", 4, 29d);
            //tyres[2] = new Tyre("M300", 2, 48d);

            UpdateValues();
        }

        private void btnRecordFitting_Click(object sender, EventArgs e)
        {
            if(txtCarReg.Text == "" || nudNumOfTyres.Value == 0 || txtFittingDate.Text == "")
            {
                MessageBox.Show("Please enter valid details for the fitting.");
                return;
            }
            else
            {
                Fitting currentFitting = new Fitting(txtCarReg.Text, txtFittingDate.Text, tyres[currentTyre].Type, Convert.ToInt32(nudNumOfTyres.Value), Convert.ToDouble(lblCost.Text.Substring(1)));
                currentFitting.Record();
                tyres[currentTyre].RemoveStock(Convert.ToInt32(nudNumOfTyres.Value));
                UpdateValues();

                txtCarReg.Text = "";
                nudNumOfTyres.Value = 0;
                txtFittingDate.Text = "";
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(currentTyre == 0)
            {
                currentTyre = tyres.Length - 1;
            }
            else
            {
                currentTyre--;
            }
            UpdateValues();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentTyre == tyres.Length - 1)
            {
                currentTyre = 0;
            }
            else
            {
                currentTyre++;
            }
            UpdateValues();
        }
        private void UpdateValues()
        {
            lblType.Text = tyres[currentTyre].Type;
            lblStockLeft.Text = tyres[currentTyre].StockLeft.ToString();
            lblPrice.Text = tyres[currentTyre].Price.ToString("C");
            lblCost.Text = (tyres[currentTyre].Price * Convert.ToDouble(nudNumOfTyres.Value)).ToString("C");
        }

        private void nudNumOfTyres_valueChanged(object sender, EventArgs e)
        {
            lblCost.Text = (tyres[currentTyre].Price * Convert.ToDouble(nudNumOfTyres.Value)).ToString("C");
        }

        private void btnAddNewStock_Click(object sender, EventArgs e)
        {
            tyres[currentTyre].AddNewStock(Convert.ToInt32(nudNewStock.Value));
            UpdateValues();
            nudNewStock.Value = 0;
        }

        private void btnViewPreviousFittings_Click(object sender, EventArgs e)
        {
            Hide();
            var viewPreviousFittings = new frmViewPreviousFittings();
            viewPreviousFittings.FormClosed += (s, args) => Close();
            viewPreviousFittings.Show();
        }

        private void btnViewAllStock_Click(object sender, EventArgs e)
        {
            Hide();
            var viewTyreStock = new frmViewTyreStock();
            viewTyreStock.FormClosed += (s, args) => Close();
            viewTyreStock.Show();
        }

        private void btnCreateNewType_Click(object sender, EventArgs e)
        {
            Hide();
            var createNewTyreType = new frmCreateNewTyreType();
            createNewTyreType.FormClosed += (s, args) => Close();
            createNewTyreType.Show();
        }
        private Tyre[] GetTyreStock()
        {
            List<Tyre> tyres = new List<Tyre>();

            var connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = TyresDatabase.mdb;";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            OleDbCommand command = null;
            OleDbDataReader dataReader;

            try
            {
                command = new OleDbCommand("SELECT * FROM TyreStockDb", conn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string type = dataReader.GetFieldValue<string>(1);
                    int stockLeft = dataReader.GetFieldValue<int>(2);
                    decimal price = dataReader.GetFieldValue<decimal>(3);

                    Tyre tyre = new Tyre(type, stockLeft, Convert.ToDouble(price));
                    tyres.Add(tyre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.Dispose();

            return tyres.ToArray();
        }
    }
}
