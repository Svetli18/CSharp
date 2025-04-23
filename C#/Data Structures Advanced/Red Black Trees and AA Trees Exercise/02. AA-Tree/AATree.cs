namespace _02._AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int CountNodes()
        {
            return this.root != null? this.root.Count : 0;
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Clear()
        {
            this.root = null;
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Search(T element)
        {
            bool result = this.Search(element, this.root);

            return result;
        }
       
        public void InOrder(Action<T> action)
        {
            this.InOrder(this.root, action);
        }

        public void PreOrder(Action<T> action)
        {
            this.PreOrder(this.root, action);
        }


        public void PostOrder(Action<T> action)
        {
            this.PostOrder(this.root, action);
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(element);
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

        private Node<T> Skew(Node<T> node)
        {
            if (node.Level == node.Left?.Level)
            {
                Node<T> temp = node.Left;
                node.Left = temp.Right;
                temp.Right = node;

                node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

                return temp;
            }

            return node;
        }

        private Node<T> Split(Node<T> node)
        {
            if (node.Level == node.Right?.Right?.Level)
            {
                Node<T> temp = node.Right;
                node.Right = temp.Left;
                temp.Left = node;

                node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
                temp.Level = 1 + this.Level(temp.Right);

                return temp;
            }

            return node;
        }

        private bool Search(T element, Node<T> node)
        {
            bool result = false;

            if (node == null)
            {
                return result;
            }

            if (node.Element.Equals(element))
            {
                result = true;
                return result;
            }

            if (node.Element.CompareTo(element) > 0)
            {
                result = this.Search(element, node.Left);
            }
            else if (node.Element.CompareTo(element) < 0)
            {
                result = this.Search(element, node.Right);
            }

            return result;
        }

        private void InOrder(Node<T> node, Action<T> inOrder)
        {
            if (node == null)
            {
                return;
            }

            this.InOrder(node.Left, inOrder);
            inOrder.Invoke(node.Element);
            this.InOrder(node.Right, inOrder);
        }

        private void PreOrder(Node<T> node, Action<T> preOrder)
        {
            if (node == null)
            {
                return;
            }

            preOrder.Invoke(node.Element);
            this.PreOrder(node.Left, preOrder);
            this.PreOrder(node.Right, preOrder);
        }

        private void PostOrder(Node<T> node, Action<T> postOrder)
        {
            if (node == null)
            {
                return;
            }

            this.PostOrder(node.Left, postOrder);
            this.PostOrder(node.Right, postOrder);
            postOrder.Invoke(node.Element);
        }

        private int GetCount(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private int Level(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Level;
        }
    }
}