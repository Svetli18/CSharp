namespace BaseHero
{
    using Raiding.Core;
    using Raiding.Core.Contracts;

    using Raiding.IO;
    using Raiding.IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();

            IWriter writer = new Writer();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}