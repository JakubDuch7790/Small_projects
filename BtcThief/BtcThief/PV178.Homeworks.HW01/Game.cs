using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
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
                System.Console.WriteLine($"[{player.PlayersName}]");
                System.Console.WriteLine("Commands: 1. Find" + Environment.NewLine + 
                    "2. Hack, send, bribe, learn, info, win, surrender");

                Console.WriteLine("Choose command");

                CheckForEndGame(player);
            }
        }

        public void IsGitignoreWorking()
        {
            return;
        }
    }

    
}
