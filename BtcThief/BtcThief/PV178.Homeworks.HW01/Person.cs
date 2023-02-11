using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinThief
{
    abstract class Person
    {
        public int ChanceOfHavingWallet { get; private set; }
        public string Name { get; private set; }
        public string IpAdress { get; set; }
        public string BtcWalletAdress { get; set; }
        public string BtcWalletPassword { get; set; }




    }
}
