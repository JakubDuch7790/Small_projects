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
        void Hack(Person foundedPerson);
        void Send(Person foundedPerson);
        void Bribe();
        void Learn();
        void Info();
        bool Win();
        bool Surrender();

    }
}