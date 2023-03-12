using PV178.Homeworks.HW03.Utils;
using System;
using System.IO;

namespace PV178.Homeworks.HW03
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.ChoseSong();

            game.Start();
        }
    }
}
