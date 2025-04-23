namespace Raiding.IO
{
    using System;

    using Raiding.IO.Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
