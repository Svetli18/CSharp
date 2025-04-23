namespace CustomComparator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> customComparator = (x, y) =>
            {
                return (x % 2 == 0 && y % 2 != 0)
                ? -1
                : (x % 2 != 0 && y % 2 == 0)
                ? 1
                : x > y
                ? 1
                : x < y
                ? -1
                : 0;
            };

            Array.Sort(array, (x, y) => customComparator(x, y));

            Console.WriteLine(string.Join(" ", array));

        }
    }
}
