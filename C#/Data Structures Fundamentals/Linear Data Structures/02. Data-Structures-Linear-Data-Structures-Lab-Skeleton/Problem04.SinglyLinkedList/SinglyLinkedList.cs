namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T value, Node next = null, Node previous = null)
            {
                this.Value = value;
                this.Next = next;
            }

            public T Value { get; set; }

            public Node Next { get; set; }

            public Node Previous { get; set; }
        }

        private Node head;
        private Node tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node newHead = new Node(item, this.head);

            if (this.head == null)
            {
                this.head = newHead;
                this.tail = newHead;
            }
            else
            {
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newTail = new Node(item);

            if (this.Count == 0)
            {
                this.head = newTail;
                this.tail = newTail;
                this.head.Next = this.tail;
                this.tail.Previous = this.head;
            }
            else
            {
                this.tail.Next = newTail;
                newTail.Previous = this.tail;
                this.tail = newTail;
            }

            this.Count++;
        }


        public T GetFirst()
        {
            this.EnsureStackIsNotEmpty();

            return this.head.Value;
        }

        public T GetLast()
        {
            this.EnsureStackIsNotEmpty();

            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            this.EnsureStackIsNotEmpty();

            T value = this.head.Value;

            Node newHead = this.head.Next;
            this.head = newHead;
            this.Count--;

            return value;
        }

        public T RemoveLast()
        {
            this.EnsureStackIsNotEmpty();

            T value = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }

            this.Count--;

            return value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
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