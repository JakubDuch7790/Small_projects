using PV178.Homeworks.HW01.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinThief
{
    public abstract class Person
    {
        public int ChanceOfHavingWallet { get; protected set; }
        public string Name { get; private set; }
        public string IpAdress { get; private set; }
        public string BtcWalletAdress { get; private set; }
        public string BtcWalletPassword { get; private set; }
        public double BtcCashamount { get; protected set; }
        public int ChanceOfDiscovery { get; protected set; }
        public int[] DefenceSequence { get; protected set; }
        public int DefenceSequencePointer { get; set; }
        public bool DoesHaveAWallet 
        {
            get
            {
                Random random = new Random();

                return random.Next(101) < ChanceOfHavingWallet;
            }
        }

        public Person()
        {
            Name = Generator.GetName();
            IpAdress = Generator.GetIp();
            BtcWalletAdress = Generator.GetBtcAddress();
            BtcWalletPassword = Generator.GetPassword();
            DefenceSequencePointer = 0;
        }
        protected abstract double CurrentPersonBtcCashAmountGenerator();
    }
}
