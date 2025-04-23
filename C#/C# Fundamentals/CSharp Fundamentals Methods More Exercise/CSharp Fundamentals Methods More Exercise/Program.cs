using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string type = Console.ReadLine();

        string typeValue = Console.ReadLine();

        string result = "";

        switch (type)
        {
            case "int": result = GetIntegerResult(int.Parse(typeValue)); 
                break;
            case "real": result = GetRealResult(decimal.Parse(typeValue));
                break;
            case "string": result = GetStringResult(typeValue); 
                break;
        }

        Console.WriteLine(result);

    }

    private static string GetStringResult(string? typeValue)
    {
        string result = "$" + typeValue + "$";

        return result;
    }

    static string GetRealResult(decimal typeValue)
    {
        decimal result = typeValue * 1.5m;

        return $"{result:F2}".ToString();
    }

    static string GetIntegerResult(int typeValue)
    {
        int result = typeValue * 2;

        return result.ToString();
    }
}