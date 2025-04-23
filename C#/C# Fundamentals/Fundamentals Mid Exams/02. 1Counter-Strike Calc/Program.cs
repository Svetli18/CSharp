using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int energy = int.Parse(Console.ReadLine());

        bool IsNotEnoughEnergy = false;

        int count = 0;

        string cmd;
        while ((cmd = Console.ReadLine()) != "End of battle")
        {
            int distance = int.Parse(cmd);

            if (distance <= energy)
            {
                energy -= distance;
                count++;

                if (count % 3 == 0)
                {
                    energy += count;
                }
            }
            else
            {
                IsNotEnoughEnergy = true;
                break;
            }

        }

        if (IsNotEnoughEnergy)
        {
            Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {energy} energy");
        }
        else
        {
            Console.WriteLine($"Won battles: {count}. Energy left: {energy}");
        }
    }
}