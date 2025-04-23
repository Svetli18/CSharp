using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var shops = new SortedDictionary<string, Dictionary<string, double>>();

        var command = "";
        while ((command = Console.ReadLine()) != "Revision")
        {
            var commandArgs = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var shopName = commandArgs[0];
            var productName = commandArgs[1];
            var priceIsValid = double.TryParse(commandArgs[2], out double productPrice);

            if (!shops.ContainsKey(shopName))
            {
                shops[shopName] = new Dictionary<string, double>();
            }

            shops[shopName][productName] = productPrice;

        }

        foreach (var shop in shops)
        {
            Console.WriteLine($"{shop.Key}->");

            foreach (var products in shop.Value)
            {
                Console.WriteLine($"Product: {products.Key}, Price: {products.Value}");
            }
        }

    }
}