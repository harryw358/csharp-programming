using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalindromeCheckRecursive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtString_TextChanged(object sender, EventArgs e)
        {
            if (txtString.Text.Length == 0)
            {
                lblOutput.Text = "";
            }
            else if (IsPalindrome(txtString.Text))
            {
                lblOutput.Text = "This is a palindrome.";
            }
            else
            {
                lblOutput.Text = "This is not a palindrome.";
            }
        }

        static string ReverseString_Recursive(string str)
        {
            if (str.Length > 0)
            {
                return str[str.Length - 1] + ReverseString_Recursive(str.Substring(0, str.Length - 1)); 
            }
            else
            {
                return str;
            }
        }

        static bool IsPalindrome(string str)
        {
            if(ReverseString_Recursive(str).ToLower() == str.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
