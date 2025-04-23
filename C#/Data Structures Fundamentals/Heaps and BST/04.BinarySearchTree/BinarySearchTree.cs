namespace _04.BinarySearchTree
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
        {
            // TODO: Create copy from root
            this.Root = root;
            this.LeftChild = root.LeftChild;
            this.RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            bool result = this.DfsSearch(this.Root, element);

            return result;
        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(element);
            }
            else
            {
                this.DfsInsert(this.Root, element);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            IAbstractBinarySearchTree<T> result = this.DfsSearchSubtree(this.Root, element);

            return result;
        }

        private IAbstractBinarySearchTree<T> DfsSearchSubtree(Node<T> subtree, T element)
        {
            IAbstractBinarySearchTree<T> result = null;

            if (subtree.Value.Equals(element))
            {
                result = new BinarySearchTree<T>(new Node<T>(element, subtree.LeftChild, subtree.RightChild));
            }

            if (subtree.Value.CompareTo(element) > 0)
            {
                result = this.DfsSearchSubtree(subtree.LeftChild, element);
            }

            if (subtree.Value.CompareTo(element) < 0)
            {
                result = this.DfsSearchSubtree(subtree.RightChild, element);
            }

            return result;
        }

        private bool DfsSearch(Node<T> binarySearchTree, T element)
        {
            bool result = false;

            if (binarySearchTree == null)
            {
                return result;
            }

            if (binarySearchTree.Value.CompareTo(element) == 0)
            {
                result = true;
            }

            if (binarySearchTree.Value.CompareTo(element) > 0)
            {
                result = this.DfsSearch(binarySearchTree.LeftChild, element);
            }

            if (binarySearchTree.Value.CompareTo(element) < 0)
            {
                result = this.DfsSearch(binarySearchTree.RightChild, element);
            }

            return result;
        }

        private void DfsInsert(Node<T> subtree, T element)
        {
            if (subtree.Value.CompareTo(element) > 0)
            {
                if (subtree.LeftChild == null)
                {
                    subtree.LeftChild = new Node<T>(element);
                    return;
                }

                this.DfsInsert(subtree.LeftChild, element);
            }
            else
            {
                if (subtree.RightChild == null)
                {
                    subtree.RightChild = new Node<T>(element);
                    return;
                }

                this.DfsInsert(subtree.RightChild, element);
            }
        }
    }
}
