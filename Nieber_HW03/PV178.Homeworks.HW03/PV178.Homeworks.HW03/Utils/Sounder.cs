using System;
using System.IO;
using System.Media;
using System.Threading;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Class for making sound in other thread.
    /// </summary>
    public static class Sounder
    {
        /// <summary>
        /// Makes sound with given frequency and duration.
        /// </summary>
        /// <param name="frequency">frequency</param>
        /// <param name="duration">duration</param>
        
        public static void MakeSound(int frequency, int duration = 300)
        {
            ThreadPool.QueueUserWorkItem(state =>
                Console.Beep(frequency, duration));
        }
        public static void MakeCoolSound(char key, int duration)
        {
            var sound = new SoundPlayer($@"C:\Users\Duško\source\repos\JakubDuch7790\Small_projects\Nieber_HW03\Sounds\Sounds\piano-{key}.wav");
            ThreadPool.QueueUserWorkItem(state =>
                sound.PlaySync());

            //sound.PlaySync();
        }
    }
}
