namespace TopIntegers
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            string result = "";

            for (int i = 0; i < arr.Length; i++)
            {
                int currNumber = arr[i];
                bool isNumber = true;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currNumber <= arr[j])
                    {
                        isNumber = false;
                        break;
                    }

                }

                if (isNumber)
                {
                    result += arr[i] + " ";
                }

            }

            Console.WriteLine(result.TrimEnd());

        }
    }
}