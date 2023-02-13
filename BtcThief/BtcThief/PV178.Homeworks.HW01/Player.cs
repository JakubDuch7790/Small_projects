using PV178.Homeworks.HW01;
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

        public Person Find()
        {
            Random random = new Random();
            Person foundedPerson;

            Person[] people1 = new Person[] { new CommonPerson(), new RarePerson(), new EpicPerson() };

            if (random.Next(101) < (people1[0].ChanceOfDiscovery))
            {
                foundedPerson = people1[0];
            }
            else if (random.Next(101) < people1[0].ChanceOfDiscovery + people1[1].ChanceOfDiscovery)
            {
                foundedPerson = people1[1];
            }
            else
            {
                foundedPerson = people1[2];
            }

            Console.WriteLine($"You have found some guy named {foundedPerson.Name} and his IP adress is {foundedPerson.IpAdress}");

            Console.WriteLine(foundedPerson.GetType());

            return foundedPerson;
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
