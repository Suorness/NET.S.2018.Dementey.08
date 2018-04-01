﻿namespace BooksLibrary.BookService
{
    using System;
    using System.Collections.Generic;
    using BooksLibrary.BookListStorage;
    using BooksLibrary.BookListStorage.Exceptions;

    /// <summary>
    /// The class that implements the interface <see cref="IBookService"/>
    /// </summary>
    public class BookListService : IBookService
    {
        #region private field
        private IBookStorage _bookStorage;
        private List<Book> _books = new List<Book>();
        #endregion private field

        /// <summary>
        /// Creation of a service instance.
        /// </summary>
        /// <param name="bookStorage">Book storage.</param>
        /// <exception cref="ArgumentNullException">
        /// The exception that is thrown when a null argument <paramref name="bookStorage"/> is passed.
        /// </exception>
        public BookListService(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage ?? throw new ArgumentNullException(nameof(bookStorage));

            try
            {
                _books.AddRange(_bookStorage.GetBooks());
            }
            catch (BookStorageException e)
            {
                throw new BookServiceException("An error occurred while reading from the repository.", e);
            }
        }

        /// <summary>
        /// Add <paramref name="book"/> to the storage.
        /// </summary>
        /// <param name="book">
        /// The book to add to the repository.
        /// </param>
        /// <exception cref="BookServiceException">
        /// It is thrown out in case of service problems.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception that is thrown when a null argument <paramref name="book"/> is passed.
        /// </exception>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            bool presenceInTheRepository = false;

            foreach(var bookItem in _books)
            {
                if (bookItem == book)
                {
                    presenceInTheRepository = true;
                    break;
                }
            }

            if (!presenceInTheRepository)
            {
                _books.Add(book);
                try
                {
                    _bookStorage.SetBooks(_books);
                }
                catch(BookStorageException e)
                {
                    _books.Remove(book);
                    throw new BookServiceException("An error occurred while writing to the repository.", e);
                }
            }
            else
            {
                throw new BookServiceException("The book is already in the repository.");
            }
        }

        /// <summary>
        /// Finding a book in the repository by <paramref name="isbn"/> ISBN.
        /// </summary>
        /// <param name="isbn"> ISBN book.</param>
        /// <exception cref="ArgumentNullException">
        /// The exception that is thrown when a null argument <paramref name="isbn"/> is passed.
        /// </exception>
        /// <exception cref="BookServiceException">
        /// It is thrown out in case of service problems.
        /// </exception>
        /// <returns>
        /// Found a book.
        /// if it's not there null
        /// </returns>
        public Book FindBook(string isbn)
        {
            Book resultBook = null;

            if (isbn == null)
            {
                throw new ArgumentNullException(nameof(isbn));
            }

            foreach(var book in _books)
            {
                if (book.Isbn == isbn)
                {
                    resultBook = new Book(book);
                    break;
                }
            }

            return resultBook;

        }

        /// <summary>
        /// Returns all books from the repository.
        /// </summary>
        /// <returns>
        /// Books from the repository.
        /// </returns>
        public IEnumerable<Book> GetBooks()
        {
            return _books.ToArray();
        }

        /// <summary>
        /// A method that removes a book <paramref name="book"/> from the repository.
        /// </summary>
        /// <param name="book">
        /// The book for removal.
        /// </param>
        /// <exception cref="BookServiceException">
        /// It is thrown out in case of service problems.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception that is thrown when a null argument <paramref name="isbn"/> is passed.
        /// </exception>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book,null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (_books.Remove(book))
            {
                try
                {
                    _bookStorage.SetBooks(_books);
                }
                catch(BookStorageException e)
                {
                    _books.Add(book);
                    throw new BookServiceException("An error occurred while writing to the repository.", e);
                }
            }
            else
            {
                throw new BookServiceException("The book for deletion was not found.");
            }
        }

        /// <summary>
        /// Sorting books from the repository using IComparable
        /// </summary>
        /// <returns>
        /// Sorted books.
        /// </returns>
        public IEnumerable<Book> SortBooks()
        {
            var books = new List<Book>(_books);
            books.Sort();
            return books.ToArray();
        }
    }
}
