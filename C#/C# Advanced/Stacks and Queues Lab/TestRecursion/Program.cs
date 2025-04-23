using System;
using System.Collections.Generic;

namespace TestRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            RecursionRhombOfStars(1, n);
        }

        private static void RecursionRhombOfStars(int currentStars, int n)
        {
            if (n < currentStars)
            {
                return;
            }

            string spaces = new string(' ', n - currentStars);
            char[] thestars = new string('*', currentStars).ToCharArray();
            Console.Write(spaces);
            Console.WriteLine(string.Join(' ', thestars));

            RecursionRhombOfStars(currentStars + 1, n);

            if (currentStars == n)
            {
                return;
            }

            spaces = new string(' ', n - currentStars);
            thestars = new string('*', currentStars).ToCharArray();
            Console.Write(spaces);
            Console.WriteLine(string.Join(' ', thestars));
        }
    }
}
