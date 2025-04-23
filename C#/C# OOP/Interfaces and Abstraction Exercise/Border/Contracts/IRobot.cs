namespace Border.Contracts
{
    public interface IRobot : IId
    {
        string Model { get; }
    }
}