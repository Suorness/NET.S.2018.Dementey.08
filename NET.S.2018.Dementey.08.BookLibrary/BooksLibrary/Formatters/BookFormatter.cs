namespace BooksLibrary.Formatters
{
    using System;
    using System.Globalization;
    using BookLibrary.Models;

    public class BookFormatter : ICustomFormatter, IFormatProvider
    {
        public enum OutputFormat
        {
            AC,
            TN
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                return null;
            }

            var book = arg as Book;

            if (ReferenceEquals(book, null))
            {
                return null;
            }

            if (ReferenceEquals(formatProvider, null))
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.Trim().ToUpper())
            {
                case nameof(OutputFormat.AC):
                    return $"{book.Author}, {string.Format(formatProvider, "{0:C}", book.Cost)}";
                case nameof(OutputFormat.TN):
                    return $"{book.Title}, {book.NumbersOfPage}";
                default:
                    throw new FormatException($"Unknown format - {format}");
            }
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
