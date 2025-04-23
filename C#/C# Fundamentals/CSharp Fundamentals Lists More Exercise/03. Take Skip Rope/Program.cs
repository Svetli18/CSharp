using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        List<int> numbers = new List<int>();
        List<string> nonNumbers = new List<string>();

        SeparateDigitsFromNonDigitsLists(text, numbers, nonNumbers);

        List<int> takeList = new List<int>();
        List<int> skipList = new List<int>();

        SeparateListToEvensAndOddsToTwoColections(numbers, takeList, skipList);

        List<string> temp = new List<string>(nonNumbers);

        string result = "";

        int skipElements = 0;

        for (int i = 0; i < takeList.Count; i++)
        {
            int take = takeList[i];
            int skip = skipList[i];

            temp = nonNumbers.Skip(skipElements).Take(take).ToList();

            result += string.Join("", temp);

            skipElements += take + skip;
        }

        Console.WriteLine(result);

    }

    static void SeparateListToEvensAndOddsToTwoColections(List<int> numbers, List<int> take, List<int> skip)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 == 0)
            {
                take.Add(numbers[i]);
                continue;
            }

            skip.Add(numbers[i]);

        }
    }

    static void SeparateDigitsFromNonDigitsLists(string text, List<int> numbers, List<string> nonNumbers)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i]))
            {
                numbers.Add(int.Parse(text[i].ToString()));
                continue;
            }

            nonNumbers.Add(text[i].ToString());

        }
    }
}