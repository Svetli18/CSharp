using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        double result = 0;
        double furstNumb = 0;
        double lastNumb = 0;

        for (int i = 0; i < input.Length; i++)
        {
            string curr = input[i];

            char first = curr.FirstOrDefault();
            char last = curr.LastOrDefault();

            double numb = double
                .Parse(string.Join("", curr.Skip(1).Take(curr.Length - 2).ToArray()));

            furstNumb = GetNumber(first);
            lastNumb = GetNumber(last);

            if (65 <= first && first <= 90)
            {
                numb /= furstNumb;
            }
            else if (97 <= first && first <= 122)
            {
                numb *= furstNumb;
            }

            if (65 <= last && last <= 90)
            {
                numb -= lastNumb;
            }
            else if (97 <= last && last <= 122)
            {
                numb += lastNumb;
            }

            result += numb;

        }

        Console.WriteLine($"{result:F2}");

    }

    static double GetNumber(char element)
    {
        double number = 0;
        switch (element)
        {
            case 'A' : number = 1;
                break;
            case 'a' : number = 1;
                break;
            case 'B': number = 2;
                break;
            case 'b': number = 2;
                break;
            case 'C': number = 3;
                break;
            case 'c': number = 3;
                break;
            case 'D': number = 4;
                break;
            case 'd': number = 4;
                break;
            case 'E': number = 5;
                break;
            case 'e': number = 5;
                break;
            case 'F': number = 6;
                break;
            case 'f': number = 6;
                break;
            case 'G': number = 7;
                break;
            case 'g': number = 7;
                break;
            case 'H': number = 8;
                break;
            case 'h': number = 8;
                break;
            case 'I': number = 9;
                break;
            case 'i': number = 9;
                break;
            case 'J': number = 10;
                break;
            case 'j': number = 10;
                break;
            case 'K': number = 11;
                break;
            case 'k': number = 11;
                break;
            case 'L': number = 12;
                break;
            case 'l': number = 12;
                break;
            case 'M': number = 13;
                break;
            case 'm': number = 13;
                break;
            case 'N': number = 14;
                break;
            case 'n': number = 14;
                break;
            case'O': number = 15;
                break;
            case'o': number = 15;
                break;
            case 'P': number = 16;
                break;
            case 'p': number = 16;
                break;
            case 'Q': number = 17;
                break;
            case 'q': number = 17;
                break;
            case 'R': number = 18;
                break;
            case 'r': number = 18;
                break;
            case 'S': number = 19;
                break;
            case 's': number = 19;
                break;
            case 'T': number = 20;
                break;
            case 't': number = 20;
                break;
            case 'U': number = 21;
                break;
            case 'u': number = 21;
                break;
            case 'V': number = 22;
                break;
            case 'v': number = 22;
                break;
            case 'W': number = 23;
                break;
            case 'w': number = 23;
                break;
            case 'X': number = 24;
                break;
            case 'x': number = 24;
                break;
            case 'Y': number = 25;
                break;
            case 'y': number = 25;
                break;
            case 'Z': number = 26;
                break;
            case 'z': number = 26;
                break;
        }

        return number;

    }
}