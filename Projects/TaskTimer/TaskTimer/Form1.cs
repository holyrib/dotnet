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
using System.IO;
namespace TaslTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // toolTip1.SetToolTip(this.button1, "My button1");
            List<string> prc = new List<string>();

            /* process[] localall = process.getprocesses();
            
            foreach (process p in localall)
            {
                listbox1.items.add(p.processname);
            }
            while (true)
            {
                Process cur = Process.GetCurrentProcess();
                Debug.WriteLine(cur.ProcessName);
            } */
            comboBox2.Items.Add("No goal");
            for (int i = 0; i <= 120; i += 5){
               
                    comboBox2.Items.Add(i);
                
            }
        }
        Dictionary<string, int> goals = new Dictionary<string, int>();
        int neutval = 3;
        int posval = 12;
        int negval = 5;
        int cur;
        DateTime dt;
        DateTime dt2;
        Timer timer = new Timer();
        Dictionary<string, int> tasks = new Dictionary<string, int>();
        Dictionary<string, int> tasks2 = new Dictionary<string, int>();
        string newTask = "";
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            newTask = textBox1.Text;
            if(comboBox2.SelectedIndex != 0)
            {
                goals.Add(newTask, Int32.Parse(comboBox2.SelectedItem.ToString()));
            }
            tasks2.Add(newTask, 0);
            if(newTask != null)
            {
               
                comboBox1.Items.Add(newTask);
                if (checkBox1.Checked)
                {
                    tasks.Add(newTask, 1);
                }
                else if (checkBox2.Checked)
                {
                    tasks.Add(newTask, 2);
                }
                else
                {
                    tasks.Add(newTask, 0);

                }
            }
            else
            {
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            cur = comboBox1.SelectedIndex;
            dt = DateTime.Now;
            string s = comboBox1.SelectedItem.ToString();
            int mx = goals[s] * 60;
            progressBar1.Maximum = mx;
            timer.Interval = 10;
            timer.Tick += new EventHandler(TickTimer);
            timer.Start();

        }
        int temp = 0;
        private void TickTimer(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - dt.Ticks;
            DateTime stopwatch = new DateTime();
            stopwatch = stopwatch.AddTicks(tick);
            label1.Text = String.Format("{0:HH:mm:ss:ff}", stopwatch);
            
            if(toSec(stopwatch) > temp)
            {
                temp = toSec(stopwatch);
                progressBar1.Value++;
            }
           
            dt2 = stopwatch;

        }
        public int toSec(DateTime d)
        {
            int s = d.Second;
            int m = d.Minute;
            return m * 60 + s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                
                timer.Stop();

                dt = DateTime.Now;
            }
            else
            {
                

                timer.Interval = 10;
                timer.Tick += new EventHandler(TickTimer);
                timer.Start();
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
        public int toMin(DateTime d)
        {
            int h = d.Hour;
            int m = d.Minute;
            return h * 60 + m;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer.Stop();
            //Series s1 = new Series();
            //chart1.Series["Series1"].ChartType = SeriesChartType.Pie;

            
            
            string task = tasks.Keys.ElementAt(cur);
            


            int val = tasks.Values.ElementAt(cur);
            DateTime res =dt2;
            int newval = toMin(res);
            tasks2[task] = newval;
            if (val == 0)
            {
                posval = posval + newval;
            }
            else if(val == 1)
            {
                negval = negval + newval;
            }
            else if(val == 2)
            {
                neutval = neutval + newval;
            }


            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            
            }

            chart1.Titles.Clear();
            chart1.Series["Series1"].Points.AddXY("Neutral", neutval.ToString());
            chart1.Series["Series1"].Points.AddXY("Positive", posval.ToString());
            chart1.Series["Series1"].Points.AddXY("Negative", negval.ToString());
          
            chart1.Series["Series1"].Points[0].Color = Color.Gray;
            chart1.Series["Series1"].Points[1].Color = Color.PowderBlue;
            chart1.Series["Series1"].Points[2].Color = Color.Red;
            chart1.Titles.Add("Productivity");
            barchart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void barchart()
        {
            chart2.Titles.Clear();
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();

            }
            chart2.Series["Series1"].Points.AddXY("Youtube", 12);
            //chart2.Series["Series1"].Points.AddXY("bl2", 52);
            for (int i = 0; i < tasks.Count; i++)
            {
                chart2.Series["Series1"].Points.AddXY(tasks.Keys.ElementAt(i), tasks2.Values.ElementAt(i));
                
            }
            chart2.Titles.Add("Time distribution");
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            /* string goal = textBox2.Text;
            Label l = new Label();
            l.Text = goal;
            int index = prg.Count;
            ProgressBar p = (ProgressBar)Controls["prg" + index];
            prg.Add(goal, 0); */
        }
    }
}
