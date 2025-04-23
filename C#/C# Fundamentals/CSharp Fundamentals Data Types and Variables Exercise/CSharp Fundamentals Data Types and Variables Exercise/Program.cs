namespace IntegerOperations
{
    using System;
    using System.Numerics;

    internal class Program
    {
        private static void Main(string[] args)
        {

            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());

            BigInteger result = ((first + second) / third) * fourth;

            Console.WriteLine(result);
        }
    }
}