namespace SumDigits
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;

            while (0 < number)
            {
                int currentNumber = number % 10;
                number = number / 10;
                sum += currentNumber;
            }

            Console.WriteLine(sum);
        }
    }
}