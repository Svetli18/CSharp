namespace The_Fight_for_Gondor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> plates = new List<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            for (int i = 1; i <= n; i++)
            {
                Stack<int> curentOrcsWave = new Stack<int>(
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                while (plates.Any() && curentOrcsWave.Any())
                {
                    int orcWarior = curentOrcsWave.Pop();

                    int plate = plates[0];

                    if (plate < orcWarior)
                    {
                        orcWarior -= plate;
                        curentOrcsWave.Push(orcWarior);
                        plates.RemoveAt(0);
                    }
                    else if (orcWarior < plate)
                    {
                        plate -= orcWarior;
                        plates[0] = plate;
                    }
                    else
                    {
                        plates.RemoveAt(0);
                    }

                }

                if (curentOrcsWave.Any())
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    Console.Write("Orcs left: ");
                    Console.WriteLine(string.Join(", ", curentOrcsWave));
                    break;
                }
            }

            if (plates.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.Write("Plates left: ");
                Console.WriteLine(string.Join(", ", plates));
            }

        }
    }
}
