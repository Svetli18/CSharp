namespace Exam.TaskManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TaskManager : ITaskManager
    {
        LinkedList<Task> tasks;
        Dictionary<string, Task> byIdTasks;
        Dictionary<string, LinkedList<Task>> byDomain;
        Dictionary<string, Task> executeTasks;

        public TaskManager()
        {
            this.tasks = new LinkedList<Task>();
            this.byIdTasks = new Dictionary<string, Task>();
            this.byDomain = new Dictionary<string, LinkedList<Task>>();
            this.executeTasks = new Dictionary<string, Task>();
        }

        public void AddTask(Task task)
        {
            if (!this.byIdTasks.ContainsKey(task.Id))
            {
                if (!this.byDomain.ContainsKey(task.Domain))
                {
                    this.byDomain[task.Domain] = new LinkedList<Task>();
                }

                this.tasks.AddLast(task);
                this.byIdTasks[task.Id] = task;
                this.byDomain[task.Domain].AddLast(task);
            }
        }

        public bool Contains(Task task)
        {
            return this.byIdTasks.ContainsKey(task.Id);
        }

        public int Size()
        {
            return this.byIdTasks.Keys.Count;
        }

        public Task GetTask(string taskId)
        {
            if (!this.byIdTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return this.byIdTasks[taskId];
        }

        public void DeleteTask(string taskId)
        {
            Task task = this.GetTask(taskId);

            this.tasks.Remove(task);
            this.byIdTasks.Remove(taskId);
            this.byDomain[task.Domain].Remove(task);

        }

        public Task ExecuteTask()
        {
            Task task = this.tasks.FirstOrDefault();

            if (task == null)
            {
                throw new ArgumentException();
            }

            this.executeTasks[task.Id] = task;

            this.tasks.RemoveFirst();
            this.byIdTasks.Remove(task.Id);
            this.byDomain[task.Domain].RemoveFirst();

            if (this.byDomain[task.Domain].Count == 0)
            {
                this.byDomain.Remove(task.Domain);
            }

            return task;
        }

        public void RescheduleTask(string taskId)
        {
            if (!this.executeTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            Task task = this.executeTasks[taskId];
            this.executeTasks.Remove(taskId);

            this.AddTask(task);
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            if (!this.byDomain.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            return this.byDomain[domain];
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
        {
            return this.tasks
                .Where(x => lowerBound <= x.EstimatedExecutionTime && x.EstimatedExecutionTime <= upperBound);
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
        {
            return this.tasks
                .OrderByDescending(x => x.EstimatedExecutionTime)
                .ThenBy(x => x.Name);
        }
    }
}
