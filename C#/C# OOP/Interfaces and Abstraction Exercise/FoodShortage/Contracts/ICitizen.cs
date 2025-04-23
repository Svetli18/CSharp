namespace FoodShortage.Contracts
{
    public interface ICitizen : IPerson
    {
        string Id { get; }

        DateTime DateTime { get; }
    }
}
