namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) 
        {
        }

        public List(int capacity = DEFAULT_CAPACITY)
        {
            this.items = new T[capacity];
            this.Count = 0;
        }

        public T this[int index] 
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.CheckArrayForResize();
            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            int index = this.IndexOf(item);

            if (index != -1)
            {
                return true;
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            if (this.Contains(item))
            {
                this.RemoveAt(this.IndexOf(item));

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            if (0 < this.Count)
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    this.items[i] = this.items[i + 1];
                }

                this.items[this.Count - 1] = default;
                this.Count--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || this.Count <= index)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void CheckArrayForResize()
        {
            if (this.Count == this.items.Length)
            {
                this.ResizeArray();
            }
        }

        private void ResizeArray()
        {
            T[] newArray = new T[this.items.Length * 2];
            Array.Copy(this.items, newArray, this.Count);
            this.items = newArray;
        }
    }
}