namespace Lootbox
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int sum = 0;

            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (firstBox.Any() && secondBox.Any())
            {
                int currSumOfBoxes = firstBox.Peek() + secondBox.Peek();

                if (currSumOfBoxes % 2 != 0)
                {
                    firstBox.Enqueue(secondBox.Pop());
                    continue;
                }

                sum += currSumOfBoxes;
                firstBox.Dequeue();
                secondBox.Pop();

            }

            if (firstBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
                Console.WriteLine(100 <= sum ? $"Your loot was epic! Value: {sum}" : $"Your loot was poor... Value: {sum}");
            }
            else if (secondBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
                Console.WriteLine(100 <= sum ? $"Your loot was epic! Value: {sum}" : $"Your loot was poor... Value: {sum}");
            }

        }
    }
}

