namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public Node(T value, Node next = null)
            {
                this.Value = value;
                this.Next = next;
            }

            public T Value { get; set; }

            public Node Next { get; set; }
        }

        private Node top;

        public Stack()
        {
            this.top = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node newTop = new Node(item);

            if (top == null)
            {
                this.top = newTop;
            }
            else
            {
                newTop.Next = this.top;
                this.top = newTop;
            }

            this.Count++;
        }

        public T Pop()
        {
            this.EnsureStackIsNotEmpty();

            T element = this.top.Value;

            if (this.Count == 1)
            {
                this.top = null;
            }
            else
            {
                this.top = this.top.Next;
            }

            this.Count--;

            return element;
        }

        public T Peek()
        {
            this.EnsureStackIsNotEmpty();
            return this.top.Value;
        }

        public bool Contains(T item)
        {
            bool isFound = false;
            Node currTop = this.top;

            while (currTop != null)
            {
                if (currTop.Value.Equals(item))
                {
                    isFound = true;
                    break;
                }

                currTop = currTop.Next;
            }

            return isFound;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currTop = this.top;

            while (currTop != null)
            {
                yield return currTop.Value;
                currTop = currTop.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureStackIsNotEmpty()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}