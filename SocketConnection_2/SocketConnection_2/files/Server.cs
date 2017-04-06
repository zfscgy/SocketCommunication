using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace SocketConnection_2.files
{
    class Connection
    {
        public const int BufferSize = 1024;
        public Socket socket;
        public bool isUsing = false;
        public byte[] ReadBuff = new byte[1024];
        public int bufferCount = 0;
        public void Init(Socket clientSocket)
        {
            socket = clientSocket;
            isUsing = true;
        }
        public int RemainBuff()
        {
            return BufferSize - bufferCount;
        }
        public string GetAddress()
        {
            if(!isUsing)
            {
                return "Socket dose not created.";
            }
            return socket.RemoteEndPoint.ToString();
        }
        public void Close()
        {
            if(!isUsing)
            {
                return;
            }
            socket.Close();
            isUsing = false;
        }
    }
    class Server
    {
    }
}
