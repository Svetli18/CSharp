namespace Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake like = new Lake(input);

            bool isFirst = true;

            foreach (var element in like)
            {
                if (isFirst)
                {
                    Console.Write(element);
                    isFirst = false;
                    continue;
                }

                Console.Write(", " + element);
            }

        }
    }
}
