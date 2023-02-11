using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW01
{
    internal class Player : IPlayer
    {
        public double BtcWallet { get; set; }
        public int HackingSkill { get; set; }
        public int CriminalityLevel { get; set; }
        public string PlayersName { get; set; }

        public Player(string playersName, double btcWallet = 0.05, int hackingSkill = 26, int criminalityLevel = 0)
        {
            BtcWallet = btcWallet;
            HackingSkill = hackingSkill;
            CriminalityLevel = criminalityLevel;
            PlayersName = playersName;
        }

        public Person Find()
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

        public void Surrender()
        {
            throw new NotImplementedException();
        }
    }
}
