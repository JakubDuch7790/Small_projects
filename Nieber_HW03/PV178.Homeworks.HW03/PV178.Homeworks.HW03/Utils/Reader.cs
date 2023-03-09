﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Class responsible for reading songs from textfiles and handling user input.
    /// </summary>
    public class KeyNotPressedEventArgs : EventArgs
    {
        public int Position { get; set; }
    }
    public class KeyPressedEventArgs : EventArgs
    {
        public char Key { get; set; }
        public int Position { get; set; }
    }
    public class Reader : IDisposable
    {
        public event EventHandler KeyPressed;
        public event EventHandler KeyNotPressed;

        //public void KeyPressedEventHandler(object source, KeyPressedEventArgs args);

        //public  void KeyNotPressedEventHandler(object source, KeyNotPressedEventArgs args);

        public int Freq { get; set; }
        public string Text { get; set; }
        private const int Timeout = 500;
        private readonly Displayer displayer = new Displayer();

        private AutoResetEvent trackDone;
        private Thread checkingThread;
        private Thread gettingThread;
        private char? input;
        private bool end;
        private readonly Dictionary<char, Tone> tones = new Dictionary<char, Tone>();

        public Reader(string songName)
        {
            if (File.Exists(@"..\..\Songs\" + songName + ".txt"))
            {
                Text = File.ReadAllText(@"..\..\Songs\" + songName + ".txt");
                trackDone = new AutoResetEvent(false);
                checkingThread = new Thread(CheckInput) { IsBackground = true };
                gettingThread = new Thread(GetInput) { IsBackground = true };

                FillDictionary(tones);
            }
            else
            {
                throw new ArgumentException("Wrong song path");
            }
        }

        /// <summary>
        /// Starts reading keys and checking whether user pressed some.
        /// </summary>
        public void ReadKeys()
        {
            gettingThread.Start();
            checkingThread.Start();
            trackDone.WaitOne();
        }

        /// <summary>
        /// Performs cleanup.
        /// </summary>
        public void Dispose()
        {
            end = true;
            trackDone.Dispose();
            Console.Clear();
        }

        /// <summary>which key was pressed and what is actual reading position.
        /// </summary>
        /// Invokes event that says 
        /// <param name="key">pressed key</param>
        /// <param name="position">actual reading position</param>
        protected virtual void OnKeyPressed(char key, int position)
        {
            KeyPressed?.Invoke(this, new KeyPressedEventArgs() {Key = key, Position = position});
        }

        /// <summary>
        /// Invokes event that says no key was pressed and what is actual reading position.
        /// </summary>
        /// <param name="position">actual reading position</param>
        protected virtual void OnKeyNotPressed(int position)
        {
            KeyNotPressed?.Invoke(this, new KeyNotPressedEventArgs() { Position = position });
        }

        /// <summary>
        /// Periodically checks if some key was pressed.
        /// </summary>
        private void CheckInput()
        {
            for (var i = -6; i < Text.Length; i++)
            {
                displayer.ActualDisplay(Text, i + 6);
                Thread.Sleep(Timeout);
                // First chars just skip (because animation)
                if (i < 0)
                {
                    continue;
                }
                if (input != null)
                {
                    OnKeyPressed((char)input, i);
                    input = null;
                }
                else
                {
                    OnKeyNotPressed(i);
                }
            }
            trackDone.Set();
        }

        /// <summary>
        /// Gets input from the user.
        /// </summary>
        private void GetInput()
        {
            while (true)
            {
                input = Console.ReadKey(true).KeyChar;

                if (input != null && !end)
                {
                    var pressedKey = (char)input;
                    if (tones.ContainsKey(pressedKey))
                    {
                        Sounder.MakeSound(tones[pressedKey].FrequencyOfTone);
                    }
                }
            }
        }

        private void FillDictionary(Dictionary<char, Tone> dictionary)
        {
            dictionary.Add('a', new Tone('a', "C", 261));
            dictionary.Add('s', new Tone('s', "D", 293));
            dictionary.Add('d', new Tone('d', "E", 330));
            dictionary.Add('f', new Tone('f', "F", 349));
            dictionary.Add('g', new Tone('g', "G", 392));
            dictionary.Add('h', new Tone('h', "A", 440));
            dictionary.Add('j', new Tone('j', "H", 494));
        }
    }
}