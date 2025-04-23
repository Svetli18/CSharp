namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;

        private int index;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current => this.books[this.index];


        public bool MoveNext()
        {
            if (this.index < this.books.Count - 1)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public void Dispose(){}

        public void Reset() => this.index = 0;

        object IEnumerator.Current => this.Current;
        
    }
}
