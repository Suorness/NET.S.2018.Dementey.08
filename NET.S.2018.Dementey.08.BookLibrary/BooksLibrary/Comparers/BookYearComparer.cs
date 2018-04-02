namespace BooksLibrary.Comparers
{
    using System.Collections.Generic;
    using BookLibrary.Models;

    /// <summary>
    /// Comparer from sort by Year.
    /// </summary>
    public class BookYearComparer : IComparer<Book>
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

            return string.Compare(x.Year, y.Year, ignoreCase: false);
        }
    }
}