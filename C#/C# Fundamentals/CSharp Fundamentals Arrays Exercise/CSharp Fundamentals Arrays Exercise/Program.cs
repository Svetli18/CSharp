namespace Train
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int[] train = new int[n];

            for (int i = 0; i < train.Length; i++)
            {
                train[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(" ", train));
            Console.WriteLine(train.Sum());
        }
    }
}