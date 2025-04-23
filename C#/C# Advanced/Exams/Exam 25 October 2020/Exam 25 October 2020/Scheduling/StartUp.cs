namespace Scheduling
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> task = new Stack<int>(
                Console.ReadLine()
                .Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> thread = new Queue<int>(
                Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                if (taskToBeKilled == task.Peek())
                {
                    break;
                }
                else if (task.Peek() <= thread.Peek())
                {
                    task.Pop();
                    thread.Dequeue();
                }
                else if (thread.Peek() < task.Peek())
                {
                    thread.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {thread.Peek()} killed task {taskToBeKilled}");

            Console.WriteLine(string.Join(' ', thread));
        }
    }
}
