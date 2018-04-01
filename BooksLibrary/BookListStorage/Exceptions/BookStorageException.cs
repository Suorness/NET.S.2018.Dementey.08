namespace BooksLibrary.BookListStorage.Exceptions
{
    using System;
    /// <summary>
    /// The exception class is thrown when there is a problem with the storage.
    /// </summary>
    public class BookStorageException: Exception
    {
        public BookStorageException()
        {
        }

        public BookStorageException(string message) : base(message)
        {
        }

        public BookStorageException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
