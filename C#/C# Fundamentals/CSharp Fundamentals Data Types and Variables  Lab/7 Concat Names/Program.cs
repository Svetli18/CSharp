namespace ConcatNames
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string delimeter = Console.ReadLine();

            string result = firstName + delimeter + lastName;

            Console.WriteLine(result);
        }
    }
}