namespace BitCoinThief
{
    internal interface IPlayer
    {
        double BtcWallet { get; set; }
        int CriminalityLevel { get; set; }
        int HackingSkill { get; set; }
        string PlayersName { get; }
        bool IsSurrendering { get;}
        void Find();
        void Hack();
        void Send();
        void Bribe();
        void Learn();
        void Info();
        void Win();
        bool Surrender();

    }
}