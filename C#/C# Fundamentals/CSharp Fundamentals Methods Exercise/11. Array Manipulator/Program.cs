using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        
        int[] array = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();

        string command = "";
        while ((command = Console.ReadLine()) != "end")
        {
            string[] currentComandArray = command.Split();

            string currentCommand = currentComandArray[0];

            if (currentCommand == "exchange")
            {
                int index = int.Parse(currentComandArray[1]);
                if (index < 0 || array.Length - 1 < index)
                {
                    Console.WriteLine("Invalid index");
                    continue;
                }

                if (index == array.Length - 1)
                {
                    continue;
                }

                int[] arr1 = GetFirstPiece(array, index);
                int[] arr2 = GetSecondPiece(array, index, arr1.Length);

                Array.Copy(arr2, 0, array, 0, arr2.Length);
                Array.Copy(arr1, 0, array, arr2.Length, arr1.Length);

            }
            else if (currentCommand == "max")
            {
                string element = currentComandArray[1];

                if (element == "even")
                {
                    PrintBiggestEvenIfHave(array);
                }
                else if (element == "odd")
                {
                    PrintBiggestOddIfHave(array);
                }

            }
            else if (currentCommand == "min")
            {
                string element = currentComandArray[1];

                if (element == "even")
                {
                    PrintSmallestEvenIfHave(array);
                }
                else if (element == "odd")
                {
                    PrintSmallestOddIfHave(array);
                }
            }
            else if (currentCommand == "first")
            {
                int count = int.Parse(currentComandArray[1]);
                string element = currentComandArray[2];

                if (array.Length < count)
                {
                    Console.WriteLine("Invalid count");
                }
                else if (element == "even")
                {
                    PrintFirstEvenCount(array, count);
                }
                else if (element == "odd")
                {
                    PrintFirstOddCount(array, count);
                }

            }
            else if (currentCommand == "last")
            {
                int count = int.Parse(currentComandArray[1]);
                string element = currentComandArray[2];

                if (array.Length < count)
                {
                    Console.WriteLine("Invalid count");
                }
                else if (element == "even")
                {
                    PrintLastEvenCount(array, count);
                }
                else if (element == "odd")
                {
                    PrintLastOddCount(array, count);
                }
            }
        }

        Console.Write("[");
        Console.Write(string.Join(", ", array));
        Console.WriteLine("]");

    }

    static void PrintLastOddCount(int[] array, int count)
    {
        string printResult = "";

        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] % 2 != 0)
            {
                if (printResult.Equals(""))
                {
                    printResult = $"{array[i]}";
                }
                else
                {
                    printResult += $", {array[i]}";
                }

                count--;

                if (count == 0)
                {
                    break;
                }

            }
        }

        if (printResult.Equals(""))
        {
            Console.WriteLine("[]");
        }
        else
        {
            Console.Write("[");
            Console.Write(printResult);
            Console.WriteLine("]");
        }
    }

    static void PrintLastEvenCount(int[] array, int count)
    {
        string printResult = "";

        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] % 2 == 0)
            {
                if (printResult.Equals(""))
                {
                    printResult = $"{array[i]}";
                }
                else
                {
                    printResult += $", {array[i]}";
                }

                count--;

                if (count == 0)
                {
                    break;
                }

            }
        }

        if (printResult.Equals(""))
        {
            Console.WriteLine("[]");
        }
        else
        {
            Console.Write("[");
            Console.Write(printResult);
            Console.WriteLine("]");
        }

    }

    static void PrintFirstOddCount(int[] array, int count)
    {
        string printResult = "";

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 != 0)
            {
                if (printResult.Equals(""))
                {
                    printResult = $"{array[i]}";
                }
                else
                {
                    printResult += $", {array[i]}";
                }

                count--;

                if (count == 0)
                {
                    break;
                }

            }
        }

        if (printResult.Equals(""))
        {
            Console.WriteLine("[]");
        }
        else
        {
            Console.Write("[");
            Console.Write(printResult);
            Console.WriteLine("]");
        }
    }

    static void PrintFirstEvenCount(int[] array, int count)
    {
        string printResult = "";

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0)
            {
                if (printResult.Equals(""))
                {
                    printResult = $"{array[i]}";
                }
                else
                {
                    printResult += $", {array[i]}";
                }

                count--;

                if (count == 0)
                {
                    break;
                }

            }
        }

        if (printResult.Equals(""))
        {
            Console.WriteLine("[]");
        }
        else
        {
            Console.Write("[");
            Console.Write(printResult);
            Console.WriteLine("]");
        }

    }

    static void PrintSmallestEvenIfHave(int[] array)
    {
        bool isMatches = false;
        int index = 0;
        int smallestEven = int.MaxValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0 && array[i] <= smallestEven)
            {
                isMatches = true;
                index = i;
                smallestEven = array[i];

            }

        }

        if (isMatches)
        {
            Console.WriteLine(index);
        }
        else
        {
            Console.WriteLine("No matches");
        }

    }

    static void PrintSmallestOddIfHave(int[] array)
    {
        bool isMatches = false;
        int index = 0;
        int smallestOdd = int.MaxValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 != 0 && array[i] <= smallestOdd)
            {
                isMatches = true;
                index = i;
                smallestOdd = array[i];

            }

        }

        if (isMatches)
        {
            Console.WriteLine(index);
        }
        else
        {
            Console.WriteLine("No matches");
        }

    }

    static void PrintBiggestOddIfHave(int[] array)
    {
        bool isMatches = false;
        int index = 0;
        int biggestOdd = int.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 != 0 && biggestOdd <= array[i])
            {
                isMatches = true;
                index = i;
                biggestOdd = array[i];
            }

        }

        if (isMatches)
        {
            Console.WriteLine(index);
        }
        else
        {
            Console.WriteLine("No matches");
        }

    }

    static void PrintBiggestEvenIfHave(int[] array)
    {
        bool isMatches = false;
        int index = 0;
        int biggestEven = int.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0 && biggestEven <= array[i])
            {
                isMatches = true;
                index = i;
                biggestEven = array[i];
            }
        }

        if (isMatches)
        {
            Console.WriteLine(index);
        }
        else
        {
            Console.WriteLine("No matches");
        }

    }

    static int[] GetFirstPiece(int[] array, int index)
    {
        return array.Take(index + 1).ToArray();
    }
    static int[] GetSecondPiece(int[] array, int index, int cnt)
    {
        return array.Skip(cnt).ToArray();
    }

}