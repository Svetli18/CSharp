namespace LowerOrUpper
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            char charecter = char.Parse(Console.ReadLine());

            if (65 <= charecter && charecter <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if (97 <= charecter && charecter <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}