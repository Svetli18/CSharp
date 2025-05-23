﻿namespace IteratorsAndComparators
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            int result = x.Tytle.CompareTo(y.Tytle);

            if (result == 0)
            {
                result = y.Year.CompareTo(x.Year);
            }

            return result;
        }
    }
}
