namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T value = default, Node next = null, Node previous = null)
            {
                this.Value = value;
                this.Next = next;
                this.Previous = previous;
            }

            public T Value { get; set; }

            public Node Next { get; set; }

            public Node Previous { get; set; }
        }

        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            this.head = new Node();
            this.tail = new Node();
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (this.Count == 0)
            {
                this.head.Value = item;
                this.tail.Value = item;
            }
            else if (this.Count == 1)
            {
                Node newHead = new Node(item);
                newHead.Next = this.head;
                this.head = newHead;
                this.head.Next = this.tail;
                this.tail.Previous = this.head;
            }
            else
            {
                Node newHead = new Node(item);
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            if (this.Count == 0)
            {
                this.head.Value = item;
                this.tail.Value = item;
            }
            else if (this.Count == 1)
            {
                Node newTail = new Node(item);
                newTail.Previous = this.tail;
                this.tail = newTail;
                this.tail.Previous = this.head;
                this.head.Next = this.tail;
            }
            else
            {
                Node newTail = new Node(item);
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureDataIsNotEmpty();

            return this.head.Value;
        }

        

        public T GetLast()
        {
            this.EnsureDataIsNotEmpty();

            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            this.EnsureDataIsNotEmpty();

            T value = this.head.Value;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            this.Count--;

            return value;
        }

        public T RemoveLast()
        {
            this.EnsureDataIsNotEmpty();

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

        private void EnsureDataIsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}