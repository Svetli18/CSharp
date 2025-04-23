using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TaskManager
{
    public class Task : IComparable<Task>
    {
        public Task()
        {
            this.ByIdDependencies = new Dictionary<string, Task>();
            this.ByIdDependents = new Dictionary<string, Task>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Assignee { get; set; }

        public int Priority { get; set; }

        public Dictionary<string, Task> ByIdDependencies {  get; set; }

        public Dictionary<string, Task> ByIdDependents {  get; set; }

        public override string ToString()
        {
            return this.Title;
        }

        public override bool Equals(object obj)
        {
            Task other = obj as Task;

            if (other == null) return false;

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public int CompareTo([AllowNull] Task other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}