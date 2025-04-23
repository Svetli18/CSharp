namespace Operations.IO
{
    using System;

    using Operations.IO.Contracts;

    public class Writer<T> : IWriter<T>
    {
        public void Write(T value)
        {
            Console.Write(value);
        }

        public void WriteLine(T value)
        {
            Console.WriteLine(value);
        }
    }
}
