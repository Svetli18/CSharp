namespace Exam.Expressionist
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Expressionist expressionist = new Expressionist();

            Expression expression = new Expression("Cvetomir", "+", ExpressionType.Operator, new Expression("Moni", "16", ExpressionType.Value, new Expression("Iskra", "6", ExpressionType.Value, null , null), new Expression("Sara", "8", ExpressionType.Value, null, null)), new Expression("Svetli", "18", ExpressionType.Value, new Expression("Zoicheto", "21", ExpressionType.Value, null, null), new Expression("Goldo", "5", ExpressionType.Value, null, null)));

            expressionist.AddExpression(expression);

            expressionist.AddExpression(new Expression("Maxo", "+", ExpressionType.Operator, new Expression("Cvetna", "8", ExpressionType.Value, null, null), new Expression("Gradina", "8", ExpressionType.Value, null, null)), "Iskra");

            Console.WriteLine(expressionist.Evaluate());
            ;
        }
    }
}
