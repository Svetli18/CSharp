using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Pianist> collection = new Dictionary<string, Pianist>(); 

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split('|');

            string piece = input[0];
            string composer = input[1];
            string key = input[2];

            Pianist pianist = new Pianist(composer, key);

            if (!collection.ContainsKey(piece))
            {
                collection[piece] = pianist;
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "Stop")
        {
            string[] commandArgs = command.Split('|');
            string cmd = commandArgs[0];
            string piece = commandArgs[1];

            if (cmd == "Add")
            {
                string composer = commandArgs[2];
                string key = commandArgs[3];

                if (collection.ContainsKey(piece))
                {
                    Console.WriteLine($"{piece} is already in the collection!");
                    continue;
                }

                Pianist pianist = new Pianist(composer, key);
                collection[piece] = pianist;
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");

            }
            else if (cmd == "Remove")
            {
                if (!collection.ContainsKey(piece))
                {
                    Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    continue;
                }

                collection.Remove(piece);
                Console.WriteLine($"Successfully removed {piece}!");

            }
            else if (cmd == "ChangeKey")
            {
                string newKey = commandArgs[2];

                if (!collection.ContainsKey(piece))
                {
                    Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    continue;
                }

                collection[piece].Key = newKey;
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
            }
        }

        foreach (var kvp in collection)
        {
            Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.Composer}, Key: {kvp.Value.Key}");
        }
    }
}

class Pianist
{
    public Pianist(string composer, string key)
    {
        Composer = composer;
        Key = key;
    }

    public string Composer { get; set; }
    public string Key { get; set; }

}