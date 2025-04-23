namespace MyCustomList
{
    using System;

    public class MyCustomList<T>
    {
        private T[] data;

        public MyCustomList()
        {
            this.data = new T[4];
        }

        public int Count { get; private set; }

        public int Index { get; private set; }

        public int MyListCapacity { get => this.data.Length; }

        public T[] MyRandomList { get => this.data; }

        public void Add(T element)
        {
            if (this.Count == this.MyListCapacity)
            {
                ResizeList();
            }

            this.data[this.Count] = element;
            this.Count++;

        }

        public void AddFirst(T element)
        {
            this.Insert(0, element);
        }

        public void AddLast(T element)
        {
            if (this.Count == this.MyListCapacity)
            {
                ResizeList();
            }

            this.data[this.Count] = element;
            this.Count++;
        }

        public void Insert(int index, T element)
        {
            this.Index = index;

            if (0 <= this.Index && this.Index < this.Count)
            {
                if (this.Count == this.MyListCapacity)
                {
                    ResizeList();
                }

                for (int i = this.Count; i > this.Index; i--)
                {
                    this.data[i] = this.data[i - 1];
                }

                this.data[this.Index] = element;
                this.Count++;
            }
        }

        public bool Remove(T element)
        {
            this.Index = this.IndexOf(element);

            if (this.Index < 0)
            {
                return false;
            }

            for (int i = this.Index; i < this.Count; i++)
            {
                this.data[i] = this.data[i + 1];
            }

            this.Count--;

            if (this.Count < this.MyListCapacity / 2)
            {
                ShrinkList();
            }

            return true;
        }

        public void RemoveAt(int index)
        {
            this.Index = index;

            if (0 < this.Count && 0 <= this.Index && this.Index < this.Count)
            {
                for (int i = this.Index; i < this.Count; i++)
                {
                    this.data[i] = this.data[i + 1];
                }

                this.Count--;

                if (this.Count < this.MyListCapacity / 2)
                {
                    ShrinkList();
                }
            }
        }

        public void RemoveFirst()
        {
            this.RemoveAt(0);
        }

        public void RemoveLast()
        {
            this.RemoveAt(this.Count - 1);
        }

        public void Reverse()
        {
            T[] newData = new T[this.data.Length];

            for (int i = 0; i < this.Count; i++)
            {
                newData[i] = this.data[this.Count - 1 - i];
            }

            this.data = newData;
        }

        public int IndexOf(T element)
        {
            int index = -1;

            for (int i = 0; i < this.Count; i++)
            {
                T currentElement = this.data[i];

                if (element.Equals(currentElement))
                {
                    index = i;
                }
            }

            return index;
        }

        private void ResizeList()
        {
            T[] newData = new T[this.MyListCapacity * 2];
            Array.Copy(this.data, newData, this.MyListCapacity);
            this.data = newData;
        }

        private void ShrinkList()
        {
            T[] newData = new T[this.MyListCapacity / 2];
            Array.Copy(this.data, newData, this.Count);
            this.data = newData;
        }

        public bool Contains(string element)
        {
            bool isFaindet = false;

            foreach (var curentElement in this.data)
            {
                if (element.Equals(curentElement))
                {
                    isFaindet = true;
                }
            }

            return isFaindet;
        }

        public void Clear()
        {
            this.data = new T[4];
        }
    }
}

