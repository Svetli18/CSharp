namespace StrongNumber
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int number = n;
            int result = 0;

            while (n != 0)
            {
                int numb = n % 10;
                n /= 10;
                int factorial = 1;

                for (int i = numb; i >= 1; i--)
                {
                    factorial *= i;
                }

                result += factorial;

            }

            if (number == result)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}