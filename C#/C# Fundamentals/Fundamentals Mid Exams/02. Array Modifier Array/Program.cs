using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string cmd;
        while ((cmd = Console.ReadLine()) != "end")
        {
            string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            switch (command)
            {
                case "swap": Swap(array, int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                    break;
                case "multiply": Multiply(array, int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                    break;
                case "decrease": Decrease(array);
                    break;
            }
        }

        Console.WriteLine(string.Join(", ", array));

    }

    static void Decrease(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] -= 1;
        }
    }

    static void Multiply(int[] array, int index1, int index2)
    {
        array[index1] *= array[index2];
    }

    static void Swap(int[] array, int index1, int index2)
    {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}