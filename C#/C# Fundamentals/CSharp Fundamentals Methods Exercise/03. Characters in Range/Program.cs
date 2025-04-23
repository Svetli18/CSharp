using System;

internal class Program
{
    private static void Main(string[] args)
    {
        char charecter1  = char.Parse(Console.ReadLine());
        char charecter2  = char.Parse(Console.ReadLine());

        int start = Math.Min(charecter1, charecter2);
        int end = Math.Max(charecter1, charecter2);

        for (int i = start + 1; i < end; i++)
        {
            Console.Write((char)i + " ");
        }

    }
}