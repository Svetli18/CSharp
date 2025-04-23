namespace SOLID_Exercise.Models.Contracts
{
    using System;

    public interface IFile
    {
        string Path { get; }

        ulong Size { get; }

        string Write(ILayout layout, IError error);
    }
}
