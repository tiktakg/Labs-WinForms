using Registration.Properties;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;


using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                AvtorisationForm form2 = new AvtorisationForm();
                if (form2.checkLogin(textBox1.Text, textBox2.Text))
                {
                    using (DBContext DB = new DBContext())
                    {
                        user_data tom = new user_data { login_user = textBox1.Text, password_user = textBox2.Text, id_role = 0 };

                        DB.user_data.Add(tom);
                        DB.SaveChanges();

                    }

                    AvtorisationForm AvtForm = new AvtorisationForm();
                    Hide();
                    AvtForm.Show();

                }
                else
                    label5.Text = "Такой логин уже есть!";
            }
            else
                label5.Text = "Поля пустые или пароли разные!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            AvtorisationForm form2 = new AvtorisationForm();
            form2.Show();
        }

        private bool CheckPass(string pass)
        {
            AvtorisationForm form2 = new AvtorisationForm();

            if ((pass.Length >= 6)
            && pass.Any(char.IsDigit)
            && pass.Any(char.IsLetter)
            && pass.Any(char.IsPunctuation)
            && pass.Any(char.IsLower)
            && pass.Any(char.IsUpper))
                return true;
            else
                return false;
              //&& !form2.checkLogin(textBox1.Text.ToLower()))
        }
        private bool CheckStrings(string str1, string str2, string str3)
        {
            if (str1 != "" & str2 != "" & str3 != "" & str2 == str3)
                return true;
            else
                return false;
        }

    }
}
