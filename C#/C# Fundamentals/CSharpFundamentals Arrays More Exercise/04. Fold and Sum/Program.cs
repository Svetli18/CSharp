namespace FoldAndSum
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arrInts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] core1 = new int[arrInts.Length / 2];

            int[] quarterFromTheStart = new int[core1.Length / 2];
            int[] quarterFromTheEnd = new int[core1.Length / 2];

            for (int i = 0; i < core1.Length; i++)
            {
                if (i < core1.Length / 2)
                {

                    quarterFromTheStart[i] = arrInts[arrInts.Length / 2 - quarterFromTheStart.Length - 1 - i];
                    quarterFromTheEnd[i] = arrInts[arrInts.Length - 1 - i];

                }

                core1[i] = arrInts[arrInts.Length / 2 - quarterFromTheEnd.Length + i];

            }

            int[] core2 = new int[arrInts.Length / 2];

            for (int i = 0; i < core2.Length; i++)
            {
                if (i < core2.Length / 2)
                {
                    core2[i] = quarterFromTheStart[i];
                    continue;
                }

                core2[i] = quarterFromTheEnd[i - quarterFromTheEnd.Length];

            }

            int[] result = new int[core1.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = core1[i] + core2[i];
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}