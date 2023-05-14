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
    public partial class Form3 : Registration.CompliteForm
    {
        string login = "";
        string password = "";

        public Form3()
        {
            InitializeComponent();

            using (DBContext DB = new DBContext())
            {
                var users = DB.user_data.ToList();
                foreach (user_data user in users)
                    listBox1.Items.Add($"{user.login_user} | {user.password_user}");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TakeData();

            AvtorisationForm.login = login;
            AvtorisationForm.password = password;

            editUser AvtForm = new editUser();
            Hide();
            AvtForm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TakeData();
            using (DBContext DB = new DBContext())
            {
                user_data user = DB.user_data.FirstOrDefault(u => u.login_user == login);
                DB.user_data.Remove(user);
                DB.SaveChanges();

                AvtorisationForm AvtForm = new AvtorisationForm();
                Hide();
                AvtForm.Show();
            }
        }

        private void TakeData()
        {
            bool stopchar = false;


            if (listBox1.SelectedItem != null)
                for (int i = 0; i < listBox1.SelectedItem.ToString().Length; ++i)
                {
                    if (stopchar)
                        if (listBox1.SelectedItem.ToString()[i] != ' ')
                            password += listBox1.SelectedItem.ToString()[i];

                    if (listBox1.SelectedItem.ToString()[i] == '|')
                        stopchar = true;

                    if (!stopchar)
                        if (listBox1.SelectedItem.ToString()[i] != ' ')
                            login += listBox1.SelectedItem.ToString()[i];
                }
        }
    }
}
