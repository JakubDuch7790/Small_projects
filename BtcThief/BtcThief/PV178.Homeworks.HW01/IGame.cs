namespace PV178.Homeworks.HW01
{
    /// <summary>
    /// Allows user to play a game.
    /// </summary>
    public interface IGame
    {
        bool IsPlayersBtcWalletEmpty { get; }
        bool IsCriminalityLevelReached { get; }
        bool IsSurrendered { get;}
        void Start();
        void EndGame();
        string AskForName();
    }
}
