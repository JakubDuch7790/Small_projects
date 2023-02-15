using PV178.Homeworks.HW01;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinThief
{
    public class Game : IGame
    {
        public bool IsSurrendered { get; private set; }

        public bool IsGameRunning { get; private set; }

        public Person CurrentHackedPerson { get; private set; }

        public bool DoesCurrentHackedPersonHaveWallet { get; private set; }

        public string AskForName()
        {
            string playersNickname;

            Console.WriteLine("Enter your nickname.");

            playersNickname = Console.ReadLine();

            if (playersNickname.Length <= 0)
            {
                Console.WriteLine("Invalid name, try again.");

                return AskForName();
            }
            Console.WriteLine($"Your hacking nickname for this game will be {playersNickname}.");

            return playersNickname;
        }

        public void EndGame()
        {
            Console.WriteLine("EndGame!");

            IsGameRunning = !IsGameRunning;
        }

        public void CheckForEndGame(Player player)
        {
            if (player.CriminalityLevel >= 5 || player.BtcWallet < - 0.001 || player.IsSurrendering)
            {
                Console.WriteLine("EndGame Hoe, and you lose.");

                EndGame();
            }
        }
        public void Start(Player player)
        {
            IsGameRunning = true;

            while (IsGameRunning)
            {
                Console.WriteLine("");
                Console.Write($"[{player.PlayersName}] ");

                ChooseCommand(player);

                CheckForEndGame(player);
            }
        }

        public void ChooseCommand(Player player)
        {
            string info;
            bool successfulSend;
            bool isWinner;

            Console.WriteLine("");
            Console.WriteLine("Commands: ");
            Console.WriteLine("");
            Console.WriteLine("1. Find ");
            Console.WriteLine("2. Hack ");
            Console.WriteLine("3. Send");
            Console.WriteLine("4. Bribe ");
            Console.WriteLine("5. Learn");
            Console.WriteLine("6. Info");
            Console.WriteLine("7. Win");
            Console.WriteLine("8. Surrender");

            Console.WriteLine("");
            Console.WriteLine("Choose command!");
            Console.WriteLine("");

            int.TryParse(Console.ReadLine(), out int command);

            Console.WriteLine("");

            switch (command)
            {
                case 1:

                    CurrentHackedPerson = player.Find();

                    DoesCurrentHackedPersonHaveWallet = CurrentHackedPerson.DoesHaveAWallet;

                    Console.WriteLine($"You have found some guy named {CurrentHackedPerson.Name} and his IP adress is {CurrentHackedPerson.IpAdress}.");

                    Console.WriteLine(CurrentHackedPerson.GetType());

                    break;

                case 2:

                    if (CurrentHackedPerson == null)
                    {
                        Console.WriteLine("First you must find someone to hack ! Are you doing this for first time ? " +
                            $" What are you? {player.PlayersName} ?");
                    }
                    else
                    {
                        Console.WriteLine($"Current Hacked Person is {CurrentHackedPerson.Name}.");

                        player.Hack(CurrentHackedPerson);

                        Console.WriteLine($"Actual Hacking Succes after this round is {player.ActualHackingSucces}.");

                        CheckForActualHackingSucces(player);

                        if (player.ActualHackingSucces < 0)
                        {
                            CurrentHackedPerson = null;
                        }
                    }

                    break;

                case 3:

                    if (CurrentHackedPerson == null)
                    {
                        Console.WriteLine("You cannot steal bitcoins if you have not hacked anyone yet fool!");
                    }
                    else
                    {
                        successfulSend = player.Send(CurrentHackedPerson);

                        if (successfulSend)
                        {
                            Console.WriteLine($"You have successufully added Bitcoins to your wallet ");
                        }
                        else
                        {
                            Console.WriteLine($"You have been discovered, your criminality level has increased to {player.CriminalityLevel}." +
                                              $" Let's find someone else.");
                        }

                        CurrentHackedPerson = null;
                    }

                    break;

                case 4:

                    if (player.CriminalityLevel == 0)
                    {
                        Console.WriteLine("Why would you want to bribe someone if no one is looking for you ? Chill you idiot ! ");
                    }
                    else
                    {
                        player.Bribe();

                        Console.WriteLine($"Your CriminalityLevel has decreased to {player.CriminalityLevel}.");
                    }

                    break;

                case 5:

                    player.Learn();

                    Console.WriteLine($"Your hacking skill has increased to {player.HackingSkill}.");

                    break;

                case 6:

                    info = player.Info();

                    Console.WriteLine(info);

                    break;

                case 7:

                    IsGameRunning =  player.Win();

                    isWinner = IsGameRunning;

                    if (!isWinner)
                    {
                        Console.WriteLine("You have won this game. Congratulation.");

                        Console.WriteLine("Now you are officially rich.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Bitcoins for win poor asshole.");
                    }

                    break;

                case 8:

                    Console.WriteLine("It seems that you will not be a bitcoin trillionaire in your lifetime after all, poor boy!");

                    IsSurrendered = player.Surrender();

                    Console.WriteLine("");

                    break;

                default:

                    Console.WriteLine("Invalid input, try again!");

                    break;
            }
        }

        public void CheckForActualHackingSucces(Player player)
        {

            if (player.ActualHackingSucces >= 30)
            {
                Console.WriteLine(DoesCurrentHackedPersonHaveWallet);

                if (!DoesCurrentHackedPersonHaveWallet)
                {
                    Console.WriteLine("This fool does not have a BTC wallet, let's hack another one!");

                    CurrentHackedPerson = null;
                }
            }

            if (player.ActualHackingSucces >= 60)
            {
                Console.WriteLine(CurrentHackedPerson.BtcWalletPassword);
            }

            if (player.ActualHackingSucces < 0)
            {
                Console.WriteLine($"You have been discovered, your criminality level has increased to {player.CriminalityLevel}.");
            }
        }
    }
}
