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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {

            if (CheckStrings(textBox1.Text, textBox2.Text, textBox3.Text))
            {
                if (CheckPass(textBox2.Text) & CheckPass(textBox3.Text))
                {
                    File.AppendAllText($"SaveDate.txt", $"|{textBox1.Text.ToLower()}[{textBox2.Text}]\n");

                    AvtorisationForm AvtForm= new AvtorisationForm();
                    Hide();
                    AvtForm.Show();

                }
                else
                    label5.Text = "Пароли разные!";
            }   
            else
                label5.Text = "Поля пустые или пароли разные!";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool CheckPass(string pass)
        {
            if ((pass.Length >= 6)
            && pass.Any(char.IsDigit)
            && pass.Any(char.IsLetter)
            && pass.Any(char.IsPunctuation)
            && pass.Any(char.IsLower)
            && pass.Any(char.IsUpper))
                return true;
            else
                return false;
        }
        private bool CheckStrings(string str1, string str2, string str3)
        {
            if (str1 != "" & str2 != "" & str3 != "")
                return true;
            else
                return false;
        }
    }
}
