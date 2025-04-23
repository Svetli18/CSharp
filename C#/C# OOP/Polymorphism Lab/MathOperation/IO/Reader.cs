namespace Operations.IO
{
    using System;

    using Operations.IO.Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
