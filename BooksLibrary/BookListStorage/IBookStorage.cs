namespace BooksLibrary.BookStorage
{
    using System.Collections.Generic;

    /// <summary>
    /// The interface describing the interaction with the repository.
    /// </summary>
    public interface IBookStorage
    {
        /// <summary>
        /// Returns all books from the repository.
        /// </summary>
        /// <exception cref="BookStorageException">
        /// It is thrown in the event of a storage error.
        /// </exception>
        /// <returns>
        /// All books from the repository.
        /// </returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Writes books to the repository.
        /// </summary>
        /// <param name="books">
        /// Books for writing.
        /// </param>
        /// <exception cref="BookStorageException">
        /// It is thrown in the event of a storage error.
        /// </exception>
        void SetBooks(IEnumerable<Book> books);
    }
}
