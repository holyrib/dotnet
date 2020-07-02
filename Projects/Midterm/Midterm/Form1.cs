using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midterm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
        }
        public event System.Windows.Forms.PaintEventHandler Paint;
        int x = 100;
        int y = 120;
        int w = 25;
        int z = 25;
        int len = 11;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            len = Int32.Parse(textBox1.Text);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            button2.BackColor = colorDialog2.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            button3.BackColor = colorDialog3.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            //Color c = new Color();
            int tempy = y;
            int r = colorDialog1.Color.R;
            int g = colorDialog1.Color.G;
            int b = colorDialog1.Color.B;
            int r2 = colorDialog2.Color.R;
            int g2 = colorDialog2.Color.G;
            int b2 = colorDialog2.Color.B;
            int r3 = colorDialog3.Color.R;
            int g3 = colorDialog3.Color.G;
            int b3 = colorDialog3.Color.B;

            //c = Color.FromArgb(r, g, b);

            int dist = len;
            for (int j= 0;  j < dist; j++ )
            {
                for (int i = 0; i < len; i++)
                {

                    //x3 = T * x1 + (1 - T) * x2

                    //double rr = Math.Abs((double)i / len * r + (1 - (double)i / len)*r2 + );
                   // double gg = Math.Abs(g + (double)i / len * (g2 - g) + (double)j / dist * (r3 - r2));
                    //double bb = Math.Abs(b + (double)i / len * (b2 - b) + (double)j / dist * (r3 - r3));
                    /*double rr = Math.Abs(r + (double)i / len * (r2 - r) + (double)j / dist * (r3 - r));
                    double gg = Math.Abs(g + (double)i / len * (g2 - g) + (double)j / dist * (g3 - g));
                    double bb = Math.Abs(b + (double)i / len * (b2 - b) + (double)j / dist * (b3 - b));*/
                    //double t = (double)i / 11;
                    double rr = ( r + 
                    //Debug.WriteLine((double)i / len + "   " + (double)j / dist + "  " +  bb + "  "  + "  " + i);
                    Color c = Color.FromArgb((int)rr, (int)gg, (int)bb);

                    Brush p = new SolidBrush(c);
                    gr.FillEllipse(p, x, y, w, z);

                    y = y + w;
                   

                }




                len = len - 1;
                x = x + w;
                tempy = tempy + w / 2;
                y = tempy;

                

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Red);
            g.DrawEllipse(p, x, y, w, z);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Pen p = new Pen(Color.Red);
            g.DrawEllipse(p, x, y, w, z);

        }
        
       
    }
    
}
