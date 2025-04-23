namespace Birthday
{
    using System;

    using Birthday.IO;
    using Birthday.Core;

    public class Program
    {
        public static void Main()
        {
            Reader reader = new Reader();
            Writer writer = new Writer();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}