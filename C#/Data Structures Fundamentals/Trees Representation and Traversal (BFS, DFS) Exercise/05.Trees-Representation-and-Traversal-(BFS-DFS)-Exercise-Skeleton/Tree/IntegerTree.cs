namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();

            var currPath = new LinkedList<int>();

            currPath.AddFirst(this.Key);

            int currSum = this.Key;

            this.DfsGetPathsWithGivenSum(this, result, currPath, ref currSum, sum);

            return result;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();

            var queue = new Queue<Tree<int>>();

            queue.Enqueue(this);

            while (queue != null)
            {
                var subtree = queue.Dequeue();
                
                int subtreeSum = 0;

                this.DfsGetSubtreesWithGivenSum(subtree, ref subtreeSum);

                if (subtreeSum == sum)
                {
                    result.Add(subtree);
                }

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private void DfsGetSubtreesWithGivenSum(Tree<int> subtree, ref int subtreeSum)
        {
            subtreeSum += subtree.Key;

            foreach (var child in subtree.Children)
            {
                DfsGetSubtreesWithGivenSum(child, ref subtreeSum);
            }
        }

        private void DfsGetPathsWithGivenSum
            (IntegerTree subtree, List<List<int>> result, LinkedList<int> currPath, ref int currSum, int sum)
        {
            foreach (var child in subtree.Children)
            {
                currSum += child.Key;
                currPath.AddLast(child.Key);

                if (currSum == sum)
                {
                    result.Add(currPath.ToList());
                }
            }
        }

    }
}
