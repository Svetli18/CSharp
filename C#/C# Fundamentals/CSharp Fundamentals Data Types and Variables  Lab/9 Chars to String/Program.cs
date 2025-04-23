namespace CharsToString
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                char charecter = char.Parse(Console.ReadLine());

                sb.Append(charecter);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}