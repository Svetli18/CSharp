using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int employee1 = int.Parse(Console.ReadLine());
        int employee2 = int.Parse(Console.ReadLine());
        int employee3 = int.Parse(Console.ReadLine());

        int students = int.Parse(Console.ReadLine());

        int time = 0;

        while (0 < students)
        {
            time++;
            if (time % 4 == 0)
            {
                continue;
            }
            
            students -= employee1 + employee2 + employee3;

        }

        Console.WriteLine($"Time needed: {time}h.");
    }
}