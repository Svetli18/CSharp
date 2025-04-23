using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var productAndPrice = new Dictionary<string, decimal>();
        var productAndQuantity = new Dictionary<string, int>();

        string cmd;
        while ((cmd = Console.ReadLine()) != "buy")
        {
            string[] currArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = currArgs[0];
            decimal price = decimal.Parse(currArgs[1]);
            int quantity = int.Parse(currArgs[2]);

            if (!productAndPrice.ContainsKey(name))
            {
                productAndPrice[name] = 0;
                productAndQuantity[name] = 0;
            }

            productAndPrice[name] = price;
            productAndQuantity[name] += quantity;
        }

        foreach (var product in productAndPrice)
        {
            string name = product.Key;
            int quantity = productAndQuantity[name];
            decimal price = product.Value * quantity;
            Console.WriteLine($"{name} -> {price:F2}");
        }
    }
}