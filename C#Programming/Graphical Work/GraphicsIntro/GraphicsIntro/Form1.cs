using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsIntro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            bool YesNo = checkBox1.Checked;
            string Sweets;
            if (YesNo)
            {
                Sweets = "I like sweets too!";
            }
            else
            {
                Sweets = "more sweets for me!";
            }
            MessageBox.Show("Hello, " + Name + ", " + Sweets);

            string Animal = listBox1.Text;
            if (Animal == "Cat")
                pictureBox1.Load("Cat.PNG");
            if (Animal == "Dog")
                pictureBox1.Load("Dog.PNG");
            if (Animal == "Bird")
                pictureBox1.Load("Bird.PNG");
            if (Animal == "Rabbit")
                pictureBox1.Load("Rabbit.PNG");
            if (Animal == "Fish")
                pictureBox1.Load("Fish.PNG");
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
