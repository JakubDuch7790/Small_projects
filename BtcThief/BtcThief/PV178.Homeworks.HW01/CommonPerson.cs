using BitCoinThief;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW01
{
    internal class CommonPerson : Person
    {
        private const int chanceOfHavingBtcWallet = 75;
        private const int chanceOfDiscovery = 60;
        private readonly int[] defenceSequence = { 0, 10, 0, 10, 0, 10 };
        private const double BtcCashUpperBound = 0.5;
        private const double BtcCashLowerBound = 0;

        public CommonPerson() : base()
        {
            ChanceOfHavingWallet = chanceOfHavingBtcWallet;
            ChanceOfDiscovery = chanceOfDiscovery;
            DefenceSequence = defenceSequence;
            BtcCashamount = CurrentPersonBtcCashAmountGenerator();
        }

        protected override double CurrentPersonBtcCashAmountGenerator()
        {
            Random random = new Random();
            return random.NextDouble() * (BtcCashUpperBound - BtcCashLowerBound) + BtcCashLowerBound;
        }
    }
}
