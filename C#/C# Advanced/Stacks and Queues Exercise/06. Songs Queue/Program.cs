using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

        var songs = new Queue<string>(input);

        while (songs.Any())
        {
            var command = Console.ReadLine();

            if (command == "Play")
            {
                songs.Dequeue();
            }
            else if (command.StartsWith("Add"))
            {
                var song = command.Substring(4);

                if (songs.Contains(song))
                {
                    Console.WriteLine($"{song} is already contained!");
                }
                else
                {
                    songs.Enqueue(song);
                }
            }
            else if (command == "Show")
            {
                Console.WriteLine(string.Join(", ", songs));
            }
        }

        if (!songs.Any())
        {
            Console.WriteLine("No more songs!");
        }

    }
}