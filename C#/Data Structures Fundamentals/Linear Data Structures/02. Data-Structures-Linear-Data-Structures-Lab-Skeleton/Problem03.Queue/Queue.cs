namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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

        private Node head;

        public Queue()
        {
            this.head = null;
            this.Count = 0;
        }

        public int Count {get; private set; }

        public void Enqueue(T item)
        {
            Node toInsert = new Node(item);

            if (this.head == null)
            {
                this.head = toInsert;
            }
            else
            {
                Node currNode = this.head;

                while (currNode.Next != null)
                {
                    currNode = currNode.Next;
                }

                currNode.Next = toInsert;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            this.EnsureStackIsNotEmpty();

            T element = this.head.Value;

            this.head = this.head.Next;
            this.Count--;

            return element;
        }

        public T Peek()
        {
            this.EnsureStackIsNotEmpty();

            return this.head.Value;
        }

        public bool Contains(T item)
        {
            bool isFound = false;
            Node currHead = this.head;

            while (currHead != null)
            {
                if (currHead.Value.Equals(item))
                {
                    isFound = true;
                }

                currHead = currHead.Next;
            }

            return isFound;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currHead = this.head;

            while (currHead != null)
            {
                yield return currHead.Value;
                currHead = currHead.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureStackIsNotEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}