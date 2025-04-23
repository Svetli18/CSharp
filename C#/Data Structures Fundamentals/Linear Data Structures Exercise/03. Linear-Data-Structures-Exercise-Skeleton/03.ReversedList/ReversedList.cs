namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) 
        {
        }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[this.Count - 1 - index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowsIfNecessary();

            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            index = this.Count - index;

            this.GrowsIfNecessary();

            for (int i = this.Count++; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
        }


        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (-1 < index)
            {
                this.RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            index = this.Count - 1 - index;


            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void GrowsIfNecessary()
        {
            if (this.Count == this.items.Length)
            {
                T[] newArray = new T[this.Count * 2]; 

                Array.Copy(this.items, newArray, this.Count);

                this.items = newArray;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || this.Count <= index)
            {
                throw new IndexOutOfRangeException();
            }
        }

    }
}