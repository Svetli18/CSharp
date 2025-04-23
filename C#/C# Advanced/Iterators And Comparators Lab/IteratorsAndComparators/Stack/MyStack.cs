using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> data;

        private int index;

        public MyStack()
        {
            this.data = new List<T>();
            this.index = -1;
        }

        public List<T> Data => this.data;

        public void Push(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.data.Add(elements[i]);
                this.index++;
            }
        }

        public T Pop()
        {
            T element = this.data[this.index];
            this.data.RemoveAt(this.index);
            this.index--;

            return element;

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.data)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
