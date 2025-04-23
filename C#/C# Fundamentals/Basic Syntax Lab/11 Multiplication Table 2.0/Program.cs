using System;

public class Program
{
    private static void Main(string[] args)
    {
        int numb1 = int.Parse(Console.ReadLine());

        int numb2 = int.Parse(Console.ReadLine());

        if (10 < numb2)
        {
            Console.WriteLine($"{numb1} X {numb2} = {numb1 * numb2}");
        }
        else
        {
            for (int i = numb2; i <= 10; i++)
            {
                Console.WriteLine($"{numb1} X {i} = {numb1 * i}");
            }
        }
    }
}