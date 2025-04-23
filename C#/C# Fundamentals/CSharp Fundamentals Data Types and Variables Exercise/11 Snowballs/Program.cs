namespace Snowballs
{
    using System;
    using System.Numerics;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger bestSnowballSnow = 0;
            BigInteger bestSnowballTime = 0;
            BigInteger bestSnowballQuality = 0;
            BigInteger bestSnowballValue = 0;

            for (int i = 0; i < n; i++)
            {
                int currentSnowballSnow = int.Parse(Console.ReadLine());
                int currentSnowballTime = int.Parse(Console.ReadLine());
                int currentSnowballQuality = int.Parse(Console.ReadLine());

                //int currentSnowballValue = (int)Math.Pow((snowballSnow / snowballTime), snowballQuality);

                BigInteger currentSnow = 1;
                BigInteger currentTime = 1;

                for (int j = 0; j < currentSnowballQuality; j++)
                {
                    currentSnow *= currentSnowballSnow;
                    currentTime *= currentSnowballTime;
                }

                BigInteger currentSnowballValue = currentSnow / currentTime;

                if (bestSnowballValue < currentSnowballValue)
                {
                    bestSnowballSnow = currentSnowballSnow;
                    bestSnowballTime = currentSnowballTime;
                    bestSnowballQuality = currentSnowballQuality;
                    bestSnowballValue = currentSnowballValue;
                }

            }

            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowballValue} ({bestSnowballQuality})");

        }
    }
}