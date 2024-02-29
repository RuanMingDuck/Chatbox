using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Email_OTP : Form
    {
        private TcpClientManager _tcpClient;
        private string OTP { get; set; }
        int timer;
        private string username;
        private string passwords;
        private string fullname;
        private string genders;
        private string birthdays;
        
        //private int id;

        //public int ID
        //{
        //    get { return id; }
        //    set { id = value; }
        //}
        public string Username
        {
            get { return username; }
            set { username = value; lb_OTPEMAIL.Text = value; }
        }
        public string Password
        {
            get { return passwords; }
            set { passwords = value; }
        }
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        public string Gender
        {
            get { return genders; }
            set { genders = value; }
        }
        public string Birthday
        {
            get { return birthdays; }
            set { birthdays = value; }
        }

        public Email_OTP()
        {
            InitializeComponent();
            
            _tcpClient = new TcpClientManager();
            btn_OTPCONFIRM.Enabled = false;
        }
        //sql connection
        
        

        private void btn_OTPSEND_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int number = random.Next(10000, 99999);
            string OTP = number.ToString();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(lb_OTPEMAIL.Text);
                mail.To.Add(lb_OTPEMAIL.Text);
                mail.Subject = "OTP Code for your Chat Application";
                mail.Body = " This is your OTP CODE  \n" + OTP;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("demonlord08062801@gmail.com", "uxigphglucolukde");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                MessageBox.Show("OTP SENT! Check your email");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            lb_OTP.Text = OTP;
            timer = 600;
            btn_OTPSEND.Enabled = false;
            timer1.Start();
            btn_OTPCONFIRM.Enabled=true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btn_OTPSEND.Text = timer--.ToString();
            if (timer < 0)
            {
                timer1.Stop();
                btn_OTPSEND.Enabled = true;
                btn_OTPSEND.Text = "SEND";
            }
        }

        private void btn_OTPCONFIRM_Click(object sender, EventArgs e)
        {
            
            string otpSet = lb_OTP.Text;
            string otpCheck = txt_OTPCONFIRM.Text;
            //if (otpSet == otpCheck)
            //{
                //Change ip here
                _tcpClient.Connect("172.20.10.11", 8888);
                MessageBox.Show($"REGISTER|{username}|{passwords}|{fullname}|{genders}|{birthdays}");
                _tcpClient.SendMessage($"REGISTER|{username}|{passwords}|{fullname}|{genders}|{birthdays}");
                _tcpClient.CloseConnection();
            //}
            //else
            //{
            //    MessageBox.Show("Wrong OTP");
            //}




        }
        private void ReceiveMessagesFromServer()
        {
            while (true)
            {
                string messageRegisterFromServer = _tcpClient.ReceiveMessage();             
                // Invoke UI update on the main thread (since this event might be raised on a background thread)
                this.Invoke((MethodInvoker)delegate ()
                {

                    if (messageRegisterFromServer == "Registration successful")
                    {
                        // Open new form or perform any other action here
                        MessageBox.Show("Registration successful");
                        _tcpClient.CloseConnection();
                        // Close current login form if needed
                        this.Hide();
                    }
                    else if (messageRegisterFromServer == "Registration failed")
                    {
                        MessageBox.Show("Registration failed");
                    }
                });

                // Break out of the loop if needed.
                break;
            }
        }

        private void Email_OTP_Load(object sender, EventArgs e)
        {
           
        }

    }
}
