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

            Console.WriteLine($"You have found some guy named {foundedPerson.Name} and his IP adress is {foundedPerson.IpAdress}.");

            Console.WriteLine(foundedPerson.GetType());

            return foundedPerson;
        }

        public void Hack(Person foundedPerson)
        {
            bool DoesFoundedPersonHaveAWallet;

            Console.WriteLine($"Current Hacked Person is {foundedPerson.Name}.");

            Random random = new Random();

            ActualHackingSucces += random.Next(HackingSkill);

            ActualHackingSucces -= foundedPerson.DefenceSequence[foundedPerson.DefenceSequencePointer];

            if (ActualHackingSucces >= 100)
            {
                ActualHackingSucces = 100;
            }
            
            if (ActualHackingSucces >= 30)
            {
                DoesFoundedPersonHaveAWallet = foundedPerson.DoesHaveAWallet;

                Console.WriteLine(DoesFoundedPersonHaveAWallet);

                if (!DoesFoundedPersonHaveAWallet)
                {
                    Console.WriteLine("This fool does not have a BTC wallet, let's hack another one!");
                }
            }

            if (ActualHackingSucces >= 60)
            {
                Console.WriteLine(foundedPerson.BtcWalletPassword);
            }

            if (ActualHackingSucces < 0)
            {
                CriminalityLevel += 1;

                Console.WriteLine($"You have been discovered, your criminality level has increased to {CriminalityLevel}");
            }

            Console.WriteLine($"Actual Hacking Succes after this round is {ActualHackingSucces}");

            if (foundedPerson.DefenceSequence.Length - 1 > foundedPerson.DefenceSequencePointer)
            {
                foundedPerson.DefenceSequencePointer += 1;
            }
            else
            {
                foundedPerson.DefenceSequencePointer = 0;
            }
        }

        public void Send(Person foundedplayer)
        {
            Random random = new Random();

            if (random.Next(101) < ActualHackingSucces)
            {
                BtcWallet += foundedplayer.BtcCashamount;
            }
            else
            {
                CriminalityLevel += 1;
                Console.WriteLine($"You have been discovered, your criminality level has increased to {CriminalityLevel}");
            }
        }

        public void Bribe()
        {
            BtcWallet -= 0.05;
            CriminalityLevel -= 1;
            Console.WriteLine($"Your CriminalityLevel has decreased to {CriminalityLevel}.");
        }

        public void Learn()
        {
            BtcWallet -= 0.005;
            HackingSkill += 1;
            Console.WriteLine($"Your hacking skill has increased to {HackingSkill}.");
        }

        public void Info()
        {
            Console.WriteLine($"You have {BtcWallet} Bitcoins in your wallet.");
            Console.WriteLine("Hacking skill = " + HackingSkill);
            Console.WriteLine($"Your Criminality Level is {CriminalityLevel}.");
        }

        public bool Win()
        {
            if (BtcWallet >= 5)
            {
                Console.WriteLine("You have won this game. Congratulation.");
                Console.WriteLine("Now you are officially rich.");
                return false;
            }
            Console.WriteLine("Not enough Bitcoins for win poor asshole.");
            return true;
        }

        public bool Surrender()
        {
            return IsSurrendering = true;
        }
    }
}
