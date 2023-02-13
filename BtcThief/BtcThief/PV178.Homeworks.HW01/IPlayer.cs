namespace BitCoinThief
{
    public interface IPlayer
    {
        double BtcWallet { get; }
        int CriminalityLevel { get; }
        int HackingSkill { get; }
        string PlayersName { get; }
        bool IsSurrendering { get;}
        Person Find();
        void Hack();
        void Send();
        void Bribe();
        void Learn();
        void Info();
        void Win();
        bool Surrender();

    }
}