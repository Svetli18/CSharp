namespace ListyIterator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> data;

        private int index;

        public ListyIterator(params T[] values)
        {
            this.data = new List<T>(values);
            this.index = 0;
        }

        //public T Current => this.data[this.index];

        public bool Move()
        {
            if (this.index < this.data.Count - 1)
            {
                this.index++;
                return true;
            }

            return false;

        }

        public bool HasNext()
        {
            if (this.index < this.data.Count - 1)
            {
                return true;
            }

            return false;

        }

        public void Print()
        {
            if (this.data.Any() && 0 <= this.index && this.index < this.data.Count)
            {
                Console.WriteLine(this.data[this.index]);
            }
            else
            {
                Exception e = new Exception("Invalid Operation!");

                Console.WriteLine(e.Message);
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.data)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.data.GetEnumerator();
    }
}
