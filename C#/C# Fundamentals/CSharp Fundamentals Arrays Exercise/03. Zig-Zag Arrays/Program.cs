namespace ZigZagArrays
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];

            int[] arr2 = new int[n];

            for (int i = 0; i < arr1.Length; i++)
            {
                int[] currArr = Console.ReadLine().Split()
                    .Select(x => int.Parse(x))
                    .ToArray();

                if (i % 2 == 0)
                {
                    arr1[i] = currArr[0];
                    arr2[i] = currArr[1];
                }
                else
                {
                    arr1[i] = currArr[1];
                    arr2[i] = currArr[0];
                }

            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));

        }
    }
}