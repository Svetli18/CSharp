using System;

public class Program
{
    private static void Main(string[] args)
    {
        int cnt = int.Parse(Console.ReadLine());

        int n = 1;

        int sum = 0;

        while (0 < cnt)
        {
            if (n % 2 != 0)
            {
                cnt--;
                sum += n;
                Console.WriteLine(n);
            }

            n++;
        }

        Console.WriteLine($"Sum : {sum}");
    }
}