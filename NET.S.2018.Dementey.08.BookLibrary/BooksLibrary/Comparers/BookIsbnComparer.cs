namespace BooksLibrary.Comparers
{
    using System.Collections.Generic;
    using BookLibrary.Models;

    /// <summary>
    /// Comparer from sort by Isbn.
    /// </summary>
    public class BookIsbnComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (ReferenceEquals(null, y))
            {
                return 1;
            }

            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            return string.Compare(x.Isbn, y.Isbn, ignoreCase: false);
        }
    }
}
