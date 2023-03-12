using PV178.Homeworks.HW03.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03
{
    public class Game : IGame
    {
        public int Points { get; private set; }

        public void Start()
        {
            string chosenSong;

            Console.WriteLine("Choose song.");

            chosenSong = Console.ReadLine().ToLower();

            Reader reader = new Reader(chosenSong);

            Points = reader.Text.Length;

            reader.KeyPressed += reader.CheckAnswerWithPressedKey;
            reader.KeyNotPressed += reader.CheckAnswerWithEmptySpace;

            reader.ReadKeys();

            Console.WriteLine($"Congratulation, You have aquired {Reader.Points} points!");
        }

        public void ChoseSong()
        {
            List<string> songNames = new List<string>();

            string root = "C:\\Users\\Duško\\source\\repos\\JakubDuch7790\\Small_projects\\Nieber_HW03\\Sounds\\Sounds";

            //var files = from file in Directory.EnumerateFiles(root) select file;

            var filess = Directory.EnumerateFiles(root);

            foreach (var file in filess)
            {
                songNames.Add(file.ToLower());
            }
            Console.WriteLine(songNames.ToString());

        }
    }
}
