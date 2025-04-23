namespace BeerKegs
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            string bestKegName = string.Empty;
            double bestKegCapacity = 0;

            for (int i = 0; i < n; i++)
            {

                string currentKegName = Console.ReadLine();
                double currentKegRadius = double.Parse(Console.ReadLine());
                int currentKegHeight = int.Parse(Console.ReadLine());

                double currentKegCapacity = Math.PI * (currentKegRadius * currentKegRadius) * currentKegHeight;

                if (bestKegCapacity < currentKegCapacity)
                {
                    bestKegName = currentKegName;
                    bestKegCapacity = currentKegCapacity;
                }

            }

            Console.WriteLine(bestKegName);

        }
    }
}