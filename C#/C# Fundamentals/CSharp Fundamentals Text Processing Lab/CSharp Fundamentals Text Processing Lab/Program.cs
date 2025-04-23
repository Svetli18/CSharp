using System;
using System.Linq;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();

        string separator = " = ";
        string word;
        while ((word = Console.ReadLine()) != "end")
        {
            sb.Append(word);
            sb.Append(separator);
            sb.Append(string.Join("", word.Reverse()));

            Console.WriteLine(sb.ToString().TrimEnd());
            sb.Clear();
        }
    }
}