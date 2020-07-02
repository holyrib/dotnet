using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string[] folders = Directory.GetDirectories(@"Y:\");

            foreach (string item2 in folders)
            {
                listBox2.Items.Add((Path.GetFileName(item2)));

            }
        }
        string target = "";
        string path = "";
        string fdate = "";
        string checkdate = "";
        static List<string> gfiles = new List<string>();



        public void getFilesRecursive(string sDir)
        {

            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    getFilesRecursive(d);
                }
                foreach (var file in Directory.GetFiles(sDir))
                {
                    //This is where you would manipulate each file found, e.g.:
                    DoAction(file);

                    if (file.Contains(target))
                    {

                        DateTime filedate = Convert.ToDateTime(File.GetCreationTime(file));
                        string datethis = filedate.ToString("MM/dd/yyyy");
                        Debug.WriteLine(datethis);
                        if (checkBox1.Checked && checkdate.Equals(datethis))
                        {
                            listBox1.Items.Add((Path.GetFileName(file)));
                        }
                        else if (!checkBox1.Checked)

                            listBox1.Items.Add((Path.GetFileName(file)));
                    }

                }

            }


            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DoAction(string filepath)
        {

            gfiles.Add(filepath);
            //listBox1.Items.Add(filepath);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            target = textBox1.Text;



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            getFilesRecursive(@"Y:\" + path);
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            path = listBox2.SelectedItem.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fdate = this.dateTimePicker1.Value;
            checkdate = fdate.ToString("MM/dd/yyyy");
            Debug.WriteLine(checkdate + " I am picked date");


        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Y:\" + path + "\\" + listBox1.SelectedItem.ToString());
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            //button1.BackgroundImage = Bitmap.FromFile("/Desktop/search.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            //button1.BackgroundImage = Bitmap.FromFile("/Desktop/search.png");
        }
        bool focus = false;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (focus)
            {
                textBox1.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Yellow);
                Graphics g = e.Graphics;
                int variance = 3;
                g.DrawRectangle(p, new Rectangle(textBox1.Location.X - variance, textBox1.Location.Y - variance, textBox1.Width + variance, textBox1.Height + variance));
            }
            else
            {
                textBox1.BorderStyle = BorderStyle.FixedSingle;
            }
        }
       

       

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            focus = true;
            this.Refresh();
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            focus = false;
            this.Refresh();
        }

        private void listBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
