namespace Test
{
    using System;

    public class Program
    {

        public static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());

            for (var i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (i == 0 || i == h - 1)
                    {
                        if (j == 0)
                        {
                            Console.Write("*");
                            continue;
                        }
                        Console.Write(" *");
                    }
                    else if (j == 0 || j ==  w - 1)
                    {
                        if (j == 0)
                        {
                            Console.Write("*");
                            continue;
                        }
                        Console.Write(" *");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}