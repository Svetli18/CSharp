using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
                                  //>>([A-Z][A-Za-z]+)<<([\d]+\.?[\d]*)!(\d+)
        Regex pattern = new Regex(@">>([A-Z][A-Za-z]+)<<(\d+\.?\d*)!(\d+)");

        decimal totalSpendMoney = 0;
        List<string> furnitureNames = new List<string>();

        string command;
        while ((command = Console.ReadLine()) != "Purchase")
        {
            Match match = pattern.Match(command);

            if (match.Success)
            {
                string name = match.Groups[1].Value;
                decimal price = decimal.Parse(match.Groups[2].Value);
                int quantity = int.Parse(match.Groups[3].Value);

                furnitureNames.Add(name);
                totalSpendMoney += price * quantity;
            }

        }

        if (0 < furnitureNames.Count)
        {
            Console.WriteLine("Bought furniture:");
            Console.WriteLine(string.Join(Environment.NewLine, furnitureNames));
            Console.WriteLine($"Total money spend: {totalSpendMoney:F2}");
        }

    }
}