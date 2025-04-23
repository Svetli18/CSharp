namespace LadyBugs
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] indexes = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int[] array = new int[n];

            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];

                array[index] = 1;
            }

            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] currCommand = command.Split();

                int currIndex = int.Parse(currCommand[0]);

                if (currIndex < 0 || array.Length - 1 < currIndex || 
                    array[currIndex] == 0)
                {
                    continue;
                }

                string currDirection = currCommand[1];
                int currFlyLength = int.Parse(currCommand[2]);

                if (currDirection == "right")
                {
                    array[currIndex] = 0;

                    while (0 <= currIndex && currIndex + currFlyLength < array.Length)
                    {
                        if (array[currIndex + currFlyLength] == 0)
                        {
                            array[currIndex + currFlyLength] = 1;
                            break;
                        }

                        currIndex += currFlyLength;

                    }
                }
                else if (currDirection == "left")
                {
                    array[currIndex] = 0;

                    while (0 <= currIndex - currFlyLength && currIndex < array.Length)
                    {
                        if (array[currIndex - currFlyLength] == 0)
                        {
                            array[currIndex - currFlyLength] = 1;
                            break;
                        }

                        currIndex -= currFlyLength;

                    }

                }
            }

            Console.WriteLine(string.Join(" ", array));

        }
    }
}