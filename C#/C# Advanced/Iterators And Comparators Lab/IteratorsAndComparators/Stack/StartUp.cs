namespace Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MyStack<string> myStack = new MyStack<string>();
            
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commandArgs[0] == "Push")
                {
                    string[] elements = command.Substring(5).Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    myStack.Push(elements);

                }
                else if (commandArgs[0] == "Pop")
                {
                    if (!myStack.Data.Any())
                    {
                        Console.WriteLine("No elements");
                        continue;
                    }

                    myStack.Pop();
                }
            }

            for (int i = myStack.Data.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(myStack.Data[i]);
            }

            for (int i = myStack.Data.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(myStack.Data[i]);
            }

        }
    }
}
