﻿namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);
            List<Book> books = new List<Book>() { bookOne, bookTwo, bookThree };
            books.Sort(new BookComparator());
            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book.Tytle);
            }
            
        }
    }
}
