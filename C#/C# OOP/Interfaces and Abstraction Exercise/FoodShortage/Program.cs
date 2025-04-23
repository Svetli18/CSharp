namespace FoodShortage
{
    using FoodShortage.Core;
    using FoodShortage.IO;

    public class Program
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