﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
    public partial class Captha : Form
    {
        Random rnd = new Random();

        private string randomNumber;


        public Captha()
        {
            InitializeComponent();
            randomNumber = Convert.ToString(Convert.ToChar(rnd.Next(0, 26) + 65)) + Convert.ToString(rnd.Next(10000, 99999)) + Convert.ToString(Convert.ToChar(rnd.Next(0, 26) + 65));


            label1.Location = new Point(rnd.Next(10, 730), rnd.Next(0, 450));
            label1.Text = randomNumber;

            this.ControlBox = false;

        }

        private void Ввести_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == randomNumber)
            {
                Hide();

                AvtorisationForm.numberOfAttempts = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randomNumber = Convert.ToString(Convert.ToChar(rnd.Next(0, 26) + 65)) + Convert.ToString(rnd.Next(10000, 99999)) + Convert.ToString(Convert.ToChar(rnd.Next(0, 26) + 65));

            label1.Location = new Point(rnd.Next(50, 730), rnd.Next(10, 400));
            label1.Text = randomNumber;
        }
    }
}
