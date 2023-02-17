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

namespace Labs_WinForms
{
    public partial class Form1 : Form
    {
        bool IsGoRight;
        float time;
        int t;

        public Form1()
        {
            InitializeComponent();      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value >= 10)
                progressBar1.Value -= 10;

            if (progressBar1.Value != 0 | progressBar1.Value != 100)
                label1.Text = "";


            timer1.Enabled = true;
            timer2.Enabled = true;
            IsGoRight = true;


            if (progressBar1.Value == 0 | progressBar1.Value == 100)
            {
                label1.Text = time.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value <= 90)
                progressBar1.Value += 10;

            if (progressBar1.Value != 0 | progressBar1.Value != 100)
                label1.Text = "";
            else

            if (progressBar1.Value == 0 | progressBar1.Value == 100)
            {
               label1.Text = time.ToString();

            }

            timer1.Enabled = true;
            timer2.Enabled = true;
            IsGoRight = false;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            time += 0.1f;
            if (progressBar1.Value == 0 | progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                label1.Text = time.ToString();

            }
        }
            private void timer2_Tick(object sender, EventArgs e)
        {
                if (IsGoRight && progressBar1.Value >= 10)
                {
                    progressBar1.Value -= 10;

                }
                else if (!IsGoRight && progressBar1.Value <= 90)
                {
                    progressBar1.Value += 10;

                }


                if (progressBar1.Value == 0 | progressBar1.Value == 100)
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    label1.Text = time.ToString();

                }
                else
                    label1.Text = "";         
        }
     
    }
}

