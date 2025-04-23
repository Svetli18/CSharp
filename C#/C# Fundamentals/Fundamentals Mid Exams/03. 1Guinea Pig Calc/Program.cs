using System;

internal class Program
{
    private static void Main(string[] args)
    {
        float food = float.Parse(Console.ReadLine());
        float hay = float.Parse(Console.ReadLine());
        float cover = float.Parse(Console.ReadLine());
        float guineaWeightInKilograms = float.Parse(Console.ReadLine());

        float foodInGrams = food * 1000;
        float hayInGrams = hay * 1000;
        float coverInGrams = cover * 1000;
        float guineaWeightInGrams = guineaWeightInKilograms * 1000;

        bool IsMerryNeedToGoInStore = false;

        for (int i = 1; i <= 30; i++)
        {
            if (foodInGrams - 300 < 0)
            {
                IsMerryNeedToGoInStore = true;
                break;
            }

            foodInGrams -= 300;

            if (i % 2 == 0)
            {
                float getHayInGrams = foodInGrams - (foodInGrams * 0.95f);

                if (hayInGrams - getHayInGrams < 0)
                {
                    IsMerryNeedToGoInStore = true;
                    break;
                }

                hayInGrams -= getHayInGrams;

            }

            if (i % 3 == 0)
            {
                float getCoverInGrams = guineaWeightInGrams / 3;

                if (coverInGrams - getCoverInGrams < 0)
                {
                    IsMerryNeedToGoInStore = true;
                    break;
                }

                coverInGrams -= getCoverInGrams;
            }
        }

        if (IsMerryNeedToGoInStore)
        {
            Console.WriteLine("Merry must go to the pet store!");
        }
        else
        {
            food = foodInGrams / 1000;
            hay = hayInGrams / 1000;
            cover = coverInGrams / 1000;

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:F2}, Hay: {hay:F2}, Cover: {cover:F2}.");
        }

    }
}