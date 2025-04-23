namespace MagicSum
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int uniqueNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length - 1; i++)
            {

                int furstElement = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    int secondElement = array[j];

                    if (furstElement + secondElement == uniqueNumber)
                    {
                        Console.WriteLine(furstElement + " " + secondElement);
                    }
                }
            }
        }
    }
}