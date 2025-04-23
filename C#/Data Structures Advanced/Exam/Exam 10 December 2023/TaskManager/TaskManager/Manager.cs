using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    public class Manager : IManager
    {
        HashSet<Task> tasks = new HashSet<Task>();
        Dictionary<string, Task> byId = new Dictionary<string, Task>();

        public void AddTask(Task task)
        {
            if (this.byId.ContainsKey(task.Id))
            {
                throw new ArgumentException();
            }

            this.tasks.Add(task);
            this.byId[task.Id] = task;
        }

        public void RemoveTask(string taskId)
        {
            Task toRemove = this.Get(taskId);

            foreach (var element in toRemove.ByIdDependents.Values)
            {
                element.ByIdDependencies.Remove(taskId);
                toRemove.ByIdDependents.Remove(element.Id);
            }

            foreach (var element in toRemove.ByIdDependencies.Values)
            {
                element.ByIdDependents.Remove(taskId);
            }

            this.tasks.Remove(toRemove);
            this.byId.Remove(taskId);
            //ne e gotovo!!
        }

        public bool Contains(string taskId)
        {
            return this.byId.ContainsKey(taskId);
        }

        public Task Get(string taskId)
        {
            if (!this.byId.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return this.byId[taskId];
        }

        public int Size()
        {
            return this.byId.Count;
        }

        public void AddDependency(string taskId, string dependentTaskId)
        {

            if (!this.byId.ContainsKey(taskId) || 
                !this.byId.ContainsKey(dependentTaskId) || 
                taskId.Equals(dependentTaskId))
            {
                throw new ArgumentException();
            }

            Queue<Task> queue = new Queue<Task>();
            queue.Enqueue(this.byId[taskId]);

            while (0 < queue.Count)
            {
                Task task = queue.Dequeue();

                if (task.ByIdDependencies.ContainsKey(dependentTaskId))
                {
                    throw new ArgumentException();
                }

                foreach (var element in task.ByIdDependencies.Values)
                {
                    queue.Enqueue(element);
                }
            }

            this.byId[taskId].ByIdDependencies[dependentTaskId] = this.byId[dependentTaskId];

            this.byId[dependentTaskId].ByIdDependents[taskId] = this.byId[taskId];
        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            if (!this.byId.ContainsKey(taskId) || !this.byId.ContainsKey(dependentTaskId) || !this.byId[taskId].ByIdDependencies.ContainsKey(dependentTaskId))
            {
                throw new AggregateException();
            }

            this.byId[taskId].ByIdDependencies.Remove(dependentTaskId);

            this.byId[dependentTaskId].ByIdDependents.Remove(taskId);
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            List<Task> result = new List<Task>();

            if (!this.byId.ContainsKey(taskId))
            {
                return result;
            }

            if (this.byId[taskId].ByIdDependencies.Count > 0)
            {
                Queue<Task> queue = new Queue<Task>(this.byId[taskId].ByIdDependencies.Values.ToArray());

                while (queue.Count > 0)
                {
                    Task task = queue.Dequeue();

                    result.Add(task);

                    foreach (var element in task.ByIdDependencies.Values)
                    {
                        queue.Enqueue(element);
                    }
                }
            }

            return result;
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            List<Task> result = new List<Task>();

            if (!this.byId.ContainsKey(taskId))
            {
                return result;
            }

            if (this.byId[taskId].ByIdDependents.Count > 0)
            {
                Queue<Task> queue = new Queue<Task>(this.byId[taskId].ByIdDependents.Values.ToArray());

                while (queue.Count > 0)
                {
                    Task task = queue.Dequeue();

                    result.Add(task);

                    foreach (var element in task.ByIdDependents.Values)
                    {
                        queue.Enqueue(element);
                    }
                }
            }

            return result;
        }
    }
}