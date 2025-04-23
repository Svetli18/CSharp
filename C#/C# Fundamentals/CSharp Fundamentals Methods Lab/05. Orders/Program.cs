using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string product = Console.ReadLine();

        int count = int.Parse(Console.ReadLine());

        decimal price = GetOrderPrice(product, count);

        Console.WriteLine($"{price:F2}");

    }

    static decimal GetOrderPrice(string product, int count)
    {
        decimal price = 0;

        switch (product)
        {
            case "coffee": price = count * 1.50m;
                break;
            case "water": price = count * 1.00m;
                break;
            case "coke": price = count * 1.40m;
                break;
            case "snacks": price = count * 2.00m;
                break;
        }

        return price;

    }
}