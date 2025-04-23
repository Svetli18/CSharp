namespace TriplesOfLatinLetters
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 97; i < 97 + n; i++)
            {
                for (int j = 97; j < 97 + n; j++)
                {
                    for (int k = 97; k < 97 + n; k++)
                    {

                        char ch1 = (char)i;
                        char ch2 = (char)j;
                        char ch3 = (char)k;

                        Console.WriteLine($"{ch1}{ch2}{ch3}");
                    }
                }
            }
        }
    }
}