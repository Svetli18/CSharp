namespace AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T element)
            {
                this.Element = element;
                this.Level = 1;
                this.Count = 1;
            }

            public T Element { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public int Level { get; set; }
            public int Count { get; set; }
        }

        private Node root;

        public int Count()
        {
            return this.root != null ? this.root.Count : 0;
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }
        
        public bool Contains(T element)
        {
            return this.Contains(element, this.root);
        }

        public void InOrder(Action<T> action)
        {
            this.InOrder(action, this.root);
        }

        public void PreOrder(Action<T> action)
        {
            this.PreOrder(action, this.root);
        }

        public void PostOrder(Action<T> action)
        {
            this.PostOrder(action, root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }

            if (node.Element.CompareTo(element) > 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (node.Element.CompareTo(element) < 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            node = this.Skew(node);
            node = this.Split(node);

            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return node;
        }

        private Node Skew(Node node)
        {
            if (node.Level == node.Left?.Level)
            {
                Node temp = node.Left;
                node.Left = temp.Right;
                temp.Right = node;

                node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

                return temp;
            }

            return node;
        }

        private Node Split(Node node)
        {
            if (node.Level == node.Right?.Right?.Level)
            {
                Node temp = node.Right;
                node.Right = temp.Left;
                temp.Left = node;

                node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
                temp.Level = 1 + this.GetLevel(temp.Right);

                return temp;
            }

            return node;
        }

        private bool Contains(T element, Node node)
        {
            bool result = false;

            if (node == null)
            {
                return false;
            }

            if (node.Element.Equals(element))
            {
                return true;
            }

            if (node.Element.CompareTo(element) > 0)
            {
                result = this.Contains(element, node.Left);
            }
            else if (node.Element.CompareTo(element) < 0)
            {
                result = this.Contains(element, node.Right);
            }

            return result;
        }

        private void InOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.InOrder(action, node.Left);
            action.Invoke(node.Element);
            this.InOrder(action, node.Right);
        }

        private void PreOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            action.Invoke(node.Element);
            this.PreOrder(action, node.Left);
            this.PreOrder(action, node.Right);
        }

        private void PostOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.PostOrder(action, node.Left);
            this.PostOrder(action, node.Right);
            action.Invoke(node.Element);
        }

        private int GetCount(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private int GetLevel(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Level;
        }
    }
}