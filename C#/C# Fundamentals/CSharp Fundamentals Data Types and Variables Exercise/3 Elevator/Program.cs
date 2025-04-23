namespace Elevator
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int count = 1;

            while (capacity < people)
            {
                people -= capacity;
                count++;
            }

            Console.WriteLine(count);
        }
    }
}