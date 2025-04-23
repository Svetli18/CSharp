using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> list = Console.ReadLine()
            .Split(", ")
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "course start")
        {
            string[] commandAguments = command
                .Split(":", StringSplitOptions.RemoveEmptyEntries);

            string currCommand = commandAguments[0];
            string lessonTitle = commandAguments[1];

            if (currCommand == "Add" && !list.Contains(lessonTitle))
            {
                list.Add(lessonTitle);

            }
            else if (currCommand == "Insert" && !list.Contains(lessonTitle))
            {
                int index = int.Parse(commandAguments[2]);
                list.Insert(index, lessonTitle);

            }
            else if (currCommand == "Remove")
            {
                list.Remove(lessonTitle);

            }
            else if (currCommand == "Swap" )
            {
                string secondLesonTitle = commandAguments[2];

                if (list.Contains(lessonTitle) && list.Contains(secondLesonTitle))
                {
                    list = SwapLesons(list, lessonTitle, secondLesonTitle);
                }

            }
            else if (currCommand == "Exercise")
            {
                if (!list.Contains(lessonTitle))
                {
                    list.Add(lessonTitle);
                    list.Add(lessonTitle + "-Exercise");
                    continue;

                }

                int index = list.IndexOf(lessonTitle);
                list.Insert(index + 1, lessonTitle + "-Exercise");

            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{list[i]}");
        }

    }

    static List<string> SwapLesons(List<string> list, string firstLessonTitle, string secondLesonTitle)
    {
        List<string> result = list.ToList();

        int indexOfFirst = result.IndexOf(firstLessonTitle);
        int indexOfFirstExercise = -1;
        int indexOfSecond = result.IndexOf(secondLesonTitle);
        int indexOfSecondExercise = -1;

        if (indexOfFirst + 1 < result.Count && 
            result[indexOfFirst + 1].Equals(result[indexOfFirst] + "-Exercise"))
        {
            indexOfFirstExercise = indexOfFirst + 1;
        }

        if (indexOfSecond + 1 < result.Count && 
            result[indexOfSecond + 1].Equals(result[indexOfSecond] + "-Exercise"))
        {
            indexOfSecondExercise = indexOfSecond + 1;
        }

        Swap(result, indexOfFirst, indexOfSecond);

        if (0 <= indexOfFirstExercise && 0 <= indexOfSecondExercise)
        {
            Swap(result, indexOfFirstExercise, indexOfSecondExercise);
        }
        else if (0 <= indexOfFirstExercise)
        {
            string exercise = result[indexOfFirstExercise];
            result.RemoveAt(indexOfFirstExercise);
            result.Insert(indexOfSecond + 1, exercise);
        }
        else if (0 <= indexOfSecondExercise)
        {
            string exercise = result[indexOfSecondExercise];
            result.RemoveAt(indexOfSecondExercise);
            result.Insert(indexOfFirst + 1, exercise);
        }

        return result;
    }

    static void Swap(List<string> result, int indexOfFirst, int indexOfSecond)
    {
        string temp = result[indexOfFirst];
        result[indexOfFirst] = result[indexOfSecond];
        result[indexOfSecond] = temp;
    }
}