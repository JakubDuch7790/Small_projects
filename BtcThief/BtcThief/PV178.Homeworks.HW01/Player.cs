using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinThief
{
    public class Player : IPlayer
    {
        public double BtcWallet { get; private set; }
        public int HackingSkill { get; private set; }
        public int CriminalityLevel { get; private set; }
        public string PlayersName { get; private set; }
        public bool IsSurrendering { get; private set; }

        public Player(string playersName, double btcWallet = 0.05, int hackingSkill = 26, int criminalityLevel = 0)
        {
            BtcWallet = btcWallet;
            HackingSkill = hackingSkill;
            CriminalityLevel = criminalityLevel;
            PlayersName = playersName;
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        public void Hack()
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            throw new NotImplementedException();
        }

        public void Bribe()
        {
            throw new NotImplementedException();
        }

        public void Learn()
        {
            throw new NotImplementedException();
        }

        public void Info()
        {
            throw new NotImplementedException();
        }

        public void Win()
        {
            throw new NotImplementedException();
        }

        public bool Surrender()
        {
            return IsSurrendering = true;
        }
    }
}
