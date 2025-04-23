namespace InheritanceDemos
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddRange(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                Push(item);
            }
        }
    
}
