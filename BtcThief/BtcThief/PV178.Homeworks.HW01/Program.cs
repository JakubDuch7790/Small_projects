using PV178.Homeworks.HW01;

namespace BitCoinThief
{
    class Program
    {
        static void Main(string[] args)
        {
            MainLoop();
        }

        public static void MainLoop()
        {
            while (true)
            {
                var game = new Game();

                game.Start();

            }
        }
    }
}
