namespace Border.Contracts
{
    public interface ICitizen : IId
    {
        string Name { get; }

        int Age { get; }
    }
}
