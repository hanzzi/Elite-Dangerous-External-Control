using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TCP_Client_and_Server
{
    public class TcpClient : System.Net.Sockets.TcpClient
    {
        private string Hostname;
        private int Port;

        public TcpClient(string hostname, int port) : base(hostname, port)

        {
            Hostname = hostname;
            Port = port;
        }

        public int WriteData(string message)
        {
            // converts the message to send into ASCII in byte format 
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(message);
            // writes the message to the TCP stream
            this.GetStream().Write(bytesToSend, 0, bytesToSend.Length);

            return 1;
        }

        public string ReadData()
        {
            // Reads the data from the stream
            byte[] bytesToRead = new byte[this.ReceiveBufferSize];
            int bytesRead = this.GetStream().Read(bytesToRead, 0, this.ReceiveBufferSize);

            return Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
        }
    }

    public class TcpServer : TcpListener
    {
        #region private fields and constructor
        private IPAddress LocalAddr;
        private int Port;
        private System.Net.Sockets.TcpClient Client;

        public TcpServer(IPAddress localAddr, int port) : base(localAddr, port)
        {
            Port = port;
            LocalAddr = localAddr;
        }
        #endregion

        public int SetupConnection()
        {
            // Starts the listener if it is not started.
            if (!this.Active)
                this.Start();

            try
            {
                // Accepts the first pending TCP Connection 
                Client = this.AcceptTcpClient();
            }
            catch (SocketException)
            {
                // returns 2 when a connection could not be established.
                return 0;
            }

            // Connection established
            return 1;
        }

        public string RecieveData()
        {
            // get the incoming data with a network stream.
            NetworkStream nwStream = Client.GetStream();
            byte[] buffer = new byte[Client.ReceiveBufferSize];

            // Reads the data from the client
            int bytesread = nwStream.Read(buffer, 0, Client.ReceiveBufferSize);
            string datarecieved = Encoding.ASCII.GetString(buffer, 0, bytesread);

            return datarecieved;
        }

        public int Callback(string callbackString)
        {
            byte[] buffer = new byte[callbackString.Length];

            // TODO: Check if this even works 
            NetworkStream nwStream = Client.GetStream();
            nwStream.Write(buffer, 0, callbackString.Length);

            return 1;
        }
    }
}
