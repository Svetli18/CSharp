namespace KaminoFactory
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int[] bestDNA = new int[n];
            int bestCnt = 0;
            int bestSample = 0;
            int sample = 0;
            int index = 0;

            string input;
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] currentDNA = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sample++;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    int element1 = currentDNA[i];
                    int cnt = 0;

                    if (element1 == 0)
                    {
                        continue;
                    }

                    cnt++;

                    for (int j = i + 1; j < currentDNA.Length; j++)
                    {
                        int element2 = currentDNA[j];

                        if (element2 != 1)
                        {
                            break;
                        }

                        cnt++;

                    }

                    if (bestCnt < cnt)
                    {
                        index = i;
                        bestCnt = cnt;
                        bestSample = sample;
                        bestDNA = currentDNA.ToArray();
                    }

                    if (bestCnt == cnt && i < index)
                    {
                        index = i;
                        bestSample= sample;
                        bestDNA = currentDNA.ToArray();
                    }

                    if (bestCnt == cnt && index == i && bestDNA.Sum() < currentDNA.Sum())
                    {
                        bestSample = sample;
                        bestDNA = currentDNA.ToArray();
                    }

                }

            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestDNA.Sum()}.");
            Console.WriteLine(string.Join(" ", bestDNA));

        }
    }
}