using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
   
    static Dictionary<string, string> clients = new Dictionary<string, string>();
   
    static List<TcpClient> connectedClients = new List<TcpClient>();
    //static string connectionString = @"Data Source= DESKTOP-NUTIPAK;Initial Catalog=LTM_ChatApplication;Integrated Security=True";
    static string connectionString = @"Data Source= DESKTOP-8DEJ0LF\SQLEXPRESS;Initial Catalog=ChatBox;Integrated Security=True";
    
    static void Main(string[] args)
    {
        
        TcpListener listener = new TcpListener(IPAddress.Any, 8888);
        listener.Start();

        Console.WriteLine("Server started. Listening for clients...");
        Task.Run(async () =>
        {
            while (true)
            {
                // Accept a client connection
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine(client.Client.RemoteEndPoint.ToString());

                // Generate a random name for the client


                // Start a new thread to handle the client communication
                _ = HandleClientCommunication(client, null);

            }
        });
        string input;

        do
        {
            input = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.StartsWith("/kick"))
                {
                    string[] commandParts = input.Split(' ');

                    if (commandParts.Length == 2)
                    {
                        string usernameToKick = commandParts[1];
                        Task.Run(async () =>
                        {
                            bool kickedUserFound = false;

                            foreach (var connectedClient in connectedClients.ToList())
                            {
                                NetworkStream networkStreamTemp = connectedClient.GetStream();
                                byte[] responseBytes;

                                if (clients.TryGetValue(connectedClient.Client.RemoteEndPoint.ToString(), out var fullName))
                                {
                                    if (fullName.Equals(usernameToKick))
                                    {
                                        responseBytes =Encoding.UTF8.GetBytes($"You have been kicked by server.");
                                        await networkStreamTemp.WriteAsync(responseBytes, 0, responseBytes.Length);

                                        clients.Remove(connectedClient.Client.RemoteEndPoint.ToString());
                                        connectedClients.Remove(connectedClient);

                                        networkStreamTemp.Close();
                                        connectedClient.Close();

                                        kickedUserFound = true;

                                        break;
                                    }
                                }
                            }

                            if (!kickedUserFound)
                            {
                                Console.WriteLine($"User '{usernameToKick}' not found or already disconnected.");
                            }
                        });
                    }
                    else
                    {
                        Console.WriteLine("Invalid kick command. Please use the format: /kick clientname");
                    }
                }
                else
                {
                    input = $"[SERVER]: {input}";

                    Task.Run(async () =>
                    {
                        await BroadcastMessage(input);

                        // Print the sent message in the console log of the server itself
                        Console.WriteLine(input);
                    });
                }

            }

        } while (input != "exit");

    }
    static async Task HandleClientCommunication(TcpClient client, string fullName)
    {
        NetworkStream networkStream = client.GetStream();
        byte[] buffer = new byte[1024*5000];

        try
        {
            int bytesRead;

            if ((bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
               
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                
                string[] messageParts = receivedMessage.Split('|');
                //Checking message if it is login or register
                if (messageParts.Length == 3 && messageParts[0] == "AUTHENTICATE")
                {
                    string username = messageParts[1];
                    string password = messageParts[2];

                    bool authenticationResult;

                   
                    fullName = AuthenticateUser(username, password);

                    // Check if the full name is not null or empty to determine authentication success
                    if (!string.IsNullOrEmpty(fullName))
                        authenticationResult = true;

                    else
                        authenticationResult = false;

                    // If authentication failed, close the connection with the client
                    if (!authenticationResult)
                    {
                        byte[] responseAuthenticationFailedBytes = Encoding.UTF8.GetBytes("Authentication failed");
                        networkStream.Write(responseAuthenticationFailedBytes, 0, responseAuthenticationFailedBytes.Length);

                        throw new IOException("Authentication failed");
                    }
                    else
                    {
                        byte[] responseAuthenticationFailedBytes = Encoding.UTF8.GetBytes("Authentication success");
                        networkStream.Write(responseAuthenticationFailedBytes, 0, responseAuthenticationFailedBytes.Length);
                    }

                    byte[] responseBytes = Encoding.UTF8.GetBytes(fullName);
                    networkStream.Write(responseBytes, 0, responseBytes.Length);
                }

                if (messageParts.Length == 6 && messageParts[0] == "REGISTER")
                {
                    string username = messageParts[1];
                    string password = HashPassword(messageParts[2]);
                    string fullname = messageParts[3];
                    string gender = messageParts[4];
                    string birthday = messageParts[5];
                    bool registrationResult = RegisterUser(username, password, fullname, gender, birthday);
                    if (!registrationResult)
                    {
                        byte[] responseRegistrationFailedBytes = Encoding.UTF8.GetBytes("Registration failed");
                        networkStream.Write(responseRegistrationFailedBytes, 0, responseRegistrationFailedBytes.Length);
                        throw new IOException("User registration failed");
                    }
                    byte[] responseSuccessfulBytes = Encoding.UTF8.GetBytes("Registration successful");
                    networkStream.Write(responseSuccessfulBytes, 0, responseSuccessfulBytes.Length);
                    Console.WriteLine("Registration successful");
                }
                

                Thread.Sleep(1000);

                // Add the connected client to the list
                connectedClients.Add(client);

                clients.Add(client.Client.RemoteEndPoint.ToString(), fullName);
                
                Console.WriteLine("Username: " + fullName);
                              
                
                Thread.Sleep(500);
                // Notify when new client join
                string userListMessage = $"Current Users:{GetConnectedUsers()}";
                string userJoin = $"{fullName} has joined.";
                Console.WriteLine(userListMessage);
                Console.WriteLine("Number of Connected Users: " + connectedClients.Count);
                await BroadcastMessage(userListMessage);
                Thread.Sleep(500);
                await BroadcastMessage(userJoin);

                Array.Clear(buffer, 0, buffer.Length);
            }
            

            while ((bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string sender;

                if (clients.TryGetValue(client.Client.RemoteEndPoint.ToString(), out sender))
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] messageParts = message.Split('|');
                    
                    if (message.StartsWith("@"))
                    {
                        // Message privately with format @fullName:
                        int recipientSeparatorIndex = message.IndexOf(':');

                        if (recipientSeparatorIndex != -1)
                        {
                            string recipientName = message.Substring(1, recipientSeparatorIndex - 1);
                            string privateMessage = message.Substring(recipientSeparatorIndex + 1);

                            TcpClient recipientClient = connectedClients.FirstOrDefault(c =>
                                clients.ContainsKey(c.Client.RemoteEndPoint.ToString()) &&
                                clients[c.Client.RemoteEndPoint.ToString()] == recipientName);

                            if (recipientClient != null)
                            {
                                NetworkStream receiverNetworkStream = recipientClient.GetStream();

                                byte[] responseBytes = Encoding.UTF8.GetBytes($"{sender} [private]: {privateMessage}");

                                await receiverNetworkStream.WriteAsync(responseBytes, 0, responseBytes.Length);

                            }
                            else
                            {
                                byte[] responseBytes =
                                    Encoding.UTF8.GetBytes($"User '{recipientName}' not found or offline.");

                                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);

                                Console.WriteLine($"Private message failed from {sender} to '{recipientName}': User not found or offline");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(sender + ": " + Encoding.UTF8.GetString(buffer, 0, bytesRead));

                        // Broadcast received message to all other clients except sender
                        foreach (TcpClient receiver in connectedClients.Where(c => c != client))
                        {
                            NetworkStream receiverNetworkStream = receiver.GetStream();

                            byte[] responseBytes = Encoding.UTF8.GetBytes($"{sender}: {Encoding.UTF8.GetString(buffer, 0, bytesRead)}");

                            await receiverNetworkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                        }
                    }
                }

                Array.Clear(buffer, 0, buffer.Length);
            }
        }
        catch (IOException ex)
        {
            

            Console.WriteLine($"Connection with {fullName} " + client.Client.RemoteEndPoint.ToString() + " closed.");
        }
        finally
        {
            // Remove the client's IP address and username mapping when closing the connection
            clients.Remove(client.Client.RemoteEndPoint.ToString());

            // Remove the disconnected client from the list
            connectedClients.Remove(client);
            Console.WriteLine("Number of Connected Clients: " + connectedClients.Count);
            networkStream.Close();

            client.Close();

            string userListMessage = $"Current Users:\n{GetConnectedUsers()}";

            await BroadcastMessage(userListMessage);
            Console.WriteLine(userListMessage + "\n");
            // Broadcast user disconnection message
            await BroadcastMessage($"{fullName} has left.");
        }
    }

    static async Task BroadcastMessage(string message)

    {
        byte[] responseBytes = Encoding.UTF8.GetBytes(message);

        foreach (TcpClient client in connectedClients)
        {
            NetworkStream networkStream = client.GetStream();
            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }

    }
    static string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }

    static bool RegisterUser(string username, string password, string fullname, string gender, string birthday)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
                          
            connection.Open();          
            SqlCommand command = new SqlCommand("INSERT INTO [User] (Email, Password, FullName, Gender, Birthday) VALUES (@Email, @Password, @FullName, @Gender, @Birthday)", connection);
            command.Parameters.AddWithValue("@Email", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@FullName", fullname);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Birthday", birthday);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected == 1;

        }
    }
    static bool VerifyHashedPassword(string plainTextpassword, string hashedPassword)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainTextpassword));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return String.Equals(builder.ToString(), hashedPassword);
        }
    }

    static string AuthenticateUser(string username, string password)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT FullName, Password FROM [User] WHERE Email=@Email", connection);

            command.Parameters.AddWithValue("@Email", username);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                // Retrieve the stored hashed password from the database
                var storedPassword = reader.GetString(reader.GetOrdinal("Password"));

                // Verify if the provided plaintext password matches the stored hashed password
                bool isPasswordValid = VerifyHashedPassword(password, storedPassword);

                if (isPasswordValid)
                {
                    // Retrieve and return full name from the database
                    var fullName = reader.GetString(reader.GetOrdinal("FullName"));
                    reader.Close();
                    return fullName;
                }
            }

            reader.Close();
        }

        return null;
    }

    
    static string GetConnectedUsers()
    {
        StringBuilder userListBuilder = new StringBuilder();

        foreach (var kvp in clients)
        {
            userListBuilder.Append(kvp.Value); 
            userListBuilder.Append(", "); 
        }

        if (userListBuilder.Length > 2)
        {
            
            userListBuilder.Remove(userListBuilder.Length - 2, 2);
        }

        return userListBuilder.ToString();
    }
   
}






