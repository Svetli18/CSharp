
namespace ListyIterator
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
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
                else if (command == "PrintAll")
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var element in iterator)
                    {
                        sb.Append($"{element} ");
                    }

                    Console.WriteLine(sb.ToString().TrimEnd());
                }
            }
        }
    }
}
