namespace SOLID_Exercise.Models.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        string GetCurrentDirectory();

        void EnsureDirectoryAndFileExist();
    }
}
