using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var tryParseNumb = int.TryParse(Console.ReadLine(), out int numb);

        var wardrobe = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < numb; i++)
        {
            var curr = Console.ReadLine().Split(" -> ");

            var color = curr[0];

            if (!wardrobe.ContainsKey(color))
            {
                wardrobe[color] = new Dictionary<string, int>();
            }

            var currArgs = curr[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var cloth in currArgs)
            {
                if (!wardrobe[color].ContainsKey(cloth))
                {
                    wardrobe[color][cloth] = 0;
                }

                wardrobe[color][cloth]++;

            }

        }

        var faindArgs = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var faindColor = faindArgs[0];
        var faindTypeCloth = faindArgs[1];

        foreach (var currColorCloth in wardrobe)
        {
            Console.WriteLine($"{currColorCloth.Key} clothes:");

            foreach (var currTypeCloth in currColorCloth.Value)
            {
                if (currColorCloth.Key == faindColor && currTypeCloth.Key == faindTypeCloth)
                {
                    Console.WriteLine($"* {currTypeCloth.Key} - {currTypeCloth.Value} (found!)");
                    continue;
                }

                Console.WriteLine($"* {currTypeCloth.Key} - {currTypeCloth.Value}");

            }
        }

    }
}