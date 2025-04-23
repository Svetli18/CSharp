namespace Telephony
{

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IEngine engine = new Engine(reader, writer);
            engine.Run();

        }

    }

}
