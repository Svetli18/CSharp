namespace ReversedChars
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {

            char character1 = char.Parse(Console.ReadLine());
            char character2 = char.Parse(Console.ReadLine());
            char character3 = char.Parse(Console.ReadLine());

            string currentString = character1 + " " + character2 + " " + character3;
            string result = string.Empty;

            for (int i = currentString.Length - 1; i >= 0; i--)
            {
                result += currentString[i];
            }

            Console.WriteLine(result);
        }
    }
}