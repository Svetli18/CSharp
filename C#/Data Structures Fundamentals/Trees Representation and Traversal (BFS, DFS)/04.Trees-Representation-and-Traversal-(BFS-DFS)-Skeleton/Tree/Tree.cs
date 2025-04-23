namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private IList<Tree<T>> childs;

        public Tree(T value)
        {
            this.Value = value;
            this.childs = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                this.childs.Add(child);
                child.Parent = this;
            }
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parent = this.FaindSubtreeBFS(parentKey);

            if (parent == null)
            {
                throw new ArgumentNullException();
            }

            parent.childs.Add(child);
            child.Parent = parent;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (0 < queue.Count)
            {
                Tree<T> subtree = queue.Dequeue();

                yield return subtree.Value;

                foreach (var child in subtree.childs)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public IEnumerable<T> OrderDfs()
        {
            ICollection<T> result = new List<T>();

            if (this == null)
            {
                throw new ArgumentNullException();
            }

            this.GetCollectionByDfs(this, result);

            foreach (var element in result)
            {
                yield return element;
            }
        }


        public void RemoveNode(T nodeKey)
        {
            Tree<T> subtree = FaindSubtreeBFS(nodeKey);
            bool isRoot = false;

            if (subtree == null)
            {
                throw new ArgumentNullException();
            }

            if (!subtree.Equals(this))
            {
                subtree.childs.Clear();
                isRoot = subtree.Parent.childs.Remove(subtree);
            }

            if (!isRoot)
            {
                throw new ArgumentException();
            }
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstSubtree = this.FaindSubtreeBFS(firstKey);
            Tree<T> secondSubtree = this.FaindSubtreeBFS(secondKey);

            if (firstSubtree == null || secondSubtree == null)
            {
                throw new ArgumentNullException();
            }
            else if (firstSubtree.Equals(this) || secondSubtree.Equals(this))
            {
                throw new ArgumentException();
            }
            else if (firstSubtree.Parent.Equals(secondSubtree))
            {
                secondSubtree = SwapToParentPlace(firstSubtree, secondSubtree);
            }
            else if (secondSubtree.Parent.Equals(firstSubtree))
            {
                firstSubtree = SwapToParentPlace(secondSubtree, firstSubtree);
            }
            else
            {
                var firstParent = firstSubtree.Parent;
                var secondParent = secondSubtree.Parent;
                var indexOfFirst = firstParent.childs.IndexOf(firstSubtree);
                var indexOfSecond = secondParent.childs.IndexOf(secondSubtree);
                firstSubtree.Parent = secondParent;
                secondSubtree.Parent = firstParent;
                firstParent.childs.Remove(firstSubtree);
                secondParent.childs.Remove(secondSubtree);
                firstParent.childs.Insert(indexOfFirst, secondSubtree);
                secondParent.childs.Insert(indexOfSecond, firstSubtree);
            }

            if (secondSubtree.Parent == null)
            {
                this.Value = firstSubtree.Value;
                this.childs.Clear();

                foreach (var child in firstSubtree.childs)
                {
                    child.Parent = this;
                    this.childs.Add(child);
                }
            }
        }

        public Tree<T> FaindSubtreeBFS(T key)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (0 < queue.Count)
            {
                Tree<T> subtree = queue.Dequeue();

                if (subtree.Value.Equals(key))
                {
                    return subtree;
                }

                foreach (var child in subtree.childs)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private void GetCollectionByDfs(Tree<T> subtree, ICollection<T> result)
        {
            foreach (var child in subtree.childs)
            {
                GetCollectionByDfs(child, result);
            }

            result.Add(subtree.Value);
        }

        private static Tree<T> SwapToParentPlace(Tree<T> firstSubtree, Tree<T> secondSubtree)
        {
            firstSubtree.Parent = secondSubtree.Parent;
            var index = secondSubtree.Parent.childs.IndexOf(secondSubtree);
            secondSubtree.Parent.childs.Remove(secondSubtree);
            secondSubtree.Parent.childs.Insert(index, firstSubtree);
            secondSubtree.childs.Clear();
            secondSubtree = null;
            return secondSubtree;
        }
    }
}
