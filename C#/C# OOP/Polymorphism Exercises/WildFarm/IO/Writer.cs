namespace WildFarm.IO
{
    using System;

    using WildFarm.IO.Contracts;

    public class Writer : IWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
