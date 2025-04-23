namespace Birthday.Contracts
{
    public interface ICitizen : IBirthdate, IId, IName
    {
        int Age { get; }
    }
}
