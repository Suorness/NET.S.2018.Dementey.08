namespace BooksLibrary.BookService
{
    using System;

    /// <summary>
    /// The exception class is thrown when there is a problem with the service.
    /// </summary>
    public class BookServiceException : Exception
    {
        public BookServiceException()
        {
        }

        public BookServiceException(string message) : base(message)
        {
        }

        public BookServiceException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
