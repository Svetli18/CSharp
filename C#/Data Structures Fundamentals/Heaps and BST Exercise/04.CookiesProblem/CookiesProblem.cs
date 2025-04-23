namespace _04.CookiesProblem
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class CookiesProblem
    {
        private List<int> _elements;
        public CookiesProblem()
        {
            this._elements = new List<int>();
        }

        public int Solve(int k, int[] cookies)
        {
            foreach (var cookie in cookies)
            {
                this._elements.Add(cookie);

                if (0 < this._elements.Count)
                {
                    HeapIfyUp();
                }
            }

            bool isPast = false;
            int result = 0;

            int firstCookie = 0;

            if (0 < this._elements.Count)
            {
                firstCookie = this._elements[0];
                Swap(0, this._elements.Count - 1);
                this._elements.RemoveAt(this._elements.Count - 1);
                HeapIfyDown(0);
            }

            while (firstCookie < k && 0 < this._elements.Count)
            {
                int secondCookie = this._elements[0];
                Swap(0, this._elements.Count - 1);
                this._elements.RemoveAt(this._elements.Count - 1);
                HeapIfyDown(0);
                result++;

                this._elements.Add(firstCookie + 2 * secondCookie);
                this.HeapIfyUp();

                firstCookie = this._elements[0];
                Swap(0, this._elements.Count - 1);
                this._elements.RemoveAt(this._elements.Count - 1);
                HeapIfyDown(0);

                if (k < firstCookie)
                {
                    isPast = true;
                    break;
                }
            }

            if (!isPast)
            {
                return -1;
            }

            return result;
        }

        private void HeapIfyUp()
        {
            int elementIndex = this._elements.Count - 1;
            int parentIndex = (elementIndex - 1) / 2;

            while (this.ValidateIndex(parentIndex) &&
                this._elements[elementIndex].CompareTo(this._elements[parentIndex]) < 0)
            {
                this.Swap(elementIndex, parentIndex);
                elementIndex = parentIndex;
                parentIndex = (elementIndex - 1) / 2;
            }
        }

        private void HeapIfyDown(int index)
        {

            int elementIndex = index;
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
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = this._elements[firstIndex];
            this._elements[firstIndex] = this._elements[secondIndex];
            this._elements[secondIndex] = temp;
        }

        private bool ValidateIndex(int index)
        {
            if (0 <= index && index < this._elements.Count)
            {
                return true;
            }

            return false;
        }
    }
}
