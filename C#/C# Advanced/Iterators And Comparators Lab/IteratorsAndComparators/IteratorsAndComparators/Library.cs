namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : BookComparator, IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[]? books)
        {
            this.books = new SortedSet<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.books.GetEnumerator();

    }
}
