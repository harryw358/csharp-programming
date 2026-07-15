using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumOfNumbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int Calculate(int num)
        {
            if (num == 1)
            {
                return 1;
            }
            else
            {
                return num += Calculate(num - 1);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            lblResult.Text = Calculate((int)numericUpDown1.Value).ToString();
        }
    }
}
