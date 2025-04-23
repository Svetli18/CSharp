using System;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Regex pattern = new Regex(@"@[#]+([A-Z][A-Za-z0-9]{4,}[A-Z])@[#]+");

        for (int i = 0; i < n; i++)
        {
            Match match = pattern.Match(Console.ReadLine());

            if (match.Success)
            {
                string result = GetResult(match.Groups[1].Value);

                if (result == string.Empty)
                {
                    Console.WriteLine("Product group: 00");
                }
                else
                {
                    Console.WriteLine($"Product group: {result}");
                }
            }
            else 
            {
                Console.WriteLine("Invalid barcode");
            }
        }
    }

    static string GetResult(string value)
    {
        string result = "";

        for (int i = 0; i < value.Length; i++)
        {
            if (char.IsDigit(value[i]))
            {
                result += value[i];
            }
        }

        return result;
    }
}