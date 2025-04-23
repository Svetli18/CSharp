using System;
using System.Linq;
using System.Collections.Generic;


internal class Program
{
    private static void Main(string[] args)
    {
        List<string> list = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string commad;
        while ((commad = Console.ReadLine()) != "3:1")
        {
            string[] commandArguments = commad
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string currendCommand = commandArguments[0];
            
            int index = int.Parse(commandArguments[1]);

            if (index < 0 || list.Count - 1 < index)
            {
                continue;
            }

            if (currendCommand == "merge")
            {
                MergeMethod(list, commandArguments, index);
            }
            else if (currendCommand == "divide")
            {
                DivideMethod(list, commandArguments, index);
            }

        }

        Console.WriteLine(string.Join(' ', list));

    }

    static void DivideMethod(List<string> list, string[] commandArguments, int index)
    {
        int divide = int.Parse(commandArguments[2]);

        string str = list[index];
        list.RemoveAt(index);

        string[] result = new string[divide];
        int resultIndex = 0;

        int elements = str.Length / divide;

        while (1 < divide)
        {
            char[] chars = str.Take(elements).ToArray();
            result[resultIndex++] = new string(chars);
            chars = str.Skip(elements).ToArray();
            str = new string(chars);
            divide--;

        }

        result[resultIndex++] = str;

        for (int i = result.Length - 1; i >= 0; i--)
        {
            list.Insert(index, result[i]);
        }
    }

    static void MergeMethod(List<string> list, string[] commandArguments, int index)
    {
        int endIndex = int.Parse(commandArguments[2]);

        string str = "";
        int currListCount = list.Count;

        for (int i = index; i <= endIndex; i++)
        {
            if (currListCount == i)
            {
                break;
            }

            str += list[index];
            list.RemoveAt(index);

        }

        list.Insert(index, str);

    }
}