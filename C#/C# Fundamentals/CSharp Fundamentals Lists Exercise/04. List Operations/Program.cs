using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> list = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] comArgsArray = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string currCommand = comArgsArray[0];

            if (currCommand == "Add")
            {
                int number = int.Parse(comArgsArray[1]);

                list.Add(number);

            }
            else if (currCommand == "Insert")
            {
                int number = int.Parse(comArgsArray[1]);
                int index = int.Parse(comArgsArray[2]);

                if (0 <= index && index < list.Count)
                {
                    list.Insert(index, number);
                    continue;
                }

                Console.WriteLine("Invalid index");

            }
            else if (currCommand == "Remove")
            {
                int index = int.Parse(comArgsArray[1]);

                if (0 <= index && index < list.Count)
                {
                    list.RemoveAt(index);
                    continue;
                }

                Console.WriteLine("Invalid index");

            }
            else if (currCommand == "Shift")
            {
                string direction = comArgsArray[1];
                int count = int.Parse(comArgsArray[2]);

                count = count % list.Count;

                if (direction == "left")
                {
                    for (int i = 0; i < count; i++)
                    {
                        int element = list[0];
                        list.RemoveAt(0);
                        list.Add(element);
                    }
                }
                else if (direction == "right")
                {
                    for (int i = 0; i < count; i++)
                    {
                        int element = list[list.Count - 1];
                        list.RemoveAt(list.Count - 1);
                        list.Insert(0, element);
                    }
                }

            }
        }

        Console.WriteLine(string.Join(' ', list));

    }
}