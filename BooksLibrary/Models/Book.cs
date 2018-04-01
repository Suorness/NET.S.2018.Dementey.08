namespace BooksLibrary
{
    using System;

    /// <summary>
    /// A class describing the book.
    /// </summary>
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        #region private field
        private string _isbn;
        private string _author;
        private string _title;
        private string _publishingHouse;
        private string _year;
        private int _numbersOfPage;
        private decimal _cost;
        #endregion private field

        public Book(
            string isbn,
            string author,
            string title,
            string publishingHouse,
            string year,
            int numbersOfPage,
            decimal cost)
        {
            _isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
            _author = author ?? throw new ArgumentNullException(nameof(author));
            _title = title ?? throw new ArgumentNullException(nameof(title));
            _publishingHouse = publishingHouse ?? throw new ArgumentNullException(nameof(publishingHouse));
            _year = year ?? throw new ArgumentNullException(nameof(year));
            _numbersOfPage = numbersOfPage;
            _cost = cost;
        }

        public Book(Book book) : this(book.Isbn, book.Author, book.Title, book.PublishingHouse, book.Year, book.NumbersOfPage, book.Cost)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }
        }

        #region property

        /// <summary>
        /// International Standard Book Number - ISBN.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null 
        /// or an empty string or string consisting of delimiter characters.
        /// </exception>
        public string Isbn
        {
            get
            {
                return _isbn;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Parameter is null or an empty string or string consisting of delimiter characters.");
                }

                _isbn = value;
            }
        }

        /// <summary>
        /// Вook author.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null 
        /// or an empty string or string consisting of delimiter characters.
        /// </exception>
        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Parameter is null or an empty string or string consisting of delimiter characters.");
                }

                _author = value;
            }
        }

        /// <summary>
        /// Title of the book.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null 
        /// or an empty string or string consisting of delimiter characters.
        /// </exception>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Parameter is null or an empty string or string consisting of delimiter characters.");
                }

                _title = value;
            }
        }

        /// <summary>
        /// Publishing house.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null 
        /// or an empty string or string consisting of delimiter characters.
        /// </exception>
        public string PublishingHouse
        {
            get
            {
                return _publishingHouse;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Parameter is null or an empty string or string consisting of delimiter characters.");
                }

                _publishingHouse = value;
            }
        }

        /// <summary>
        /// The year of publishing.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null 
        /// or an empty string or string consisting of delimiter characters.
        /// </exception>
        public string Year
        {
            get
            {
                return _year;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Parameter is null or an empty string or string consisting of delimiter characters.");
                }

                _year = value;
            }
        }

        /// <summary>
        /// Number of pages.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the <paramref name="value"/> argument is less than zero.
        /// </exception>
        public int NumbersOfPage
        {
            get
            {
                return _numbersOfPage;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"The value of the argument{nameof(value)} must be greater than zero.");
                }

                _numbersOfPage = value;
            }
        }

        /// <summary>
        /// Cost of the book.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the <paramref name="value"/> argument is less than zero.
        /// </exception>
        public decimal Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"The value of the argument{nameof(value)} must be greater than zero.");
                }

                _cost = value;
            }
        }

        #endregion property

        /// <summary>
        /// Comparison of two operands for equality.
        /// </summary>
        /// <param name="bookA">The first operand.</param>
        /// <param name="bookB">The second operand.</param>
        /// <returns>
        /// True if equivalents, false otherwise.
        /// </returns>
        public static bool operator ==(Book bookA, Book bookB)
        {
            if (ReferenceEquals(bookA, bookB))
            {
                return true;
            }

            if (ReferenceEquals(null, bookA))
            {
                return false;
            }

            return bookA.Equals(bookB);
        }

        /// <summary>
        /// Comparison of two operands by inequality.
        /// </summary>
        /// <param name="bookA">The first operand.</param>
        /// <param name="bookB">The second operand.</param>
        /// <returns>
        /// True if inequality, false otherwise.
        /// </returns>
        public static bool operator !=(Book bookA, Book bookB)
        {
            return !(bookA == bookB);
        }

        /// <summary>
        /// Verifies for equality this copy of the book with <paramref name="value"/>.
        /// </summary>
        /// <param name="value"> Value for comparison</param>
        /// <returns>
        /// True if objects are equivalent, false otherwise.
        /// </returns>
        public override bool Equals(object value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }

            if (ReferenceEquals(this, value))
            {
                return true;
            }

            if (value.GetType() != GetType())
            {
                return false;
            }

            return IsEqual(value as Book);
        }

        /// <summary>
        /// Verifies for equality this copy of the book with <paramref name="value"/>.
        /// </summary>
        /// <param name="value"> Value for comparison</param>
        /// <returns>
        /// True if objects are equivalent, false otherwise.
        /// </returns>
        public bool Equals(Book book)
        {
            if (ReferenceEquals(null, book))
            {
                return false;
            }

            if (ReferenceEquals(this, book))
            {
                return true;
            }

            return IsEqual(book);
        }

        /// <summary>
        /// Returns the hash code value.
        /// </summary>
        /// <returns>
        /// Hash code value.
        /// </returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Returns the string representation of an object.
        /// </summary>
        /// <returns>
        /// String representation of an book.
        /// </returns>
        public override string ToString()
        {
            return Isbn;
        }

        /// <summary>
        /// A comparison of the two books is case-sensitive.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <exception cref="ArgumentException">
        /// <param name="obj"> is not the same type as this instance.
        /// </exception>
        /// <returns>
        /// Less than zero. This instance precedes other in the sort order. 
        /// Zero. This instance occurs in the same position in the
        /// sort order as other.
        /// Greater than zero. This instance follows other in the sort order.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            if (obj.GetType() != GetType())
            {
                throw new ArgumentException($"{nameof(obj)} is not the same type as this instance.", nameof(obj));
            }

            return Compare(obj as Book);
        }

        /// <summary>
        /// A comparison of the two books is case-sensitive.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        /// <returns>
        /// Less than zero. This instance precedes other in the sort order. 
        /// Zero. This instance occurs in the same position in the
        /// sort order as other.
        /// Greater than zero. This instance follows other in the sort order.
        /// </returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            return Compare(other);
        }

        private bool IsEqual(Book book)
        {
            return string.Equals(Isbn, book.Isbn, StringComparison.Ordinal);
        }

        private int Compare(Book book)
        {
            return string.Compare(Isbn, book.Isbn, ignoreCase: false);
        }
    }
}
