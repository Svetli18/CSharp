using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var gasStancions = GetGasStancions(n);
        int index = 0;
        bool isSuccess = true;

        while (true)
        {
            long totalFuel = 0;

            foreach (var currStancion in gasStancions)
            {
                totalFuel += currStancion.Petrol;

                if (totalFuel < currStancion.InformationDistance)
                {
                    isSuccess = false;
                    break;
                }

                totalFuel -= currStancion.InformationDistance;

            }

            if (isSuccess)
            {
                break;
            }

            index++;
            isSuccess = true;
            gasStancions.Enqueue(gasStancions.Dequeue());

        }

        Console.WriteLine(index);

    }

    static new Queue<GasStancion> GetGasStancions(int n)
    {
        var queue = new Queue<GasStancion>();

        for (int i = 0; i < n; i++)
        {
            var current = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var petrol = current[0];
            var informationDistance = current[1];

            var stancion = new GasStancion(petrol, informationDistance);

            queue.Enqueue(stancion);
        }

        return queue;
    }
}

class GasStancion
{
    public GasStancion(int petrol, int informationDistance)
    {
        Petrol = petrol;
        InformationDistance = informationDistance;
    }

    public long Petrol { get; set; }
    public long InformationDistance { get; set; }
}

