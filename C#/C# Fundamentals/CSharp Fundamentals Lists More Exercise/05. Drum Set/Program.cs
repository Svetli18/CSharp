using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    private static void Main(string[] args)
    {
        float money = float.Parse(Console.ReadLine());

        List<int> drums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> drumSet = new List<int>(drums); 

        string command;
        while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
        {
            int hitingPower = int.Parse(command);

            for (int i = 0; i < drumSet.Count; i++)
            {
                drumSet[i] -= hitingPower;

                if (drumSet[i] <= 0)
                {
                    float price = drums[i] * 3;

                    if (price <= money)
                    {
                        money -= price;
                        drumSet[i] = drums[i];
                    }
                    else
                    {
                        drumSet.RemoveAt(i);
                        drums.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        Console.WriteLine(string.Join(" ", drumSet));
        Console.WriteLine($"Gabsy has {money:F2}lv.");
    }
}