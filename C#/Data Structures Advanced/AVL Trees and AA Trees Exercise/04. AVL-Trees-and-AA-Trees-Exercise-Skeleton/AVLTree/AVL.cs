namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        private Node newSubtree;
        private Node oldSubtree;
        private bool changeSubtree;

        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Height = 1;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }
        }

        public Node Root { get; private set; }

        public bool Contains(T element)
        {
            return this.Contains(element, this.Root);
        }

        private bool Contains(T element, Node node)
        {
            bool result = false;

            if (node == null)
            {
                return false;
            }

            if (node.Value.Equals(element))
            {
                return true;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                result = this.Contains(element, node.Left);
            }
            else if (node.Value.CompareTo(element) < 0)
            {
                result = this.Contains(element, node.Right);
            }

            return result;
        }

        public void Insert(T element)
        {
            this.Root = this.Insert(element, this.Root);
        }

        public void Delete(T element)
        {
            if (this.Root != null)
            {
                Node parent = this.Root;

                if (this.Root.Value.Equals(element))
                {

                    if (this.Root.Right != null)
                    {
                        Node newRoot = this.GetSmallestElementFromRight(this.Root.Right, parent);
                        newRoot.Left = this.Root.Left;
                        if (newRoot.Value.CompareTo(this.Root.Right.Value) < 0)
                        {
                            if (this.changeSubtree)
                            {
                                this.changeSubtree = false;
                                this.Root = this.ChangeSubtree(this.Root);
                            }
                            newRoot.Right = this.Root.Right;
                        }
                        this.Root = newRoot;
                        this.Root.Height = 1 + Math.Max(this.GetHeight(this.Root.Left), this.GetHeight(this.Root.Right));
                    }
                    else if (this.Root.Left != null)
                    {
                        Node newRoot = this.Root.Left;
                        this.Root = newRoot;
                        this.Root.Height = 1 + Math.Max(this.GetHeight(this.Root.Left), this.GetHeight(this.Root.Right));
                    }
                    else
                    {
                        this.Root = null;
                        return;
                    }
                }
                else if (this.Root.Value.CompareTo(element) > 0)
                {
                    this.Delete(element, this.Root.Left, parent);
                }
                else if (this.Root.Value.CompareTo(element) < 0)
                {
                    this.Delete(element, this.Root.Right, parent);                    
                }

                int balance = this.GetHeight(this.Root.Left) - this.GetHeight(this.Root.Right);
                this.Root = this.RebalanceSubtree(this.Root, balance);

                this.Root.Height = 1 + Math.Max(this.GetHeight(this.Root.Left), this.GetHeight(this.Root.Right));
            }
        }

        public void DeleteMin()
        {
            if (this.Root != null)
            {
                if (this.Root.Left == null)
                {
                    this.Root = this.Root.Right;
                    if (this.Root != null)
                    {
                        this.Root.Height = this.GetHeight(this.Root);
                        return;
                    }
                }
                else
                {
                    Node parent = this.Root;
                    DeleteMin(this.Root, parent);
                }
            }
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.Root);
        }

        private Node ChangeSubtree(Node node)
        {
            if (node.Left.Value.Equals(this.oldSubtree.Value))
            {
                node.Left = this.newSubtree;

                return node;
            }
            else if (node.Right.Value.Equals(this.oldSubtree.Value))
            {
                node.Right = this.newSubtree;

                return node;
            }

            if (node.Value.CompareTo(this.oldSubtree.Value) > 0)
            {
                node.Left = this.ChangeSubtree(node.Left);
            }
            else if (node.Value.CompareTo(this.oldSubtree.Value) < 0)
            {
                node.Right = this.ChangeSubtree(node.Right);
            }

            return node;
        }

        private void Delete(T element, Node node, Node parent)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value.Equals(element))
            {
                if (node.Left != null && node.Right != null)
                {
                    Node childOfDeletedNode = node.Right;
                    childOfDeletedNode.Left = node.Left;
                    childOfDeletedNode.Height = 1 + Math.Max(this.GetHeight(childOfDeletedNode.Left), this.GetHeight(childOfDeletedNode.Right));

                    if (parent.Value.CompareTo(node.Value) < 0)
                    {
                        parent.Right = childOfDeletedNode;
                    }
                    else
                    {
                        parent.Left = childOfDeletedNode;
                    }
                }
                else if (node.Left == null && node.Right != null)
                {
                    Node childOfDeletedNode = node.Right;
                    childOfDeletedNode.Height = 1 + Math.Max(this.GetHeight(childOfDeletedNode.Left), this.GetHeight(childOfDeletedNode.Right));

                    if (parent.Value.CompareTo(node.Value) < 0)
                    {
                        parent.Right = childOfDeletedNode;
                    }
                    else
                    {
                        parent.Left = childOfDeletedNode;
                    }
                }
                else if (node.Left != null && node.Right == null)
                {
                    Node childOfDeletedNode = node.Left;
                    childOfDeletedNode.Height = 1 + Math.Max(this.GetHeight(childOfDeletedNode.Left), this.GetHeight(childOfDeletedNode.Right));

                    if (parent.Value.CompareTo(node.Value) < 0)
                    {
                        parent.Right = childOfDeletedNode;
                    }
                    else
                    {
                        parent.Left = childOfDeletedNode;
                    }
                }
                else
                {
                    if (parent.Value.CompareTo(node.Value) < 0)
                    {
                        parent.Right = null;
                    }
                    else
                    {
                        parent.Left = null;
                    }
                }


                int balanceSubtree = this.GetHeight(parent.Left) - this.GetHeight(parent.Right);

                parent = this.RebalanceSubtree(parent, balanceSubtree);

                parent.Height = 1 + Math.Max(this.GetHeight(parent.Left), this.GetHeight(parent.Right));
            }

            if (node.Value.CompareTo(element) > 0)
            {
                parent = node;
                this.Delete(element, node.Left, parent);
            }
            else if (node.Value.CompareTo(element) < 0)
            {
                parent = node;
                this.Delete(element, node.Right, parent);
            }

            int balance = this.GetHeight(node.Left) - this.GetHeight(node.Right);

            node = this.RebalanceSubtree(node, balance);

            node.Height = 1 + Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right));
        }

        private Node GetSmallestElementFromRight(Node node, Node parent)
        {
            Node newRoot = null;
            if (node.Left == null)
            {
                newRoot = node;
                //tuk trqbvada ima balace
                if (!parent.Value.Equals(this.Root.Value))
                {
                    parent.Left = newRoot.Right;
                    this.oldSubtree = parent;

                    int balance = this.GetHeight(parent.Left) - this.GetHeight(parent.Right);

                    if (balance < -1 || 1 < balance)
                    {
                        parent = this.RebalanceSubtree(parent, balance);
                        this.newSubtree = parent;
                        this.changeSubtree = true;
                    }

                    parent.Height = 1 + Math.Max(this.GetHeight(parent.Left), this.GetHeight(parent.Right));
                }

                return newRoot;
            }

            parent = node;
            newRoot = this.GetSmallestElementFromRight(node.Left, parent);

            return newRoot;
        }

        private Node RebalanceSubtree(Node node, int balance)
        {
            if (balance < -1)
            {
                int childBalance = this.GetHeight(node?.Right?.Left) - this.GetHeight(node?.Right?.Right);
                if (0 < childBalance)
                {
                    node.Right = this.RotateRight(node.Right);
                }

                node = this.RotateLeft(node);
            }
            else if (1 < balance)
            {
                int childBalance = this.GetHeight(node?.Left?.Left) - this.GetHeight(node?.Left?.Right);
                if (childBalance < 0)
                {
                    node.Left = this.RotateLeft(node.Left);
                }

                node = this.RotateRight(node);
            }

            return node;
        }

        
        private void DeleteMin(Node node, Node parent)
        {

            if (node.Left == null)
            {
                parent.Left = node.Right;

                return;
            }

            parent = node;
            this.DeleteMin(node.Left, parent);

            node.Height = 1 + Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right));

            return;
        }


        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                return new Node(element);
            }

            if (node.Value.CompareTo(element) > 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (node.Value.CompareTo(element) < 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            int balance = this.GetHeight(node.Left) - this.GetHeight(node.Right);

            node = this.RebalanceSubtree(node, balance);

            node.Height = 1 + Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right));

            return node;
        }

        private Node RotateRight(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            node.Height = 1 + Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right));

            return temp;
        }

        private Node RotateLeft(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            node.Height = 1 + Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right));

            return temp;
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);
            action.Invoke(node.Value);
            this.EachInOrder(action, node.Right);
        }

        private int GetHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }
    }
}
