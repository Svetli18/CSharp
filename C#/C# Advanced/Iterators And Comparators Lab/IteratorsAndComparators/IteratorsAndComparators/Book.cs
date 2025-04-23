namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class Book : IComparable<Book>
    {
        //private string title;
        //private int year;
        //private string[] authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Tytle = title;
            this.Year = year;
            this.Authors = authors;
        }

        public string Tytle { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyList<string> Authors { get; private set; }

        public int CompareTo([AllowNull] Book other)
        {
            int result = this.Year.CompareTo(other.Year);
            if (result == 0)
            {
                result = this.Tytle.CompareTo(other.Tytle);
            }

            return result;

        }

        public override string ToString()
        {
            return $"{this.Tytle} - {this.Year}";
        }
    }
}
