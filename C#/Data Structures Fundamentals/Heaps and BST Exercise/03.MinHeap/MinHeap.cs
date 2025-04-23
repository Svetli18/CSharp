namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size => this._elements.Count;

        public T Dequeue()
        {
            int elementIndex = 0;

            T result = this._elements[elementIndex];
            this.Swap(0, this.Size - 1);
            this._elements.RemoveAt(this.Size - 1);
            int leftChildIndex = 2 * elementIndex + 1;

            while (this.ValidateIndex(leftChildIndex) &&
                this._elements[elementIndex].CompareTo(this._elements[leftChildIndex]) > 0)
            {
                int rightChildIndex = 2 * elementIndex + 2;

                if (this.ValidateIndex(rightChildIndex) &&
                    this._elements[leftChildIndex].CompareTo(this._elements[rightChildIndex]) > 0)
                {
                    leftChildIndex = rightChildIndex;
                }

                this.Swap(elementIndex, leftChildIndex);
                elementIndex = leftChildIndex;
                leftChildIndex = 2 * elementIndex + 1;
            }

            return result;
        }
        
        public void Add(T element)
        {
            this._elements.Add(element);

            if (0 < this.Size)
            {
                int elementIndex = this.Size - 1;
                int parentIndex = (elementIndex - 1) / 2;

                while (this.ValidateIndex(parentIndex) && 
                    this._elements[elementIndex].CompareTo(this._elements[parentIndex]) < 0)
                {
                    this.Swap(elementIndex, parentIndex);
                    elementIndex = parentIndex;
                    parentIndex = (elementIndex - 1) / 2;
                }
            }
        }

        public T Peek()
        {
            return this._elements[0];
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            T temp = this._elements[firstIndex];
            this._elements[firstIndex] = this._elements[secondIndex];
            this._elements[secondIndex] = temp;
        }

        private bool ValidateIndex(int index)
        {
            if (0 <= index && index < this.Size)
            {
                return true;
            }

            return false;
        }
    }
}
