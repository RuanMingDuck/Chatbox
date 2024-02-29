using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public class TcpClientManager
    {
        private TcpClient _client;
        private NetworkStream _networkStream;

        public bool IsConnected { get; private set; }

        // Create a list to store received messages.

        public NetworkStream GetStream()
        {
            return _client.GetStream();
        }
        public void Connect(string serverIp, int port)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(serverIp, port);

                _networkStream = _client.GetStream();

                // Start listening for incoming messages on a separate thread.

                IsConnected = true;
            }
            catch (Exception ex)
            {
                // Handle connection error.
                MessageBox.Show($"Error connecting to server: {ex.Message}");
                IsConnected = false;
            }
        }

        public void SendMessage(string message)
        {
            if (IsConnected && !string.IsNullOrEmpty(message))
            {
                try
                {

                    byte[] data = Encoding.UTF8.GetBytes(message);
                    _networkStream.Write(data, 0, data.Length);

                }
                catch (Exception ex)
                {

                    // Handle write error or disconnection.
                    MessageBox.Show($"Error sending message: {ex.Message}");
                    IsConnected = false;

                }
            }
        }
        public void SendFile(string filePath)
        {
            try
            {
                
                byte[] fileData = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);
                
                
                byte[] attachmentHeader = Encoding.UTF8.GetBytes($"FILE|"+fileName);

                _networkStream.Write(attachmentHeader, 0, attachmentHeader.Length);
                _networkStream.Write(BitConverter.GetBytes(fileData.Length), 0, sizeof(int));
                _networkStream.Write(fileData, 0, fileData.Length);

                _networkStream.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public string ReceiveMessage()
        {
        try
            {
            byte[] buffer = new byte[1024];
            int bytesRead = _networkStream.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);

            }
        catch (Exception ex)
            {

            // Handle read error or disconnection.
            MessageBox.Show($"Error reading ReceiveMessage() message: {ex.Message}");
            IsConnected = false;
            return null;

            }
        }
        public void CloseConnection()
        {
            try
            {
                _networkStream.Close();
                _client.Close();
                IsConnected = false;
            }
            catch (Exception ex)
            {
                // Handle error while closing connection.
                MessageBox.Show($"Error closing connection: {ex.Message}");
            }
        }


    }
}