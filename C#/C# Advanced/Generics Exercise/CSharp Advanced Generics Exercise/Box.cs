
namespace GenericBox
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T value)
        {
            this.list.Add(value);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = this.list[firstIndex];
            this.list[firstIndex] = this.list[secondIndex];
            this.list[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T value in this.list)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
