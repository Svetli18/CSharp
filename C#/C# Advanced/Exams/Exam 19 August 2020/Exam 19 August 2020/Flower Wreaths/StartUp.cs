namespace Exam19August2020
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(
                Console.ReadLine()
                .Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> roses = new Queue<int>(
                Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int flowersLeft = 0;
            int wreathCount = 0;

            while (lilies.Any() && roses.Any())
            {
                int currSum = lilies.Peek() + roses.Peek();

                if (15 == currSum)
                {
                    wreathCount++;
                }
                else if (15 < currSum)
                {
                    lilies.Push(lilies.Pop() - 2);
                    continue;
                }
                else if (0 <= currSum && currSum < 15)
                {
                    flowersLeft += currSum;
                }

                lilies.Pop();
                roses.Dequeue();

            }

            wreathCount += flowersLeft / 15;

            if (5 <= wreathCount)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }

        }
    }
}
