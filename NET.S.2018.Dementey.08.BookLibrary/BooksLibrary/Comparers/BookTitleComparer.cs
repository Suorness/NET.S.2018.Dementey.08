namespace BooksLibrary.Comparers
{  
    using System.Collections.Generic;
    using BookLibrary.Models;

    /// <summary>
    /// Comparer from sort by Title.
    /// </summary>
    public class BookTitleComparer : IComparer<Book>
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

            return string.Compare(x.Title, y.Title, ignoreCase: false);
        }
    }
}
