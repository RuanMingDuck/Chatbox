using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{


    public partial class Login : Form
    {
        private TcpClientManager _tcpClient;
        

        public Login()
        {
            InitializeComponent();
            _tcpClient = new TcpClientManager();
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register formRegister = new Register();
            formRegister.Closed += (s, args) => this.Close();
            formRegister.Show();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) || !String.IsNullOrEmpty(txtPassword.Text))
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;
                //Change ip here
                _tcpClient.Connect("172.20.10.11", 8888);
                _tcpClient.SendMessage($"AUTHENTICATE|{username}|{password}");

                ReceiveMessagesFromServer();
            }
            else {
                MessageBox.Show("Username and Password can't be blank");
            }
            
        }
        
        private void ReceiveMessagesFromServer()
        {
            while (true)
            {
                string messageAuthenticationFromServer = _tcpClient.ReceiveMessage();
                
                // Invoke UI update on the main thread (since this event might be raised on a background thread)
                this.Invoke((MethodInvoker)delegate ()
                {

                    if (messageAuthenticationFromServer == "Authentication success")
                    {
                        // Open new form or perform any other action here
                        Form_Main mainForm = new Form_Main(_tcpClient);
                        mainForm.Show();

                        // Close current login form if needed
                        this.Hide();
                    }
                    else if(messageAuthenticationFromServer == "Authentication failed") 
                    {
                        MessageBox.Show("Wrong credential");
                    }
                });

                // Break out of the loop if needed.
                break;
            }
        }



    }
    
}


