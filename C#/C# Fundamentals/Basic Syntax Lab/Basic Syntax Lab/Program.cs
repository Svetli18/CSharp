using System;
public class Program
{
    private static void Main(string[] args)
    {
        double grade = double.Parse(Console.ReadLine());

        string result = 3 <= grade ? "Passed!" : null;
        Console.WriteLine(result);
    }

}