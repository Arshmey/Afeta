using Afeta.Logic.Client;
using Afeta.Logic.ClientCommand;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Afeta.Logic.Other
{
    internal class Connect
    {

        private TcpClient client;
        private NetworkStream stream;
        private Command command;
        private Sender sender;
        private string name = "";
        private Random random = new Random();
        private char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        public void StartSession()
        {

            Console.Write("Write (ip:port)>: ");
            string[] ip_port = Console.ReadLine().Split(':');
            client = new TcpClient(ip_port[0], int.Parse(ip_port[1]));
            stream = client.GetStream();
            command = new Command();
            sender = new Sender(client, stream, command);
            Thread startReader = new Thread(sender.StartRead);
            startReader.Start();
            Thread.Sleep(200);
            Account();
        }

        private void Account()
        {
            Console.Clear();
            Console.WriteLine("1 - Continue\n2 - Create Wallet");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Console.Clear();
                    Login();
                    break;
                case 2:
                    Console.Clear();
                    Register();
                    break;
                default:
                    Console.WriteLine("Read the list");
                    break;
            }
        }

        private void Login()
        {
            Console.Write("Write name: ");
            string name = Console.ReadLine();
            Console.Write("Write password: ");
            string pass = Console.ReadLine();
            sender.Writer("Login<:>" + name + "<:>" + pass);
            new Lobby(sender).Start();
        }

        private void Register()
        {
            getID();
            File.Create(@"Afeta_Data/Wallet.txt").Close();
            File.WriteAllText(@"Afeta_Data/Wallet.txt", name);
            Console.Write("Write password: ");
            string pass = Console.ReadLine();
            sender.Writer("Reg<:>" + name + "<:>" + pass);
            new Lobby(sender).Start();
        }

        private void getID()
        {
            string ID = "";
            for (int i = 0; i != alphabet.Length; i++)
            {
                int j = random.Next(0, alphabet.Length);
                ID += alphabet[j];
            }
            name = ID;
        }
    }
}
