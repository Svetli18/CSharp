using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class Product
{
    public Product(string name, int count, decimal price)
    {
        Name = name;
        Count = count;
        Price = price;
    }

    public string Name { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }

    public decimal TotalPrice => Price * Count;
}

internal class Program
{
    private static void Main(string[] args)
    {
        Regex pattern = new 
            Regex(@"^%([A-Z][a-z]+)%[^|$%\.]*<(\w+)>[^|$%\.]*\|(\d+)\|[^|$%\.]*?(\d+\.?\d+)\$");
                   //%([A-Z][a-z]+)%[^|$%\.]*?<(\w+)>[^|$%\.]*?\|(\d+)\|[^|$%\.]*?(\d+\.?\d*)\$
        Dictionary<string, Product> customers = new Dictionary<string, Product>();

        string comment;
        while ((comment = Console.ReadLine()) != "end of shift")
        {
            Match match = pattern.Match(comment);

            if (match.Success)
            {
                string customerName = match.Groups[1].ToString();
                string productName = match.Groups[2].ToString();

                int count = int.Parse(match.Groups[3].ToString());
                decimal price = decimal.Parse(match.Groups[4].ToString());

                Product product = new Product(productName, count, price);

                customers[customerName] = product;

            }

        }

        decimal totalIncome = 0;

        foreach (var kvp in customers)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value.Name} - {kvp.Value.TotalPrice:F2}");
            totalIncome += kvp.Value.TotalPrice;
        }

        Console.WriteLine($"Total income: {totalIncome:F2}");
    }
}