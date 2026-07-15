using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomisingDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var style = new DataGridViewCellStyle();
            style.Font = new Font("Segoe Print", 20);

            dataGridView1.Columns[0].HeaderCell.Style = style;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
