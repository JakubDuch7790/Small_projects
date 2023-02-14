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
        public bool IsPlayersBtcWalletEmpty => throw new NotImplementedException();

        public bool IsCriminalityLevelReached => throw new NotImplementedException();

        public bool IsSurrendered => throw new NotImplementedException();

        public bool IsGameRunning { get; set; }

        public string AskForName()
        {
            string playersNickname;
            Console.WriteLine("Enter your nickname");

            playersNickname = Console.ReadLine();

            if (playersNickname.Length <= 0)
            {
                Console.WriteLine("Invalid name, try again");
                AskForName();
            }
            Console.WriteLine($"Your hacking nickname for this game will be {playersNickname}");
            return playersNickname;
        }

        public void EndGame()
        {
            IsGameRunning = !IsGameRunning;
        }

        public void CheckForEndGame(Player player)
        {
            if (player.CriminalityLevel >= 5 || player.BtcWallet <= 0 || player.IsSurrendering)
            {
                Console.WriteLine("EndGame Hoe");
                EndGame();
            }
        }
        public void Start(Player player)
        {
            IsGameRunning = true;
            while (IsGameRunning)
            {

                Console.Write($"[{player.PlayersName}] ");

                ChooseCommand(player);

                CheckForEndGame(player);
            }
        }

        public void ChooseCommand(Player player)
        {

            Console.WriteLine("Commands: ");
            Console.WriteLine("1. Find ");
            Console.WriteLine("2. Hack ");
            Console.WriteLine("3. Send");
            Console.WriteLine("4. Bribe ");
            Console.WriteLine("5. Learn");
            Console.WriteLine("6. Info");
            Console.WriteLine("7. Win");
            Console.WriteLine("8. Surrender");

            Console.WriteLine("Choose command");

            var chosenCommand = int.Parse(Console.ReadLine());

            switch (chosenCommand)
            {
                case 1:
                    player.Find();
                    break;

                case 2:
                    player.Hack();
                    break;

                case 3:
                    player.Send();
                    break;

                case 4:
                    player.Bribe();
                    break;

                case 5:
                    player.Learn();
                    break;

                case 6:
                    player.Info();
                    break;

                case 7:
                    player.Win();
                    break;

                case 8:
                    player.Surrender();
                    break;

                default:

                    Console.WriteLine("Invalid input, try again");
                    break;
            }
        }
    }
}
