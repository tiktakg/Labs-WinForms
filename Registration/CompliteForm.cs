﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
   
    public partial class CompliteForm : Form
    {
        internal static string password2, login;

       
        public CompliteForm()
        {       
            InitializeComponent();
           
            label3.Text = AvtorisationForm.password;
            label4.Text = AvtorisationForm.login;

        }     
    }
}
