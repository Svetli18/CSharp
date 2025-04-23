namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T> 
        : IBinarySearchTree<T> where T : IComparable
    {
        private Node root;

        public RedBlackTree()
        {
        }

        public int Count { get { return root != null? root.Count : 0; } }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
            this.root.Color = Color.Black;
        }

        public T Select(int rank)
        {
            T result = this.Select(rank, this.root);

            return result;
        }

        private T Select(int rank, Node node)
        {
            if (node == null)
            {
                return default(T);
            }

            int leftCount = this.GetCount(node.Left);

            if (leftCount == rank)
            {
                return node.Value;
            }
            else if (leftCount > rank)
            {
                return this.Select(rank, node.Left);
            }

            return this.Select(rank - (leftCount + 1), node.Right);
        }

        public int Rank(T element)
        {
            return this.Rank(element, this.root);
        }

        private int Rank(T element, Node node)
        {
            int result = 0;
            RedBlackTree<T> tree = new RedBlackTree<T>();
            tree.root = node;
            Node currNode = tree.root;

            while (currNode != null)
            {
                if (currNode.Value.CompareTo(element) > 0)
                {
                    currNode = currNode.Left;
                }
                else if (currNode.Value.CompareTo(element) < 0)
                {
                    result += 1 + this.GetCount(currNode.Left);
                    currNode = currNode.Right;
                }
                else
                {
                    return result + this.GetCount(currNode.Left);
                }
            }

            return result;
        }

        public bool Contains(T element)
        {
            bool result = this.Contains(this.root, element);

            return result;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node node = this.FaindElement(this.root, element);
            RedBlackTree<T> tree = new RedBlackTree<T>();
            tree.root = node;

            return tree;
        }

        private Node FaindElement(Node node, T element)
        {
            Node result = null;

            if (node == null)
            {
                result = null;
                return result;
            }
            else if (node.Value.Equals(element))
            {
                result = node;
                return result;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                result = this.FaindElement(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                result = this.FaindElement(node.Right, element);
            }

            return result;
        }

        public void DeleteMin()
        {
            if (this.root == null)
            {
                throw new ArgumentNullException();
            }

            Node parent = null;
            this.DeleteMin(this.root, parent);
        }

        

        public void DeleteMax()
        {
            if (this.root == null)
            {
                throw new ArgumentNullException();
            }

            Node parent = null;
            this.DeleteMax(this.root, parent);
        }

        public void Delete(T element)
        {
            if (this.root == null)
            {
                throw new ArgumentNullException();
            }

            this.root = this.Delete(this.root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Delete(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Delete(node.Right, element);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }
                if (node.Left == null)
                {
                    return node.Right;
                }
                //tuk vzimame noda!
                Node temp = node;
                //tuk vzimame minimalniq node ot dqsnata strana na segashniq node!!!
                node = this.FaindMin(temp.Right);
                //i tuk tozi node(minimalniq) kudeto vzehme go pravim node(glaven), a parenta mu go vrushtame kato dqsno dete na node(glaven)!!
                node.Right = DeleteMin2(temp.Right);
                //tuk temp prosto dava levite deca na node(iztritiq) i 
                node.Left = temp.Left;
            }

            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return node;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            List<T> result = new List<T>();

            this.Range(startRange, endRange, this.root, result);

            return result;
        }

        private void Range(T startRange, T endRange, Node node, List<T> result)
        {
            this.Range(startRange, endRange, node.Left, result);
            if (node.Value.CompareTo(startRange) >= 0 && node.Value.CompareTo(endRange) <= 0)
            {
                result.Add(node.Value);
            }
            this.Range(startRange, endRange, node.Right, result);
        }

        public T Ceiling(T element)
        {
            return this.Select(this.Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return this.Select(this.Rank(element) - 1);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);
            action.Invoke(node.Value);
            this.EachInOrder(action, node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            if (node.Left != null && node.Right != null && node.Left.Color.Equals(Color.Red) && node.Right.Color.Equals(Color.Red))
            {
                this.FlipColors(node);
            }

            if (node.Right != null && node.Right.Color.Equals(Color.Red))
            {
                node = this.RotateLeft(node);
            }

            if (node.Left != null && node.Left.Left != null && node.Left.Color.Equals(Color.Red) && node.Left.Left.Color.Equals(Color.Red))
            {
                node = this.RotateRight(node);
            }

            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return node;
        }

        private Node FaindMin(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        private void DeleteMin(Node node, Node parent)
        {
            if (node.Left == null)
            {
                parent.Left = node.Right;
            }
            else if (node.Left == null && node.Right == null)
            {
                this.root = null;
            }
            else if (node.Left == null && node.Right != null)
            {
                this.root = this.root.Right;
            }
            else
            {
                parent = node;

                this.DeleteMin(node.Left, parent);
            }

            parent.Count = 1 + this.GetCount(parent.Left) + this.GetCount(parent.Right);
        }

        private Node DeleteMin2(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = this.DeleteMin2(node.Left);
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return node;
        }

        private void DeleteMax(Node node, Node parent)
        {
            if (node.Right == null)
            {
                parent.Right = node.Left;
            }
            else if (node.Left == null && node.Right == null)
            {
                this.root = null;
            }
            else if (node.Left != null && node.Right == null)
            {
                this.root = this.root.Left;
            }
            else
            {
                parent = node;

                this.DeleteMax(node.Right, parent);
            }

            parent.Count = 1 + this.GetCount(parent.Left) + this.GetCount(parent.Right);
        }

        private void FlipColors(Node node)
        {
            node.Color = Color.Red;
            node.Left.Color = Color.Black;
            node.Right.Color = Color.Black;
        }

        private Node RotateLeft(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            temp.Color = node.Color;
            node.Color = Color.Red;
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return temp;
        }

        private Node RotateRight(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            temp.Color = node.Color;
            node.Color = Color.Red;
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return temp;
        }

        private int GetCount(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private bool Contains(Node node, T element)
        {
            bool result = false;

            if (node == null)
            {
                return false;
            }
            else if (node.Value.Equals(element))
            {
                result = true;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                result = this.Contains(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                result = this.Contains(node.Right, element);
            }

            return result;
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Color Color { get; set; }
            public int Count { get; set; }
        }

        private enum Color
        {
            Red,
            Black
        }
    }
}