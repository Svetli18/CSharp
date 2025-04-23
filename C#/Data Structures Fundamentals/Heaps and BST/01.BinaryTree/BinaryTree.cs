namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild = null
            , IAbstractBinaryTree<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            string result = this.DFSIndentedPreOrder(this, indent);

            return result;
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            this.DFSInOrderCollection(this, result);

            return result;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            this.DFSPostOrderCollection(this, result);

            return result;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            this.DFSPreOrderCollection(this, result);

            return result;
        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.ForEachInOrder(action);
            }
        }

        private void DFSPreOrderCollection(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> result)
        {
            result.Add(binaryTree);

            if (binaryTree.LeftChild != null)
            {
                this.DFSPreOrderCollection(binaryTree.LeftChild, result);
            }

            if (binaryTree.RightChild != null)
            {
                this.DFSPreOrderCollection(binaryTree.RightChild, result);
            }
        }

        private void DFSPostOrderCollection(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> result)
        {
            if (binaryTree.LeftChild != null)
            {
                this.DFSPostOrderCollection(binaryTree.LeftChild, result);
            }

            if (binaryTree.RightChild != null)
            {
                this.DFSPostOrderCollection(binaryTree.RightChild, result);
            }

            result.Add(binaryTree);
        }

        private string DFSIndentedPreOrder(IAbstractBinaryTree<T> subtree, int indent)
        {
            string result = $"{new string(' ', indent)}{subtree.Value}{Environment.NewLine}";

            if (subtree.LeftChild != null)
            {
                result += DFSIndentedPreOrder(subtree.LeftChild, indent + 2);
            }

            if (subtree.RightChild != null)
            {
                result += DFSIndentedPreOrder(subtree.RightChild, indent + 2);
            }

            return result;
        }

        private void DFSInOrderCollection(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> result)
        {

            if (binaryTree.LeftChild != null)
            {
                DFSInOrderCollection(binaryTree.LeftChild, result);
            }

            result.Add(binaryTree);

            if (binaryTree.RightChild != null)
            {
                DFSInOrderCollection(binaryTree.RightChild, result);
            }
        }
    }
}
