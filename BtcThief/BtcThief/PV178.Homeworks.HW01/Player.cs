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
        public int ActualHackingSucces { get; private set; }

        public Player(string playersName, double btcWallet = 0.05, int hackingSkill = 26, int criminalityLevel = 0)
        {
            BtcWallet = btcWallet;
            HackingSkill = hackingSkill;
            CriminalityLevel = criminalityLevel;
            PlayersName = playersName;
        }

        public Person Find()
        {
            BtcWallet -= 0.01;
            Random random = new Random();
            Person foundedPerson;
            ActualHackingSucces = 0;

            Person[] people1 = new Person[] { new CommonPerson(), new RarePerson(), new EpicPerson() };

            int personsDiscovery = random.Next(101);

            if (personsDiscovery < (people1[2].ChanceOfDiscovery))
            {
                foundedPerson = people1[2];
            }
            else if (personsDiscovery < people1[2].ChanceOfDiscovery + people1[1].ChanceOfDiscovery)
            {
                foundedPerson = people1[1];
            }
            else
            {
                foundedPerson = people1[0];
            }

            return foundedPerson;
        }

        public void Hack(Person foundedPerson)
        {
            //bool DoesFoundedPersonHaveAWallet;

            Console.WriteLine($"Current Hacked Person is {foundedPerson.Name}.");

            Random random = new Random();

            ActualHackingSucces += random.Next(HackingSkill);

            ActualHackingSucces -= foundedPerson.DefenceSequence[foundedPerson.DefenceSequencePointer];

            if (ActualHackingSucces >= 100)
            {
                ActualHackingSucces = 100;
            }


            if (ActualHackingSucces < 0)
            {
                CriminalityLevel += 1;
            }

            if (foundedPerson.DefenceSequence.Length - 1 > foundedPerson.DefenceSequencePointer)
            {
                foundedPerson.DefenceSequencePointer += 1;
            }
            else
            {
                foundedPerson.DefenceSequencePointer = 0;
            }
        }

        public bool Send(Person foundedplayer)
        {
            Random random = new Random();

            if (random.Next(101) < ActualHackingSucces)
            {
                BtcWallet += foundedplayer.BtcCashamount;

                return true;
            }
            else
            {
                CriminalityLevel += 1;

                return false;
            }
        }

        public void Bribe()
        {
            BtcWallet -= 0.05;
            CriminalityLevel -= 1;
        }

        public void Learn()
        {
            BtcWallet -= 0.005;
            HackingSkill += 1;
        }

        public string Info()
        {
            string info = $"You have {BtcWallet} Bitcoins in your wallet. "
                        + $"Your Hacking Skill is currently { HackingSkill },"
                        + $" and Criminality level is at {CriminalityLevel}.";
            return info;
        }

        public bool Win()
        {
            if (BtcWallet >= 5)
            {
                return false;
            }
            return true;
        }

        public bool Surrender()
        {
            return IsSurrendering = true;
        }
    }
}
