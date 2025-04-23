namespace _05.TopView
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
            this.elements = new List<T>();
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var result = new Dictionary<int, (T nodeValue, int level)>();

            this.DfsTopView(this, result, 0, 1);

            foreach (var kvp in result)
            {
                this.elements.Add(kvp.Value.nodeValue);
            }

            return this.elements;
        }

        private void DfsTopView(BinaryTree<T> binaryTree, Dictionary<int, (T nodeValue, int level)> result, int horizontalDistance, int depthLevel)
        {
            if (binaryTree == null)
            {
                return;
            }

            if (!result.ContainsKey(horizontalDistance))
            {
                result[horizontalDistance] = (binaryTree.Value, depthLevel);
            }

            this.DfsTopView(binaryTree.LeftChild, result, horizontalDistance - 1, depthLevel + 1);
            this.DfsTopView(binaryTree.RightChild, result, horizontalDistance + 1, depthLevel + 1);
        }
    }
}
