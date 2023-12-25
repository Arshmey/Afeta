using Afeta.Logic.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Afeta.Logic.ClientCommand
{
    internal class Sender
    {

        private TcpClient client;
        private NetworkStream stream;
        private Command command;

        public Sender(TcpClient client, NetworkStream stream, Command command) 
        {
            this.client = client;
            this.stream = stream;
            this.command = command;
        }

        public void StartRead()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    stream.Read(buffer, 0, buffer.Length);
                    buffer = buffer.Where(x => x > 0).ToArray();
                    string commandProcessing = Encoding.UTF8.GetString(buffer);
                    string[] commandProcessed = commandProcessing.Split(new string[] { "<:>" }, StringSplitOptions.None);
                    command.Execute(commandProcessed);
                }
                catch(Exception ex) { }
            }
        }

        public void Writer(string command)
        {
            byte[] buffer = new byte[8192];
            buffer = Encoding.UTF8.GetBytes(command);
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

    }
}
