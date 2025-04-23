using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string cmd;
        while ((cmd = Console.ReadLine()) != "Travel")
        {
            string[] cmdArgs = cmd.Split(':');

            var command = cmdArgs[0];

            if (command == "Add Stop")
            {
                var index = int.Parse(cmdArgs[1]);
                var destination = cmdArgs[2];

                if (0 <= index && index < input.Length)
                {
                    input = input.Insert(index, destination);
                    Console.WriteLine(input);
                }
            }
            else if (command == "Remove Stop")
            {
                var startIndex = int.Parse(cmdArgs[1]);
                var endIndex = int.Parse(cmdArgs[2]);

                if (startIndex <= endIndex &&
                    0 <= startIndex && startIndex < input.Length &&
                    0 <= endIndex && endIndex < input.Length)
                {
                    input = RemoveElements(startIndex, endIndex, input);
                }
                Console.WriteLine(input);
            }
            else if (command == "Switch")
            {
                var oldString = cmdArgs[1];
                var newString = cmdArgs[2];

                if (input.Contains(oldString))
                {
                    input = input.Replace(oldString, newString);
                    Console.WriteLine(input);
                }
            }
        }

        Console.WriteLine($"Ready for world tour! Planned stops: {input}");

    }

    static string RemoveElements(int startIndex, int endIndex, string input)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (i < startIndex || endIndex < i)
            {
                sb.Append(input[i]);
            }
        }

        return sb.ToString().Trim();
    }
}