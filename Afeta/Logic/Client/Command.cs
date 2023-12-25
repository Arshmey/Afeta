using Afeta.Logic.Other;
using System;
using System.Collections.Generic;

namespace Afeta.Logic.Client
{
    internal class Command
    {

        private List<string> command = new List<string>();

        public Command() 
        {
            command.Add("Balance");
            command.Add("Transfer");
        }

        public void Execute(string[] commandProcessed)
        {
            switch (commandProcessed[0])
            {
                case "Balance":
                    Console.WriteLine("You have: " + commandProcessed[1] + " coins.");
                    break;
                case "Transfer":
                    Console.WriteLine("You have gift: " + commandProcessed[1] + " coins.");
                    break;
                default: 
                    break;
            }
        }

        public List<string> getCommand()
        {
            return command;
        }


    }
}
