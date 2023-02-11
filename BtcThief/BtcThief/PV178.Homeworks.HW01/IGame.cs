namespace BitCoinThief
{
    /// <summary>
    /// Allows user to play a game.
    /// </summary>
    public interface IGame
    {
        bool IsPlayersBtcWalletEmpty { get; }
        bool IsCriminalityLevelReached { get; }
        bool IsSurrendered { get;}
        void Start(Player player);
        void EndGame();
        string AskForName();
    }
}
