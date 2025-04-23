namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var keys = line.Split(' ').Select(x => int.Parse(x)).ToList();

                var parent = keys[0];
                var child = keys[1];

                this.AddEdge(parent, child);
            }

            return this.GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!this.nodesByKey.ContainsKey(key))
            {
                this.nodesByKey[key] = new IntegerTree(key);
            }

            return this.nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parendNode = this.CreateNodeByKey(parent);
            var childNode = this.CreateNodeByKey(child);

            parendNode.AddChild(childNode);
            childNode.AddParent(parendNode);
        }

        public IntegerTree GetRoot()
        {
            foreach (var currentNode in this.nodesByKey)
            {
                if (currentNode.Value.Parent == null)
                {
                    return currentNode.Value;
                }
            }

            return null;
        }
    }
}
