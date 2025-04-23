namespace Exam.TaskManager
{
    public class Task
    {
        public Task(string id, string name, int estimatedExecutionTime, string domain)
        {
            Id = id;
            Name = name;
            EstimatedExecutionTime = estimatedExecutionTime;
            Domain = domain;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int EstimatedExecutionTime { get; set; }

        public string Domain { get; set; }

        public override bool Equals(object obj)
        {
            Task other = obj as Task;

            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
