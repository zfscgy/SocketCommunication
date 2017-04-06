using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;


namespace SocketConnection_2.files
{
    class Client
    {
        //The maxiumum length of a message
        public const int BufferSize = 1024;
        public Socket socket;
        bool isConnected = false;
        private string hostAddress;
        private int port;
        //This buffer is for receiving message
        byte[] readBuff = new byte[BufferSize];
        //Store the message received just now
        public string messageReceived;
        public void Connect()
        {
            //Create a new socket, then connect it to the host.
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(hostAddress, port);
        }

        private void ReceiveCallBack(IAsyncResult asyncRe)
        {
            int msgSize = socket.EndReceive(asyncRe);
            messageReceived = System.Text.Encoding.UTF8.GetString(readBuff, 0, msgSize);
            //continue receiving
            socket.BeginReceive(readBuff, 0, BufferSize, SocketFlags.None, ReceiveCallBack, null);
        }
        public void Send(string sentingMsg)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(sentingMsg);
            if(!isConnected)
            {
                return;
            }
            socket.Send(bytes);
        }
    }
}
