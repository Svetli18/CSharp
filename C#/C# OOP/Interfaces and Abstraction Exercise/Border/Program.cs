namespace Border
{
    using Border.IO;
    using Border.Core;

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