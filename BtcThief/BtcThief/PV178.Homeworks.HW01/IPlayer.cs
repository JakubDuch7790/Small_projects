namespace PV178.Homeworks.HW01
{
    internal interface IPlayer
    {
        double BtcWallet { get; set; }
        int CriminalityLevel { get; set; }
        int HackingSkill { get; set; }
        string PlayersName { get; set; }
        Person Find();
        void Hack();
        void Send();
        void Bribe();
        void Learn();
        void Info();
        void Win();
        void Surrender();

    }
}