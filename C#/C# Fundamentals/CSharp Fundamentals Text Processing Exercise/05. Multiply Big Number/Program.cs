using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int multiply = int.Parse(Console.ReadLine());

        string result = "";
        int remainder = 0;

        while (input != "")
        {
            string currStr = input.Last().ToString();
            int current = int.Parse(currStr);
            input = input.Remove(input.Length - 1);

            current = current * multiply;

            if (9 < current)
            {
                if (9 < (current % 10) + remainder)
                {
                    result += (((current % 10) + remainder) % 10).ToString();
                    remainder = ((current % 10) + remainder) / 10;
                }
                else
                {
                    result += ((current % 10) + remainder).ToString();
                    current = current / 10;
                    remainder = current;
                }
            }
            else if (0 <= current)
            {
                if (9 < (current % 10) + remainder)
                {
                    result += (((current % 10) + remainder) % 10).ToString();
                    remainder = ((current % 10) + remainder) / 10;
                }
                else
                {
                    result += ((current % 10) + remainder).ToString();
                    remainder = 0;
                }
            }

        }

        if (0 < remainder)
        {
            result += remainder.ToString();
        }

        Console.WriteLine(string.Join("", result.Reverse().ToArray()));

    }
}