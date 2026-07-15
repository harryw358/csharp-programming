using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FittingsStacks
{
    public partial class frmFittings : Form
    {
        Tyre[] tyres;
        Stack newFittings, previousFittings;
        int currentTyre;
        public frmFittings()
        {
            InitializeComponent();
        }

        private void frmFittings_Load(object sender, EventArgs e)
        {
            newFittings = new Stack();
            previousFittings = new Stack();

            tyres = new Tyre[5];
            tyres[0] = new Tyre("T100", 10, 36d);
            tyres[1] = new Tyre("D800", 4, 29d);
            tyres[2] = new Tyre("M300", 2, 48d);
            tyres[3] = new Tyre("L900", 23, 38d);
            tyres[4] = new Tyre("A600", 54, 54d);
            currentTyre = 0;

            UpdateValues();
        }

        private void btnPreviousTyre_Click(object sender, EventArgs e)
        {
            if (currentTyre == 0)
            {
                currentTyre = tyres.Length - 1;
            }
            else
            {
                currentTyre--;
            }
            UpdateValues();
        }

        private void btnNextTyre_Click(object sender, EventArgs e)
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
        private void btnRecordFitting_Click(object sender, EventArgs e)
        {
            if(txtCarReg.Text == "" || nudNumOfTyres.Value == 0 || txtFittingDate.Text == "")
            {
                MessageBox.Show("Please enter valid fitting details.");
            }
            else
            {
                Fitting currentFitting = new Fitting(txtCarReg.Text, txtFittingDate.Text, tyres[currentTyre].Type, Convert.ToInt32(nudNumOfTyres.Value), Convert.ToDouble(lblCost.Text.Substring(1)));
                newFittings.Push(currentFitting);

                MessageBox.Show("Fitting has been recorded.");
                Clear();
            }
        }
        private void btnPreviousFitting_Click(object sender, EventArgs e)
        {
            Fitting previousFitting = newFittings.Pop();
            previousFittings.Push(previousFitting);

            UpdateFittingValues(previousFitting);
        }

        private void btnMostRecentFitting_Click(object sender, EventArgs e)
        {
            Fitting mostRecentFitting = previousFittings.Pop();
            newFittings.Push(mostRecentFitting);
            UpdateFittingValues(mostRecentFitting);
        }

        private void btnAddNewStock_Click(object sender, EventArgs e)
        {
            tyres[currentTyre].AddNewStock(Convert.ToInt32(nudNewStock.Value));
            UpdateValues();
            nudNewStock.Value = 0;
        }
        private void Clear()
        {
            txtCarReg.Text = "";
            nudNumOfTyres.Value = 0;
            txtFittingDate.Text = "";
            lblTyreType.Text = tyres[currentTyre].Type;
        }
        private void nudNumOfTyres_valueChanged(object sender, EventArgs e)
        {
            lblCost.Text = (tyres[currentTyre].Price * Convert.ToDouble(nudNumOfTyres.Value)).ToString("C");
        }
        private void UpdateValues()
        {
            lblType.Text = tyres[currentTyre].Type;
            lblStockLeft.Text = tyres[currentTyre].StockLeft.ToString();
            lblPrice.Text = tyres[currentTyre].Price.ToString("C");
            lblTyreType.Text = tyres[currentTyre].Type;
            lblCost.Text = (tyres[currentTyre].Price * Convert.ToDouble(nudNumOfTyres.Value)).ToString("C");
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void UpdateFittingValues(Fitting currentFitting)
        {
            if (currentFitting == null)
            {
                return;
            }
            else
            {
                txtCarReg.Text = currentFitting.CarReg;
                nudNumOfTyres.Value = currentFitting.NumOfTyres;
                txtFittingDate.Text = currentFitting.FittingDate;
                lblTyreType.Text = currentFitting.TyreType;
            }
        }
    }
}
