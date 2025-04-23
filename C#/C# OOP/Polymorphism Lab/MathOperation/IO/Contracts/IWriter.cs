namespace Operations.IO.Contracts
{
    public interface IWriter<T>
    {
        void Write(T value);

        void WriteLine(T value);
    }
}
