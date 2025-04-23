namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            T result = this.DfsGetCommonAncestor(this, first, second);

            return result;
        }

        private T DfsGetCommonAncestor(BinaryTree<T> binaryTree, T first, T second)
        {
            T result = default(T);

            if (binaryTree.Value.CompareTo(first) > 0 && binaryTree.Value.CompareTo(second) < 0)
            {
                return binaryTree.Value;
            }

            if (binaryTree.Value.CompareTo(first) < 0)
            {
                result = DfsGetCommonAncestor(binaryTree.RightChild, first, second);
            }

            if (binaryTree.Value.CompareTo(second) > 0)
            {
                result = DfsGetCommonAncestor(binaryTree.LeftChild, first, second);
            }

            return result;
        }
    }
}
