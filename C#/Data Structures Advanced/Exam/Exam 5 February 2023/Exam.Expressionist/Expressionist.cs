namespace Exam.Expressionist
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Expressionist : IExpressionist
    {
        Expression root = null;
        Dictionary<string, Expression> byIdParent = new Dictionary<string, Expression>();
        Dictionary<string, Expression> byId = new Dictionary<string, Expression>();

        public void AddExpression(Expression expression)
        {
            if (this.root != null)
            {
                throw new ArgumentException();
            }

            this.root = expression;

            this.AddExpressionDfs(this.root, null);
        }

        private int GetCount(Expression expression)
        {
            if (expression == null)
            {
                return 0;
            }

            return expression.Count;
        }

        private void UpdateParentDFS(Expression parent, Expression node)
        {
            if (node == null)
            {
                return;
            }

            node.Parent = parent;
            parent = node;

            this.UpdateParentDFS(parent, node.LeftChild);
            this.UpdateParentDFS(parent, node.RightChild);

            node.Count = 1 + GetCount(node.LeftChild) + GetCount(node.RightChild);
        }

        private void AddExpressionDfs(Expression node, Expression parent)
        {
            if (node == null)
            {
                return;
            }

            if (!this.byId.ContainsKey(node.Id))
            {
                this.byId[node.Id] = node;
            }

            if (parent != null && parent.LeftChild == null)
            {
                parent.LeftChild = node;
            }
            else if (parent != null && parent.RightChild == null)
            {
                parent.RightChild = node;
            }

            node.Parent = parent;
            parent = node;



            this.AddExpressionDfs(node.LeftChild, parent);
            this.AddExpressionDfs(node.RightChild, parent);

            node.Count = 1 + GetCount(node.LeftChild) + GetCount(node.RightChild);
        }

        public void AddExpression(Expression node, string parentId)

        {
            Expression parent = this.byId[parentId];

            if (parent == null || parent.LeftChild != null && parent.RightChild != null)
            {
                throw new ArgumentException();
            }

            this.AddExpressionDfs(node, parent);
            this.UpdateCount(parent);
        }

        private void UpdateCount(Expression node)
        {
            if (node == null)
            {
                return;
            }

            node.Count = 1 + GetCount(node.LeftChild) + GetCount(node.RightChild);

            this.UpdateCount(node.Parent);

        }

        public bool Contains(Expression expression)
        {
            return this.byId.ContainsKey(expression.Id);
        }

        public int Count()
        {
            return this.root.Count;
        }

        public string Evaluate()
        {

            if (this.root == null)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();

            this.EvaluateResultDFS(this.root, result);

            return result.ToString().Trim();
        }

        private void EvaluateResultDFS(Expression node, StringBuilder result)
        {
            if (node.LeftChild != null) 
            {
                this.EvaluateResultDFS(node.LeftChild, result);
            }

            if (node.Type.Equals(ExpressionType.Operator))
            {
                if (node.LeftChild != null && node.RightChild != null)
                {
                    this.byIdParent[node.Id] = node;
                    result.Append($" ({node.LeftChild.Value} {node.Value} {node.RightChild.Value})");
                }
            }
            else if (node.Type.Equals(ExpressionType.Value) && !this.byIdParent.ContainsKey(node.Parent.Id))
            {
                if (0 < result.Length && result[result.Length - 1].Equals(')'))
                {
                    result.Append($" {node.Value}");
                }
                else
                {
                    if (!(node.Parent != null && node.Parent.Type.Equals(ExpressionType.Operator)) || node.Id.Equals(this.root.Id))
                    {
                        var arr = result.ToString().Split(' ');
                        var toParse = int.TryParse(arr[arr.Length - 1], out int intValue);
                        int sum = toParse ? int.Parse(node.Value) + intValue : int.Parse(node.Value);
                        ;
                        result.Replace(arr[arr.Length - 1], sum.ToString(), result.Length - intValue.ToString().Length, intValue.ToString().Length);
                        //result.Remove(arr.Length - 1, intValue.ToString().Length);
                        ;
                    }
                }
            }

            if (node.RightChild != null)
            {
                this.EvaluateResultDFS(node.RightChild, result);
            }
        }

        public Expression GetExpression(string expressionId)
        {
            if (!this.byId.ContainsKey(expressionId))
            {
                throw new ArgumentException();
            }

            return this.byId[expressionId];
        }

        public void RemoveExpression(string expressionId)
        {
            Expression toRemove = this.GetExpression(expressionId);

            Expression parent = toRemove.Parent;

            this.RemoveExpressionDfs(toRemove);

            if (parent.LeftChild.Id.Equals(toRemove.Id))
            {
                parent.LeftChild = parent.RightChild;
                parent.RightChild = null;
            }
            else if (parent.RightChild.Id.Equals(toRemove.Id))
            {
                parent.RightChild = null;
            }

            this.UpdateCount(parent);
        }

        private void RemoveExpressionDfs(Expression node)
        {

            if (node.LeftChild != null)
            {
                this.RemoveExpressionDfs(node.LeftChild);
                node.LeftChild = node.RightChild;
                node.RightChild = null;
                if (node.LeftChild != null)
                {
                    this.RemoveExpressionDfs(node.LeftChild);
                    node.LeftChild = null;
                }
            }

            this.byId.Remove(node.Id);
            node.Parent = null;

            if (node.RightChild != null)
            {
                this.RemoveExpressionDfs(node.RightChild);
                node.RightChild = null;
            }

            node = null;
        }
    }
}
