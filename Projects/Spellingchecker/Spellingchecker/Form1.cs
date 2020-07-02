using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Spellingchecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            

            using (StreamReader reader = new StreamReader(@"\\Mac\Home\Documents\Visual Studio 2015\Projects\Lab2\TextFile1.txt"))
            {
                while (true)
                {                   
                    line = reader.ReadLine();
                    words.Add(line);
                    if (line == null)
                    {
                        break;
                    }
                }

            }
        }
        Leven l = new Leven();
        Leven levi = new Leven();
        string line = "";
        List<string> words = new List<string>();




        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string text = "";
        string word = "";
        int index = 0;
        string spelled = "";

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                text = richTextBox2.Text;
                label3.Text += word + " ";
                richTextBox2.Text = text;
                richTextBox2.SelectionStart = richTextBox2.Text.Length;

                int n = text.Length;
                if (n - 1 >= 0 && !Char.IsLetter(text[n - 1]))
                {

                    for (int i = n - 2; i >= 0; i--)
                    {

                        if (i == 0) { word = text.Substring(i, n - i - 1); break; }
                        if (!Char.IsLetter(text[i])) { word = text.Substring(i + 1, n - i - 2); break; }

                    }

                    if (words.Contains(word)) return;
                    else
                    {
                        StringBuilder sb = new StringBuilder(text);
                        richTextBox2.SelectionStart = n - 1 - word.Length;
                        richTextBox2.SelectionLength = word.Length;
                        richTextBox2.SelectionColor = Color.Red;
                        richTextBox2.SelectionLength = 0;
                        richTextBox2.SelectionStart = n;
                    }
                   
                }

            }
            else
            {
                
                text = richTextBox2.Text;
                richTextBox2.SelectionColor = Color.Black;

                /* string[] separators = new string[] { ",", ".", "!", "\'", " ", "\'s" };

                 List<string> textlist = new List<string>();


                  if(text)
                  foreach (string wword in text.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                  {
                      textlist.Add(wword);
                      Debug.WriteLine(wword + " AAAA");
                  } */

                int n = text.Length;
                if (n - 1 >= 0 && !Char.IsLetter(text[n - 1]))
                {

                    for (int i = n - 2; i >= 0; i--)
                    {

                        if (i == 0) { word = text.Substring(i, n - i - 1); break; }
                        if (!Char.IsLetter(text[i])) { word = text.Substring(i + 1, n - i - 2); break; }

                    }
                    if (words.Contains(word)) return;
                    
                    int temp = 100;
                        for (int j = 0; j < words.Count - 1; j++)
                        {
                                if(word == " ")
                        {
                            break;

                        }
                                if(words == null){
                                    break;
                                }
                                int res = l.leven(word.ToCharArray(), words[j].ToCharArray());
                                if (res < 3)
                                {
                                    listBox2.Items.Clear();
                                    listBox2.Items.Add(words[j]);

                                    

                        }
                                
                                if (res < temp)
                                {
                                    temp = res;
                                    index = j;                                   
                                }
                        }


                    

                    if (word != null && word != " ")
                    {
                        text = text.Replace(word, words[index]);
                        spelled = words[index];
                    }

                    label3.Text += word + " ";
                    richTextBox2.Text = text;
                    richTextBox2.SelectionStart = richTextBox2.Text.Length;
                    Debug.WriteLine(word + "  " + words[index]);

                    text = text.Replace(word, words[index]);
                    label3.Text += word + " ";
                    richTextBox2.Text = text;
                    richTextBox2.SelectionStart = richTextBox2.Text.Length;
                }

                
                    
                
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            words.Add(word);
            Debug.WriteLine("d");
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    

        private void listBox2_DoubleClick_1(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string replaced = listBox2.SelectedItem.ToString();
                richTextBox2.Text = text.Replace(spelled, replaced);
                Debug.WriteLine(spelled + "  " + replaced);
            }

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

        

       
    }

