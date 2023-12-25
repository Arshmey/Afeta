using Afeta.Logic.ClientCommand;
using Afeta.Logic.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Afeta.Logic
{
    internal class Lobby
    {

        private Sender sender;
        private MiningClass mining = new MiningClass();

        public Lobby(Sender sender) 
        {
            this.sender = sender;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("1 - Mining\n2 - Balance\n3 - Send coin");
            Console.Write("Choose>: ");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    mining.Mine( sender);
                    break;
                case 2:
                    sender.Writer("Balance");
                    Thread.Sleep(2000);
                    Start();
                    break;
                case 3:
                    Console.WriteLine("\nHow much you need send?");
                    Console.WriteLine("Example (addres<:>coin_need_to_send)");
                    sender.Writer(Console.ReadLine());
                    Thread.Sleep(1000);
                    Start();
                    break;
                default:
                    Console.WriteLine("Please read the list");
                    Thread.Sleep(1000);
                    Start();
                    break;
            }
        }

    }
}
