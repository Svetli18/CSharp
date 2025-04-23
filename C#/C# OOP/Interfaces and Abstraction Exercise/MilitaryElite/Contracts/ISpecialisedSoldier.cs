namespace MilitaryElite.Contracts
{
    using MilitaryElite.Enumarations;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
