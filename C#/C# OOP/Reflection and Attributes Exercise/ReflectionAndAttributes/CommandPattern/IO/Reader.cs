namespace CommandPattern.IO
{
    using System;
    using CommandPattern.IO.Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
