using Afeta.Logic.ClientCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Afeta.Logic.Mining
{
    internal class MiningClass
    {

        private Lobby lobby;
        private Random random = new Random();
        private bool isWhiled = true;
        private int round = 0;

        public void Mine(Sender sender)
        {
            Console.Clear();
            Console.WriteLine("Press space to stop");
            isWhiled = true;
            while (isWhiled)
            {
                Console.Clear();
                int i = random.Next(0, 100);
                if (i == 5)
                {
                    Console.WriteLine("#" + ++round + " You find block");
                    sender.Writer("Mining");
                    sender.Writer("Balance");
                }
                else
                {
                    Console.WriteLine("#" + ++round + " You not find block");
                    sender.Writer("Balance");
                }
                Thread.Sleep(50);
            }
        }
    }
}
