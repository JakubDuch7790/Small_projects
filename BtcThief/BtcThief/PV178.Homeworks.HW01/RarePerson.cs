using BitCoinThief;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW01
{
    internal class RarePerson : Person
    {
        private const int chanceOfHavingBtcWallet = 100;
        private const int chanceOfDiscovery = 30;
        private readonly int[] defenceSequence = { 15, 15, 15, 15, 15 };
        private const double BtcCashUpperBound = 1.5;
        private const double BtcCashLowerBound = 0.5;

        protected override double CurrentPersonBtcCashAmountGenerator()
        {
            Random random = new Random();
            return random.NextDouble() * (BtcCashUpperBound - BtcCashLowerBound) + BtcCashLowerBound;
        }
    }
}
