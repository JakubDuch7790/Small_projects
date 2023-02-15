using PV178.Homeworks.HW01;

namespace BitCoinThief
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var player = new Player(game.AskForName());

            game.Start(player);
        }
    }
}
