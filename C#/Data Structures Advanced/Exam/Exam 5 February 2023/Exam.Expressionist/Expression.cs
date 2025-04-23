namespace Exam.Expressionist
{
    public class Expression
    {
        public Expression()
        {

        }

        public Expression(string id, string value, ExpressionType type, Expression leftChild, Expression rightChild)
        {
            this.Id = id;
            this.Value = value;
            this.Type = type;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            this.Count = 1;
        }

        public string Id { get; set; }

        public string Value { get; set; }

        public int Count { get; set; }
        public ExpressionType Type { get; set; }

        public Expression Parent { get; set; }

        public Expression LeftChild { get; set; }

        public Expression RightChild { get; set; }

        public override bool Equals(object obj)
        {
            Expression other = obj as Expression;

            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
