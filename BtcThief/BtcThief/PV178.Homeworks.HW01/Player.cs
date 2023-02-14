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

            Console.WriteLine($"You have found some guy named {foundedPerson.Name} and his IP adress is {foundedPerson.IpAdress}");

            Console.WriteLine(foundedPerson.GetType());

            return foundedPerson;
        }

        public void Hack(Person foundedPerson)
        {
            Console.WriteLine($"Current Hacked Person is {foundedPerson.Name}");
        }

        public void Send()
        {
            throw new NotImplementedException();
        }

        public void Bribe()
        {
            BtcWallet -= 0.05;
            CriminalityLevel -= 1;
            Console.WriteLine($"Your CriminalityLevel has decreased to {CriminalityLevel}");
        }

        public void Learn()
        {
            BtcWallet -= 0.005;
            HackingSkill += 1;
            Console.WriteLine($"Your hacking skill has increased to {HackingSkill}");
        }

        public void Info()
        {
            Console.WriteLine($"You have {BtcWallet} Bitcoins in your wallet");
            Console.WriteLine("Hacking skill = " + HackingSkill);
            Console.WriteLine($"Your Criminality Level is {CriminalityLevel}");
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
