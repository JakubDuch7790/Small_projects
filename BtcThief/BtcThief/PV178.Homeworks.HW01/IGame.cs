namespace BitCoinThief
{
    /// <summary>
    /// Allows user to play a game.
    /// </summary>
    public interface IGame
    {
        bool IsSurrendered { get;}
        bool IsGameRunning { get; }
        Person CurrentHackedPerson { get; }
        void Start(Player player);
        void EndGame();
        string AskForName();
        void CheckForEndGame(Player player);
        void ChooseCommand(Player player);
    }
}
