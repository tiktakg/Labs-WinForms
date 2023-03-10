using Registration.Properties;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                    CompliteForm form2 = new CompliteForm();
                    form2.Show();
                }
                label5.Text = "Поля паролей разные";

            }
            else
                label5.Text = "Поля пустые";
        }

        public bool ReadFileAndCheckPass()
        {
            string[] lines = File.ReadAllLines("SaveDate.txt");
            bool stopChar = false;
            bool startChar = false;
            foreach (string line in lines)
            {
                Debug.WriteLine("line - " + line);

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != '' & stopChar == true)
                        password += line[i];
                    if(line[i] == '')
                    {
                        if (textBox2.Text == password & textBox1.Text.ToLower() == login.ToLower())
                            return true;
                    }

                    if (line[i] != '' & startChar & !stopChar)
                        login += line[i];

                    if(line[i] == '')
                        stopChar = true;

                    if ((line[i] == ''))
                        startChar = true;
                }
                password = "";
                login = "";

                stopChar = false;
                startChar = false;

            }
            return false;
        }
        public bool ReadFileAndCheckLogin(string TextLogin)
        {
            string[] lines = File.ReadAllLines("SaveDate.txt");
            bool stopChar = false;
            bool startChar = false;
            foreach (string line in lines)
            {
                Debug.WriteLine("line - " + line);

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '')
                    {
                        if (TextLogin.ToLower() == login.ToLower())
                            return true;
                    }

                    if (line[i] != '' & startChar & !stopChar)
                        login += line[i];

                    if (line[i] == '')
                        stopChar = true;

                    if ((line[i] == ''))
                        startChar = true;
                }
                login = "";

                stopChar = false;
                startChar = false;

            }
            return false;
        }

    }
}
