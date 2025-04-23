namespace RecursiveFibonacci
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long result = RecursiveFibonacci(n);

            Console.WriteLine(result);
        }

        private static long RecursiveFibonacci(int n)
        {

            if (n == 1 || n == 2)
            {
                return 1;
            }

            return RecursiveFibonacci(n - 2) + RecursiveFibonacci(n - 1);

        }
    }
}