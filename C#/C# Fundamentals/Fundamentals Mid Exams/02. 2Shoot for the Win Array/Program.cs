using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] targets = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int count = 0;

        string cmd;
        while ((cmd = Console.ReadLine()) != "End")
        {
            int targetIndex = int.Parse(cmd);

            if (targetIndex < 0 || targets.Length - 1 < targetIndex)
            {
                continue;
            }

            if (targets[targetIndex] != -1)
            {
                int valueOfTarget = targets[targetIndex];
                targets[targetIndex] = -1;
                count++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (i == targetIndex || targets[i] == -1)
                    {
                        continue;
                    }
                    else if (valueOfTarget < targets[i])
                    {
                        targets[i] -= valueOfTarget;
                    }
                    else
                    {
                        targets[i] += valueOfTarget;
                    }
                    
                }

            }

        }

        Console.Write($"Shot targets: {count} -> ");
        Console.WriteLine(string.Join(" ", targets));
    }
}