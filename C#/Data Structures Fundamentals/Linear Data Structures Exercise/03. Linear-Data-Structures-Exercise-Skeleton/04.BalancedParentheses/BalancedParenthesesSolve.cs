namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        private Stack<char> _stack;

        public BalancedParenthesesSolve()
        {
            _stack = new Stack<char>();
        }

        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 != 0)
            {
                return false;
            }

            bool isBalanced = true;

            char[] chars = parentheses.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {

                if (chars[i] == '(' || chars[i] == '{' || chars[i] == '[')
                {
                    this._stack.Push(chars[i]);
                    continue;
                }

                char open = this._stack.Pop();
                char close = chars[i];

                if (open == '(' && close == ')' ||
                    open == '{' && close == '}' || 
                    open == '[' && close == ']')
                {
                    continue;
                }
                else
                {
                    isBalanced = false;
                    break;                                       
                }
            }

            return isBalanced;
        }
    }
}
