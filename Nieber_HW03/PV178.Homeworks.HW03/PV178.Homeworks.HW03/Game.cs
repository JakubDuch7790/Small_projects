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
            Console.WriteLine("Choose song.");
            Console.WriteLine(" ");

            //List<string> songNames = new List<string>();

            string root = "C:\\Users\\Duško\\source\\repos\\JakubDuch7790\\Small_projects\\Nieber_HW03\\PV178.Homeworks.HW03\\PV178.Homeworks.HW03\\Songs";
            DirectoryInfo directoryInfo = new DirectoryInfo(root);

            FileInfo[] songNames1 = directoryInfo.GetFiles();

            //var files = Directory.EnumerateFiles(root);

            foreach (FileInfo f in songNames1)
            {
                Console.WriteLine(Path.GetFileNameWithoutExtension(f.FullName));
            }


            //foreach (var file in files)
            //{
            //    songNames.Add(file.ToLower());
            //}
            //Console.WriteLine(songNames.Select(songNames.));

        }
    }
}
