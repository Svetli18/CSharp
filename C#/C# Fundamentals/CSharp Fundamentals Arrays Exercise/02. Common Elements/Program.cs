namespace CommonElements
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();

            string[] arr2 = Console.ReadLine().Split();

            string result = "";

            foreach (var element2 in arr2)
            {

                foreach (var element1 in arr1)
                {

                    if (element1.Equals(element2))
                    {
                        result += element2 + " ";
                    }

                }

            }

            Console.WriteLine(result);

        }
    }
}