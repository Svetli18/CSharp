namespace SOLID_Exercise.Models.Contracts
{
    using SOLID_Exercise.Models.Enumerations;

    public interface IError
    {
        Level Level { get; }

        DateTime DateTime { get; }

        string Message { get; }
    }
}
