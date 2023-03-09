using Registration.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
    public partial class AvtorisationForm : Form
    {
        internal static string login, password = "";

        public AvtorisationForm()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            RegistrationForm form = new RegistrationForm();
            form.ShowDialog();
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '\0';
            button4.BackgroundImage = Image.FromFile("C:\\Users\\gupli\\source\\repos\\tiktakg\\Labs-WinForms\\Registration\\Resources\\OpenEye.png");
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '*';
            button4.BackgroundImage = Image.FromFile("C:\\Users\\gupli\\source\\repos\\tiktakg\\Labs-WinForms\\Registration\\Resources\\CloseEye.png");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="" & "" != textBox2.Text)
            {

                if(ReadFileAndCheckPass())
                { 
                    Hide();
                    login = textBox1.Text;
                    password = textBox2.Text;
                    CompliteForm form2 = new CompliteForm();
                    form2.password = "3";
                    form2.Show();
                }
                label5.Text = password + "Поля пустые";

            }
            else
                label5.Text = "Поля пустые";
        }

        public bool ReadFileAndCheckPass()
        {
            string[] lines = File.ReadAllLines("SaveDate.txt");
            bool stopChar = false;
            foreach(string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ']' & stopChar)
                        password += line[i];

                    if (line[i] != '[')
                        login += line[i];
                    else
                    {
                        stopChar = true;
                        i++;
                    }
                        

                    

                }

                textBox1.Text = password;
                textBox2.Text = login;
                if (login == textBox1.Text.ToLower() & textBox2.Text == password)
                    return true;
                password = "";
                login = "";


            }
            return false;
        }

    }
}
