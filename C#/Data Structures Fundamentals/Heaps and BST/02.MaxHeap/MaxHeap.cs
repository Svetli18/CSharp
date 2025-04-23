namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _list;

        public MaxHeap()
        {
            this._list = new List<T>();
        }

        public int Size { get { return this._list.Count; } }

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

        private void Swap(int parentIndex, int childIndex)
        {
            T temp = this._list[parentIndex];
            this._list[parentIndex] = this._list[childIndex];
            this._list[childIndex] = temp;
        }
    }
}
