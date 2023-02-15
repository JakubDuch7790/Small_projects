using BitCoinThief;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW01
{
    internal class EpicPerson : Person
    {
        private const int chanceOfHavingBtcWallet = 100;
        private const int chanceOfDiscovery = 10;
        private readonly int[] defenceSequence = { 10, 15, 20, 10, 15 };
        private const double BtcCashUpperBound = 2.5;
        private const double BtcCashLowerBound = 1;

        public EpicPerson() : base()
        {
            ChanceOfDiscovery = chanceOfDiscovery;
            ChanceOfHavingWallet = chanceOfHavingBtcWallet;
            DefenceSequence = defenceSequence;
        }

        protected override double CurrentPersonBtcCashAmountGenerator()
        {
            Random random = new Random();
            return random.NextDouble() * (BtcCashUpperBound - BtcCashLowerBound) + BtcCashLowerBound;
        }
    }
}
