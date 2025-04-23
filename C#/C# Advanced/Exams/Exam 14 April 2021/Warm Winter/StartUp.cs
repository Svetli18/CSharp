namespace WarmWinter
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> sets = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (scarf < hat)
                {
                    sets.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (hat < scarf)
                {
                    hats.Pop();
                }
                else if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));

        }
    }
}
