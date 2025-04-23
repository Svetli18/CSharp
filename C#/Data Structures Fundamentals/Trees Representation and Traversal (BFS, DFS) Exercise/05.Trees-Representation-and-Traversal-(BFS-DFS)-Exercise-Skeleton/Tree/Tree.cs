namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private ICollection<Tree<T>> _children;

        private Tree() 
        {
            this._children = new List<Tree<T>>();
        }
        public Tree(T key, params Tree<T>[] children)
            :this()
        {
            this.Key = key;

            foreach (var child in children)
            {
                this.AddChild(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children
            => (IReadOnlyCollection<Tree<T>>)this._children;

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
            child.Parent = this;
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            StringBuilder sb = new StringBuilder();

            this.DfsAsString(this, sb, 0);

            return sb.ToString().TrimEnd();
        }
        
        public IEnumerable<T> GetInternalKeys()
        {
            var result = new List<T>();

            this.DfsWithResultKeys(this, x => x._children.Count > 1 && x.Parent != null, result);

            return result;
        }
        
        public IEnumerable<T> GetLeafKeys()
        {
            var result = new List<T>();

            this.DfsWithResultKeys(this, x => x._children.Count == 0, result);

            return result;
        }

        public T GetDeepestKey()
        {
            Tree<T> result = this;

            this.DfsGetDeepestNode(this, result, 0, 0);

            return result.Key;
        }
        
        public IEnumerable<T> GetLongestPath()
        {
            ICollection<T> result = new List<T>();

            Tree<T> treeNode = null;

            this.DfsGetDeepestNode(this, treeNode, 0, 0);

            while (treeNode != null)
            {
                result.Add(treeNode.Key);

                treeNode = treeNode.Parent;
            }

            return result.Reverse();
        }

        private void DfsGetDeepestNode(Tree<T> tree, Tree<T> deepestNode, int cnt, int depth)
        {
            foreach (var child in tree.Children)
            {
                this.DfsGetDeepestNode(child, deepestNode, cnt + 1, depth);
            }

            if (depth < cnt)
            {
                depth = cnt;
                deepestNode = tree;            
            }
        }

        private void DfsAsString(Tree<T> tree, StringBuilder sb, int cntSpace)
        {
            sb.Append(' ', cntSpace)
              .AppendLine(tree.Key.ToString());

            foreach (var child in tree.Children)
            {
                this.DfsAsString(child, sb, cntSpace + 2);
            }
        }

        private void DfsWithResultKeys(Tree<T> subtree, Predicate<Tree<T>> predicate, List<T> result)
        {
            if (predicate.Invoke(subtree))
            {
                result.Add(subtree.Key);
            }

            foreach (var child in subtree.Children)
            {
                DfsWithResultKeys(child, predicate, result);
            }
        }
    }
}
