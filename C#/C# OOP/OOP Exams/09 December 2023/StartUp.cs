namespace NauticalCatchChallenge
{
    using NauticalCatchChallenge.Core;
    using NauticalCatchChallenge.Core.Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            //int x = 200;

            //int y = 100;

            //x -= (int)Math.Round((decimal)y * 0.60m, MidpointRounding.AwayFromZero);

            //Console.WriteLine(x);

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}