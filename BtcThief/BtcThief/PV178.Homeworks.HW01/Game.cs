using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW01
{
    public class Game : IGame
    {
        public bool IsPlayersBtcWalletEmpty => throw new NotImplementedException();

        public bool IsCriminalityLevelReached => throw new NotImplementedException();

        public bool IsSurrendered => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }

        public void Start()
        {
            AskForName();
        }
        
    }
}
