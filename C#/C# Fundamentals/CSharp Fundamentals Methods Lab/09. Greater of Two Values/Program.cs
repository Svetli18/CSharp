using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string tipe = Console.ReadLine();

        string element1 = Console.ReadLine();
        string element2 = Console.ReadLine();

        if (tipe == "int")
        {
            GetMax(int.Parse(element1), int.Parse(element2));
        }
        else if (tipe == "char")
        {
            GetMax((char)element1[0], (char)element2[0]);
        }
        else if (tipe == "string")
        {
            GetMax(element1, element2);
        }

    }

    static void GetMax(int numb1, int numb2)
    {
        int result = Math.Max(numb1, numb2);

        Console.WriteLine(result);
    }

    static void GetMax(char symbol1, char symbol2)
    {
        char result = (char)Math.Max(symbol1, symbol2);

        Console.WriteLine(result);
    }

    static void GetMax(string str1, string str2)
    {
        int valueStr1 = 0;
        int valueStr2 = 0;

        for (int i = 0; i < str1.Length; i++)
        {
            valueStr1 += str1[i];
            valueStr2 += str2[i];

            if (valueStr1 <= valueStr2)
            {
                Console.WriteLine(str2);
                break;
            }
            else
            {
                Console.WriteLine(str1);
                break;
            }

        }

    }
}