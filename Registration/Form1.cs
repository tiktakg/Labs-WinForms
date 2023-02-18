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
    public partial class RegForm : Form
    {
        internal static string login,password = "";

        public RegForm()
        {
            InitializeComponent();
            //button4.PreviewKeyDown += button4.Pr;
        }
     

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

      
        private void button4_Click(object sender, EventArgs e)
        {
            
            textBox2.PasswordChar = '\0';
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" & "" != textBox1.Text)
            {
                password = textBox2.Text;
                login = textBox1.Text;
            }
            else
                label5.Text = "Поля пустые";

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == login & password == textBox2.Text)
            {
                Hide();
                CompliteForm form2 = new CompliteForm();

                form2.Show();
            }
            else
                label5.Text = "Поля пустые";
        }  
    } 
}
