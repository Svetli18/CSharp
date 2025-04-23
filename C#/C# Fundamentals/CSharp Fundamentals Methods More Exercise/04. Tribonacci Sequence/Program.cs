using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        //result with for
        int[] result = GetTribunaciResult(n);

        //result with recursive metod.
        int index = 0;
        int[] array = new int[n];
        int[] recursiveResult = GetTribunaciResultRecursive(n, index, array);

        Console.WriteLine(string.Join(" ", recursiveResult));
    }

    static int[] GetTribunaciResultRecursive(int n, int index, int[] result)
    {

        if (n == index)
        {
            return result;
        }

        if (index == 0)
        {
            result[index] = 1;
        }
        else if (index < 3)
        {
            result[index] = index;
        }
        else
        {
            result[index] = result[index - 1] + result[index - 2] + result[index - 3];
        }

        GetTribunaciResultRecursive(n, index + 1, result);

        return result;
    }

    static int[] GetTribunaciResult(int n)
    {
        int[] result = new int[n];

        for (int i = 0; i < result.Length; i++)
        {
            if (i == 0)
            {
                result[i] = 1;
            }
            else if (i < 3)
            {
                result[i] = i;
            }
            else
            {
                result[i] = result[i - 1] + result[i - 2] + result[i - 3];
            }

        }

        return result;
    }
}