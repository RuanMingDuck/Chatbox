using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            cbGender.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            if (!String.IsNullOrEmpty(txtUsername.Text) && Regex.IsMatch(txtUsername.Text, pattern) && !String.IsNullOrEmpty(txtPassword.Text) && !String.IsNullOrEmpty(txtFullName.Text))
            {
                Email_OTP formEmail = new Email_OTP();
                formEmail.Username = txtUsername.Text;
                formEmail.Password = txtPassword.Text;
                formEmail.FullName = txtFullName.Text;
                formEmail.Gender = cbGender.Text;
                formEmail.Birthday = dateBirth.Text;               
                formEmail.Show();
            }
            else
            {
                MessageBox.Show("Can't be blank");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login formLogin = new Login();
            formLogin.Closed += (s, args) => this.Close();
            formLogin.Show();
        }
    }
}
