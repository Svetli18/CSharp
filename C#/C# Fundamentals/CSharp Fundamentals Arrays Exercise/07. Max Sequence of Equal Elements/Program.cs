namespace MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int cnt = 1;
            int bestCnt = 0;
            int index = 0;
            string result = null;

            for (int i = 0; i < array.Length - 1; i++)
            {
                int currElement = array[i];

                if (currElement == array[i + 1])
                {
                    cnt++;

                    if (bestCnt < cnt)
                    {
                        bestCnt = cnt;
                        index = i;
                    }

                }
                else 
                {
                    cnt = 1;
                }

            }

            for (int i = 0; i < bestCnt; i++)
            {
                result += array[index] + " ";
            }

            Console.WriteLine(result);

        }
    }
}