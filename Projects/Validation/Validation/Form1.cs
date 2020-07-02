using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            string text2 = textBox3.Text;
            string text3 = textBox4.Text;
            string text0 = textBox1.Text;
            if (!c.IsPhone(text))
            {
                MessageBox.Show("Phone number is invalid");
            }   
            else if(!c.IsName(text0))
            {
                Debug.WriteLine(text0);
                MessageBox.Show("Name is invalid");
            }       
            else if (!c.IsMail(text2))
            {
                MessageBox.Show("Mail is invalid");
            }
            else if (!c.IsZip(text3))
            {
                MessageBox.Show("Zipcode is invalid");
            }
            else
            {
                MessageBox.Show("Submition complete");
            }
        }
    }
}
