using Registration.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Registration
{
    public partial class AvtorisationForm : Form
    {
        internal static string login, password = "";
        internal static int numberOfAttempts = 0;

        private double time = 0;
        private bool isCapthaOpen = false;
        private char role;

        public AvtorisationForm()
        {
            InitializeComponent();
            string[] Settings;

            try
            {
                Settings = File.ReadAllLines("TimeInformation.txt");
            }
            catch
            {
                FileStream f = new FileStream("TimeInformation.txt"  , FileMode.OpenOrCreate);
                string text = "0";
                byte[] buffer = Encoding.Default.GetBytes(text);
                f.Write(buffer, 0, buffer.Length);
                f.Close();
                Settings = File.ReadAllLines("TimeInformation.txt");
               

            }

            time = Convert.ToDouble(Settings[0]);

            if (time != 0)
            {
                numberOfAttempts = 3;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }

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
            if (textBox1.Text != "" | "" != textBox2.Text)
            {

                if (ReadFileAndCheckPass())
                {
                    numberOfAttempts = 0;
                    Hide();

                    if (role == '0')
                    {
                        Form2 form = new Form2();
                        form.Show();
                    }
                    else if(role == '1')
                    {
                        Form3 form = new Form3();
                        form.Show();
                    }
                    else if (role == '2')
                    {
                        Form4 form = new Form4();
                        form.Show();
                    }
                    else if (role == '3')
                    {
                        CompliteForm form = new CompliteForm();
                        form.Show();
                    }


                   
                }
                label5.Text = "Такого пользователя нету";

            }
            else
                label5.Text = "Поля пустые";

            numberOfAttempts++;

            if (numberOfAttempts >= 3)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }

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
                    if (line[i] == '')
                    {
                        role = line[line.Length-1];
                        
                        if (textBox2.Text == password & textBox1.Text.ToLower() == login.ToLower())
                            return true;
                    }

                    if (line[i] != '' & startChar & !stopChar)
                        login += line[i];

                    if (line[i] == '')
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            FileStream fileForSaveData = File.Create("TimeInformation.txt");
            string strTime = time.ToString();
            fileForSaveData.Write(Encoding.Default.GetBytes(strTime), 0, strTime.Length);
            fileForSaveData.Close();

            if (numberOfAttempts >= 3 & time <= 30)
                time += 0.1f;
            else if (time >= 3 & numberOfAttempts == 0)
            {
                time = 0;

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

            }

            double t = 30 - Math.Round(time, 0);
            if (t != 30)
            {
                string TimeString = t.ToString();
                label1.Text = "оставшееся время - " + TimeString;
            }
            else
            {
                label1.Text = "";
            }



            if (time >= 30 & numberOfAttempts == 3 & !isCapthaOpen)
            {
                isCapthaOpen = true;
                this.Enabled = false;

                Captha form3 = new Captha();
                form3.Show();

            }

            if (time >= 0 & numberOfAttempts == 0 & isCapthaOpen)
            {
                isCapthaOpen = false;
                this.Enabled = true;
            }
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
