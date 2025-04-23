using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string str;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (65 <= ch && ch <= 90)
            {
                //if (90 < ch + 3)
                //{
                //    str = ((char)((ch + 3) - 26)).ToString();
                //    sb.Append(str);
                //}
                str = ((char)(ch + 3)).ToString();
                sb.Append(str);

            }
            else if (97 <= ch && ch <= 122)
            {
                //if (122 <= ch + 3)
                //{
                //    str = ((char)((ch + 3) - 26)).ToString();
                //    sb.Append(str);
                //}
                str = ((char)(ch + 3)).ToString();
                sb.Append(str);

            }
            else
            {
                str = ((char)(ch + 3)).ToString();
                sb.Append(str);
            }
        }

        Console.WriteLine(sb.ToString());

    }
}