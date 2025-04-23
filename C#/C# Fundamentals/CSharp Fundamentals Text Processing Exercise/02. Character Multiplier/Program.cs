using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(' ', StringSplitOptions.None);

        double sum = GetSum(input[0], input[1]);

        Console.WriteLine(sum);
    }

    static double GetSum(string str1, string str2)
    {
        double result = 0;

        if (str1.Length == str2.Length)
        {
            for (int i = 0; i < str1.Length; i++)
            {
                result += str1[i] * str2[i];
            }
        }
        else if (str1.Length < str2.Length)
        {
            for (int i = 0; i < str1.Length; i++)
            {
                result += str1[i] * str2[i];
            }
            for (int i = str1.Length; i < str2.Length; i++)
            {
                result += str2[i];
            }
        }
        else if (str2.Length < str1.Length)
        {
            for (int i = 0; i < str2.Length; i++)
            {
                result += str1[i] * str2[i];
            }
            for (int i = str2.Length; i < str1.Length; i++)
            {
                result += str1[i];
            }
        }

        return result;
    }
}