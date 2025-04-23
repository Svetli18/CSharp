using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        int explozian = 0;

        for (int i = 0; i < text.Length; i++)
        {
            char curr = text[i];

            if (curr == '>')
            {
                if (i + 1 < text.Length - 1 && char.IsDigit(text[i + 1]))
                {
                    int index = i + 1;
                    int end = int.Parse(text[index].ToString());

                    if (0 < explozian)
                    {
                        end += explozian;
                    }

                    explozian = end;

                    for (int j = 0; j < end; j++)
                    {
                        if (text.Length - 1 < index || text[index] == '>')
                        {
                            break;
                        }

                        text = text.Remove(index, 1);
                        explozian--;
                    }
                }
            }
        }

        Console.WriteLine(text);

    }
}