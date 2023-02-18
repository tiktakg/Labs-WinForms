using System;
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
       // public string password, login;

       
        public CompliteForm()
        {       
            InitializeComponent();
           
            label3.Text = RegForm.password;
            label4.Text = RegForm.login;

        }     
    }
}
