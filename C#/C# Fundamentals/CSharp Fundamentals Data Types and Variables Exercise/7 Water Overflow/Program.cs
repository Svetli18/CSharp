namespace WaterOverflow
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int litersInTheTank = 0;

            for (int i = 0; i < n; i++)
            {

                int currentLiters = int.Parse(Console.ReadLine());
                litersInTheTank += currentLiters;

                if (255 < litersInTheTank)
                {
                    Console.WriteLine("Insufficient capacity!");
                    litersInTheTank -= currentLiters;
                }

            }

            Console.WriteLine(litersInTheTank);

        }
    }
}