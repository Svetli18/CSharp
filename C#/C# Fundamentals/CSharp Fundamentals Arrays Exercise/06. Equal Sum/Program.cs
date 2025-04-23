namespace EqualSum
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int index = 0;
            bool isEqual = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;



                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += arr[j];
                }

                for (int k = i + 1; k < arr.Length; k++)
                {
                    rightSum += arr[k];
                }

                if (leftSum == rightSum)
                {
                    index = i;
                    isEqual = true;
                    break;
                }

            }

            if (isEqual)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}