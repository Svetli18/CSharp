namespace SumOfChars
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char charecter = char.Parse(Console.ReadLine());

                sum += charecter;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}