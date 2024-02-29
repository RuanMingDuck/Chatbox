using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Reflection.Emit;

namespace DoAn
{
    public partial class Form_Main : Form
    {
        private TcpClientManager tcpClient;
        private NetworkStream _stream;
        StreamReader _streamReader;
        private Thread messageReceivingThread;
        public Form_Main(TcpClientManager _tcpClient)
        {
            InitializeComponent();
            listview_MessagesBox.View = View.List;
            listview_FriendList.View = View.List;
            tcpClient = _tcpClient;

        }
        private async void Form_Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient != null && tcpClient.IsConnected)
                {
                    _stream = tcpClient.GetStream();
                    _streamReader = new StreamReader(_stream);
                    byte[] buffer = new byte[1024];
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    string receivedUsername = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        lb_name.Text = receivedUsername;
                        // Start receiving messages in a separate thread
                        messageReceivingThread = new Thread(ReceiveMessages);
                        messageReceivingThread.Start();
                    }));
                }
                else
                {
                    MessageBox.Show("Not connected to server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                // Handle any other error scenarios or perform necessary cleanup here.
                // You can also choose to close/disconnect from the server in case of an error.
            }

        }

        private  void btnMessageSend_Click(object sender, EventArgs e)
        {
            string message = txt_MessageSend.Text; // Get the text from your message input textbox
            
            if (tcpClient != null && tcpClient.IsConnected) // Check if TCP client is connected to the server
            {
                 tcpClient.SendMessage(message);
                 listview_MessagesBox.Items.Add("Me: "+message);
                // Send the message using SendMessage method of TcpCLientHandler
                txt_MessageSend.Clear();
                // You can also add code here to update UI or perform any other necessary actions after sending the message
            }
            
        }
        
        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            tcpClient.CloseConnection();
            this.Close();
            
        }
        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            StringBuilder receivedData = new StringBuilder();

            while (tcpClient.IsConnected)
            {
                try
                {
                    int bytesRead = _stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        string trimmedMessage = receivedMessage.Trim();
                            
                            receivedData.Append(trimmedMessage);
                        if (receivedData.ToString().StartsWith("Current Users:"))
                        {
                            string userListString = receivedData.ToString().Substring(14); // Remove "Current Users: "

                            // Split the user list by comma and update it in UI one by one
                            string[] userList = userListString.Split(',');

                            foreach (string user in userList)
                                UpdateUserList(user.Trim()); // Trim any leading/trailing white spaces

                            receivedData.Clear();
                        }
                        while (_stream.DataAvailable)
                        {
                            bytesRead = _stream.Read(buffer, 0, buffer.Length);
                            trimmedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            receivedData.Append(trimmedMessage);
                            
                        }
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            listview_MessagesBox.Items.Add(receivedData.ToString());
                            receivedData.Clear();
                        }));
                        if (trimmedMessage.EndsWith("has left."))
                        {
                            string usernameLeft = trimmedMessage.Substring(0,
                                trimmedMessage.IndexOf("has left.")).Trim();

                            RemoveUserFromList(usernameLeft);
                        }

                        // Check if the message is a user list message


                        // Handle other types of messages here
                    }
                }
                catch (IOException ex)
                {
                    // Handle any IO exceptions or end-of-stream conditions here.
                    // You can choose to close/disconnect from the server in case of an error.

                    
                    break;
                }
            }
        }
        private void UpdateUserList(string user)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                bool userExists = false;

                // Check if the user already exists in the list
                foreach (ListViewItem item in listview_FriendList.Items)
                {
                    if (item.Text == user)
                    {
                        userExists = true;
                        break;
                    }
                }

                // Add the user to the list only if it doesn't exist
                if (!userExists)
                    listview_FriendList.Items.Add(user);
            }));
        }
        private void RemoveUserFromList(string user)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                ListViewItem itemToRemove = null;

                // Find the item corresponding to the given username
                foreach (ListViewItem item in listview_FriendList.Items)
                {
                    if (item.Text == user)
                    {
                        itemToRemove = item;
                        break;
                    }
                }

                // Remove the found item from the list
                if (itemToRemove != null)
                    listview_FriendList.Items.Remove(itemToRemove);
            }));
        }

        private void btn_Attachment_Click(object sender, EventArgs e)
        {
            if (tcpClient != null && tcpClient.IsConnected) // Check if TCP client is connected to the server
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Send the file using SendMessage method of TcpClientHandler
                    tcpClient.SendFile(filePath);


                }
            }
        }

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            String message = "😊";
            tcpClient.SendMessage(message);
            listview_MessagesBox.Items.Add("Me: " + message);
        }

        private void btnIncrese_Click(object sender, EventArgs e)
        {
            listview_MessagesBox.Font = new Font(listview_MessagesBox.Font.FontFamily, listview_MessagesBox.Font.Size + 2, listview_MessagesBox.Font.Style);
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            listview_MessagesBox.Font = new Font(listview_MessagesBox.Font.FontFamily, listview_MessagesBox.Font.Size - 2, listview_MessagesBox.Font.Style);
        }
    }
}

