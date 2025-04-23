namespace MilitaryElite
{
    using MilitaryElite.Core;
    using MilitaryElite.IO;
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}