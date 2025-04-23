namespace IteratorsAndComparators
{
    using System;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();

            ListyIterator<string> iterator = null;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commandArgs[0] == "Create")
                {
                    iterator = new ListyIterator<string>(commandArgs.Skip(1).ToArray());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }
                else if (command == "Print")
                {
                    iterator.Print();
                }
            }
        }
    }
}