using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
    public partial class editUser : Form
    {
        public editUser()
        {
            InitializeComponent();
            
            textBox1.Text = AvtorisationForm.login;
            textBox2.Text = AvtorisationForm.password;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExitForm();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != AvtorisationForm.login | textBox2.Text != AvtorisationForm.password | textBox3.Text !="")
            {
                using (DBContext DB = new DBContext())
                {
                    user_data user = DB.user_data.FirstOrDefault(u => u.login_user == AvtorisationForm.login);

                    user.login_user = textBox1.Text;
                    user.password_user = textBox2.Text;
                    user.id_role = Convert.ToInt32(textBox3.Text);

                    DB.user_data.AddOrUpdate(user);
                    DB.SaveChanges();

                    ExitForm();
                }
            }
        }
        private void ExitForm()
        {
            AvtorisationForm AvtForm = new AvtorisationForm();
            Hide();
            AvtForm.Show();
        }
    }
}
