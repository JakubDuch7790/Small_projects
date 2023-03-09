using PV178.Homeworks.HW03.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03
{
    public class Game : IGame
    {
        public void Start()
        {
            string chosenSong;

            Console.WriteLine("Choose song.");

            chosenSong = Console.ReadLine().ToLower();

            Reader reader = new Reader(chosenSong);

            reader.ReadKeys();
        }
    }
}
