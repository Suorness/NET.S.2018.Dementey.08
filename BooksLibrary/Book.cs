namespace BooksLibrary
{
    using System;

    public class Book: IEquatable<Book>, IComparable, IComparable<Book>
    {
        #region private field
        private string _isbn;
        private string _author;
        private string _title;
        private string _publishingHouse;
        private int _year;
        private int _numbersOfPage;
        private decimal _cost;
        #endregion private field

        public Book(string isbn, string author, string title, string publishingHouse, int year, int numbersOfPage, decimal cost)
        {
            _isbn = isbn;
            _author = author;
            _title = title;
            _publishingHouse = publishingHouse;
            _year = year;
            _numbersOfPage = numbersOfPage;
            _cost = cost;
        }

        #region property
        public string Isbn { get => _isbn; set => _isbn = value; }

        public string Author { get => _author; set => _author = value; }

        public string Title { get => _title; set => _title = value; }

        public string PublishingHouse { get => _publishingHouse; set => _publishingHouse = value; }

        public int Year { get => _year; set => _year = value; }

        public int NumbersOfPage { get => _numbersOfPage; set => _numbersOfPage = value; }

        public decimal Cost { get => _cost; set => _cost = value; }

        #endregion property


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

        public static bool operator != (Book bookA, Book bookB)
        {
            return !(bookA == bookB);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            //TODO: implement this
            return base.ToString();
        }

        private bool IsEqual(Book book)
        {
            return Isbn == book.Isbn &&
                   Author == book.Author &&
                   Title == book.Title &&
                   PublishingHouse == book.PublishingHouse &&
                   Year == book.Year &&
                   NumbersOfPage == book.NumbersOfPage &&
                   Cost == book.Cost;
        }

        private int Compare(Book book)
        {
            return string.Compare(Isbn, book.Isbn);
        }

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
                throw new ArgumentException(nameof(obj));
            }

            return Compare(obj as Book);
        }

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
    }
}
