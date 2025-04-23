namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
            :this()
        {
            this.Root = root;
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public bool Contains(T element)
        {
            bool result = this.DfsIsFound(this.Root, element);

            return result;
        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(element, null, null);
            }
            else
            {
                Node<T> parent = this.Root;

                if (this.Root.Value.CompareTo(element) > 0)
                {
                    this.DfsInsertElement(this.Root.LeftChild, element, parent);
                }
                else if (this.Root.Value.CompareTo(element) < 0)
                {
                    this.DfsInsertElement(this.Root.RightChild, element, parent);
                }
            }

            this.Count++;
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            IAbstractBinarySearchTree<T> result = null;

            result = this.DfsGetBinaryTreeElement(this.Root, element);

            return result;
        }

        public void EachInOrder(Action<T> action)
        {
            this.DfsEachInOrder(this.Root, action);
        }

        public List<T> Range(T lower, T upper)
        {
            List<T> result = new List<T>();

            this.DfsGetRangeCollection(this.Root, result, lower, upper);

            return result;
        }

        public void DeleteMin()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }
            else if (this.Root != null && this.Root.LeftChild == null && this.Root.RightChild == null)
            {
                this.Root = null;
            }
            else if (this.Root != null && this.Root.LeftChild == null && this.Root.RightChild != null)
            {
                this.Root = this.Root.RightChild;
            }
            else
            {
                Node<T> parent = this.Root;

                this.DfsFaindMinElementAndDelete(this.Root.LeftChild, parent);
            }

            this.Count--;
        }

        public void DeleteMax()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }
            else if (this.Root != null && this.Root.LeftChild == null && this.Root.RightChild == null)
            {
                this.Root = null;
            }
            else if (this.Root != null && this.Root.LeftChild != null && this.Root.RightChild == null)
            {
                this.Root = this.Root.LeftChild;
            }
            else
            {
                Node<T> parent = this.Root;

                this.DfsFaindMaxElementAndDelete(this.Root.RightChild, parent);
            }

            this.Count--;
        }

        public int GetRank(T element)
        {
            int result = this.DfsGetRankCount(this.Root, element);

            return result;
        }

        private bool DfsIsFound(Node<T> subtree, T element)
        {
            bool result = false;

            if (subtree == null)
            {
                return result;
            }

            if (subtree.Value.Equals(element))
            {
                result = true;
            }

            if (subtree.Value.CompareTo(element) > 0)
            {
                result = this.DfsIsFound(subtree.LeftChild, element);
            }

            if (subtree.Value.CompareTo(element) < 0)
            {
                result = this.DfsIsFound(subtree.RightChild, element);
            }

            return result;
        }

        private void DfsInsertElement(Node<T> subtree, T element, Node<T> parent)
        {
            if (subtree == null)
            {
                subtree = new Node<T>(element, null, null);

                if (parent.Value.CompareTo(element) > 0)
                {
                    parent.LeftChild = subtree;
                }
                else if (parent.Value.CompareTo(element) < 0)
                {
                    parent.RightChild = subtree;
                }

                return;
            }

            parent = subtree;

            if (subtree.Value.CompareTo(element) > 0)
            {
                this.DfsInsertElement(subtree.LeftChild, element, parent);
            }
            else if (subtree.Value.CompareTo(element) < 0)
            {
                this.DfsInsertElement(subtree.RightChild, element, parent);
            }
        }

        private IAbstractBinarySearchTree<T> DfsGetBinaryTreeElement(Node<T> subtree, T element)
        {
            IAbstractBinarySearchTree<T> result = null;

            if (subtree.Value.Equals(element))
            {
                result = new BinarySearchTree<T>(subtree);
            }

            if (subtree.Value.CompareTo(element) > 0)
            {
                result = this.DfsGetBinaryTreeElement(subtree.LeftChild, element);
            }
            else if (subtree.Value.CompareTo(element) < 0)
            {
                result = this.DfsGetBinaryTreeElement(subtree.RightChild, element);
            }

            return result;
        }

        private void DfsGetRangeCollection(Node<T> subtree, List<T> result, T lower, T upper)
        {            
            if (subtree != null && subtree.Value.CompareTo(lower) >= 0)
            {
                this.DfsGetRangeCollection(subtree.LeftChild, result, lower, upper);
            }

            if (subtree != null && subtree.Value.CompareTo(lower) >= 0 && subtree.Value.CompareTo(upper) <= 0)
            {
                result.Add(subtree.Value);
            }

            if (subtree != null && subtree.Value.CompareTo(upper) <= 0)
            {
                this.DfsGetRangeCollection(subtree.RightChild, result, lower, upper);
            }
        }

        private void DfsFaindMinElementAndDelete(Node<T> subtree, Node<T> parent)
        {
            if (subtree.LeftChild == null)
            {
                parent.LeftChild = subtree.RightChild;
                return;
            }

            parent = subtree;

            this.DfsFaindMinElementAndDelete(subtree.LeftChild, parent);
        }

        private void DfsFaindMaxElementAndDelete(Node<T> subtree, Node<T> parent)
        {
            if (subtree.RightChild == null)
            {
                parent.RightChild = subtree.LeftChild;
                return;
            }

            parent = subtree;

            this.DfsFaindMaxElementAndDelete (subtree.RightChild, parent);
        }

        private void DfsEachInOrder(Node<T> subtree, Action<T> action)
        {
            if (subtree == null)
            {
                return;
            }

            this.DfsEachInOrder(subtree.LeftChild, action);
            action.Invoke(subtree.Value);
            this.DfsEachInOrder(subtree.RightChild, action);
        }

        private int DfsGetRankCount(Node<T> node, T element)
        {
            int result = 0;

            if (node.Value.CompareTo(element) < 0)
            {
                result = 1;
            }

            if (node.LeftChild != null)
            {
                result += this.DfsGetRankCount(node.LeftChild, element);
            }

            if (node.RightChild != null)
            {
                result += this.DfsGetRankCount(node.RightChild, element);
            }

            return result;
        }
    }
}
