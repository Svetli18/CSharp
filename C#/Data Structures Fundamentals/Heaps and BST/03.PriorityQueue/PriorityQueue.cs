namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _list;

        public PriorityQueue()
        {
            this._list = new List<T>();
        }

        public int Size { get { return this._list.Count; } }

        public T Dequeue()
        {
            if (this._list.Count == 0)
            {
                return default(T);
            }

            T element = this._list[0];

            if (1 < this._list.Count)
            {
                this.Swap(0, this._list.Count - 1);
            }

            this._list.RemoveAt(this._list.Count - 1);
            this.HeapifyDown(0);

            return element;
        }

        public void Add(T element)
        {
            this._list.Add(element);
            this.HeapifyUp(this._list.Count - 1);
        }

        public T Peek()
        {
            return this._list.Count > 0 ? this._list[0] : default(T);
        }

        private void HeapifyUp(int childIndex)
        {

            if (0 < this._list.Count)
            {
                int parentIndex = (childIndex - 1) / 2;

                if (this._list[childIndex].CompareTo(this._list[parentIndex]) > 0)
                {
                    this.Swap(parentIndex, childIndex);
                    this.HeapifyUp(parentIndex);
                }
            }
        }

        private void HeapifyDown(int parentIndex)
        {
            int leftChildIndex = 2 * parentIndex + 1;
            int rightChildIndex = 2 * parentIndex + 2;

            if (leftChildIndex < this._list.Count - 1 && this._list[leftChildIndex].CompareTo(this._list[rightChildIndex]) < 0)
            {
                leftChildIndex = rightChildIndex;
            }

            if (leftChildIndex < this._list.Count && this._list[parentIndex].CompareTo(this._list[leftChildIndex]) < 0)
            {
                this.Swap(parentIndex, leftChildIndex);
                this.HeapifyDown(leftChildIndex);
            }
        }

        private void Swap(int parentIndex, int childIndex)
        {
            T temp = this._list[parentIndex];
            this._list[parentIndex] = this._list[childIndex];
            this._list[childIndex] = temp;
        }
    }
}
