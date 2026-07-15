using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        //global variables
        string sign;
        double val1;
        double val2;
        int trackkeypoint = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void cmd0_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd0.Text;
        }

        private void cmd1_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd1.Text;
        }

        private void cmd2_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd2.Text;
        }

        private void cmd3_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd3.Text;
        }

        private void cmd4_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd4.Text;
        }

        private void cmd5_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd5.Text;
        }

        private void cmd6_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd6.Text;
        }

        private void cmd7_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd7.Text;
        }

        private void cmd8_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd8.Text;
        }

        private void cmd9_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + cmd9.Text;
        }

        private void cmdCos_Click(object sender, EventArgs e)
        {
            double v;
            v = double.Parse(txtBox.Text);
            txtBox.Text = Math.Cos(v).ToString();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtBox.Text = "";
            val1 = 0;
            val2 = 0;
            sign = "";
        }

        private void cmdEqual_Click(object sender, EventArgs e)
        {
            val2 = double.Parse(txtBox.Text);
            double result;
            if(sign == "+")
            {
                result = val1 + val2;
                txtBox.Text = result.ToString();
            }
            else if(sign == "-")
            {
                result = val1 - val2;
                txtBox.Text = result.ToString();
            }
            else if (sign == "*")
            {
                result = val1 * val2;
                txtBox.Text = result.ToString();
            }
            else
            {
                result = val1 / val2;
                txtBox.Text = result.ToString();
            }
        }

        private void cmdSin_Click(object sender, EventArgs e)
        {
            double v;
            v = double.Parse(txtBox.Text);
            txtBox.Text = Math.Sin(v).ToString();
        }

        private void cmdSquare_Click(object sender, EventArgs e)
        {
            double v;
            v = double.Parse(txtBox.Text);
            txtBox.Text = Math.Pow(v, 2).ToString();
        }

        private void cmdSqrt_Click(object sender, EventArgs e)
        {
            double v;
            v = double.Parse(txtBox.Text);
            txtBox.Text = Math.Sqrt(v).ToString();
        }

        private void cmdTan_Click(object sender, EventArgs e)
        {
            double v;
            v = double.Parse(txtBox.Text);
            txtBox.Text = Math.Tan(v).ToString();
        }

        private void cmdSubtract_Click(object sender, EventArgs e)
        {
            sign = "-";
            val1 = double.Parse(txtBox.Text);
            txtBox.Text = "";
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            sign = "+";
            val1 = double.Parse(txtBox.Text);
            txtBox.Text = "";
        }

        private void cmdMultiply_Click(object sender, EventArgs e)
        {
            sign = "*";
            val1 = double.Parse(txtBox.Text);
            txtBox.Text = "";
        }

        private void cmdDivide_Click(object sender, EventArgs e)
        {
            sign = "/";
            val1 = double.Parse(txtBox.Text);
            txtBox.Text = "";
        }
        private void txtBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int keycode;
            keycode = e.KeyChar;
            //accept only number from key 0 to key 9, key back, and key dot
            if (keycode >= 48 && keycode <= 57 || keycode == 8 || keycode == 32)
            {
                //key dot allowed only one time
                if (keycode == 46) ++trackkeypoint;
                if (trackkeypoint > 1) { e.Handled = true; --trackkeypoint; }
            }
            else e.Handled = true;
        }
    }
}
