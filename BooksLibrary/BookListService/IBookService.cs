namespace BooksLibrary.BookService
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface describing the operation of the service.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Add <paramref name="book"/> to the storage.
        /// </summary>
        /// <param name="book">
        /// The book to add to the repository.
        /// </param>
        /// <exception cref="BookServiceException">
        /// It is thrown out in case of service problems.
        /// </exception>
        void AddBook(Book book);

        /// <summary>
        /// A method that removes a book <paramref name="book"/> from the repository.
        /// </summary>
        /// <param name="book">
        /// The book for removal.
        /// </param>
        /// <exception cref="BookServiceException">
        /// It is thrown out in case of service problems.
        /// </exception>
        void RemoveBook(Book book);

        /// <summary>
        /// Finding a book in the repository by <paramref name="isbn"/> ISBN.
        /// </summary>
        /// <param name="isbn"> ISBN book.</param>
        /// <returns>
        /// Found a book.
        /// if it's not there null
        /// </returns>
        Book FindBook(string isbn);

        /// <summary>
        /// Sorting books from the repository using IComparable
        /// </summary>
        /// <returns>
        /// Sorted books.
        /// </returns>
        IEnumerable<Book> SortBooks();

        /// <summary>
        /// Returns all books from the repository.
        /// </summary>
        /// <returns>
        /// Books from the repository.
        /// </returns>
        /// <exception cref="BookServiceException">
        /// It is thrown out in case of service problems.
        /// </exception>
        IEnumerable<Book> GetBooks();

    }
}
