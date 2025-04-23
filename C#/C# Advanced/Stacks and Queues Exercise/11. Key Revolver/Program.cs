using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var bulletPrice = int.Parse(Console.ReadLine());
        var gunBarrel = int.Parse(Console.ReadLine());

        var inputBullets = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var bullets = new Stack<int>(inputBullets);

        var inputLocks = Console.ReadLine()
            .Split(' ', StringSplitOptions .RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var locks = new Queue<int>(inputLocks);

        var intelligenceValue = int.Parse(Console.ReadLine());

        var cnt = 0;
        var reloadingCnt = 0;

        while(bullets.Any() && locks.Any())
        {
            var currentBullet = bullets.Pop();
            var currentLocks = locks.Peek();


            if (currentBullet <= currentLocks)
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }
            cnt++;
            reloadingCnt++;

            if (reloadingCnt == gunBarrel && bullets.Any())
            {
                Console.WriteLine("Reloading!");
                reloadingCnt = 0;
            }

        }

        if (locks.Any())
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
        else
        {
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - (bulletPrice * cnt)}");
        }

    }
}