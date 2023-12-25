using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afeta.Logic.Other
{
    internal class CreateWallet
    {

        public void Create(string name)
        {
            File.Create(@"Afeta_Data/Wallet.txt").Close();
            File.WriteAllText(@"Afeta_Data/Wallet.txt", name);
        }

    }
}
