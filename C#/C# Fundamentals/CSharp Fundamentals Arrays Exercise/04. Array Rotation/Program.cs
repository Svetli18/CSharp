namespace ArrayRotation
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            int rottation = int.Parse(Console.ReadLine());

            rottation = rottation % arr.Length;

            for (int r = 0; r < rottation; r++)
            {
                string temp = arr[0]; 

                for (int i = 0; i < arr.Length - 1; i++)
                {

                    arr[i] = arr[i + 1];

                }

                arr[arr.Length - 1] = temp;

            }

            Console.WriteLine(string.Join(" ", arr));

        }
    }
}