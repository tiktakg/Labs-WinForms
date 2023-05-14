using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Registration
{

    public partial class CompliteForm : Form
    {

        public CompliteForm()
        {
            InitializeComponent();

            label3.Text = AvtorisationForm.login;
            label4.Text = AvtorisationForm.password;

            Size = new System.Drawing.Size(300, 250);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editUser AvtForm = new editUser();
            Hide();
            AvtForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (DBContext DB = new DBContext())
            {
                user_data user = DB.user_data.FirstOrDefault(u => u.login_user == AvtorisationForm.login);
                DB.user_data.Remove(user);
                DB.SaveChanges();

                AvtorisationForm AvtForm = new AvtorisationForm();
                Hide();
                AvtForm.Show();
            }
        }

       
    }
}
