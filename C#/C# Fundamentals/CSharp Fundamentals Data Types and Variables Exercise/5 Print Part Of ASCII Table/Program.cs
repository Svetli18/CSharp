namespace PrintPartOfASCIITable
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            int start = Math.Min(first, second);
            int end = Math.Max(first, second);

            StringBuilder sb = new StringBuilder();
            int cnt = 1;

            for (int i = start; i <= end; i++)
            {
                char charecter = (char)i;

                if (0 < cnt)
                {
                    sb.Append(charecter);
                    cnt = 0;
                    continue;
                }

                sb.Append(' ');
                sb.Append(charecter);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}