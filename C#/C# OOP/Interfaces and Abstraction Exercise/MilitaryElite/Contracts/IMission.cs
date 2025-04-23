namespace MilitaryElite.Contracts
{
    using MilitaryElite.Enumarations;

    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
