namespace ConsoleApp1
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] data;
        private int headIndex;
        private int tailIndex;

        public CircularQueue(int capacity = 4)
        {
            this.data = new T[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.data[this.headIndex];

            this.data[this.headIndex] = default;
            this.headIndex++;

            if (this.headIndex == this.data.Length)
            {
                this.headIndex = 0;
            }

            this.Count--;

            return element;
        }

        public void Enqueue(T item)
        {
            this.GrowIfNecessary();

            if (Count == 0)
            {
                this.headIndex = 0;
                this.tailIndex = 0;
                this.data[this.headIndex] = item;
            }
            else
            {
                this.tailIndex++;

                if (this.Count == this.data.Length)
                {
                    this.tailIndex = 0;
                }

                this.data[this.tailIndex] = item;
            }

            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.data[this.headIndex];
        }

        public T[] ToArray()
        {
            if (this.Count == 0)
            {
                return Array.Empty<T>();
            }

            List<T> list = new List<T>();

            if (this.tailIndex < this.headIndex)
            {
                for (int i = this.headIndex; i < this.data.Length; i++)
                {
                    list.Add(this.data[i]);
                }

                for (int i = 0; i <= this.tailIndex; i++)
                {
                    list.Add(this.data[i]);
                }
            }
            else
            {
                for (int i = this.headIndex; i <= this.tailIndex; i++)
                {
                    list.Add(this.data[i]);
                }
            }

            return list.ToArray();
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (this.tailIndex < this.headIndex)
            {
                for (int i = this.headIndex; i < this.data.Length; i++)
                {
                    yield return this.data[i];
                }

                for (int i = 0; i <= this.tailIndex; i++)
                {
                    yield return this.data[i];
                }
            }
            else
            {
                for (int i = this.headIndex; i <= this.tailIndex; i++)
                {
                    yield return this.data[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void GrowIfNecessary()
        {
            if (this.Count == this.data.Length)
            {
                this.Grow();
            }
        }

        private void Grow()
        {
            T[] newData = new T[this.data.Length * 2];

            Array.Copy(this.data, newData, this.Count);

            this.data = newData;
        }

    }
}
