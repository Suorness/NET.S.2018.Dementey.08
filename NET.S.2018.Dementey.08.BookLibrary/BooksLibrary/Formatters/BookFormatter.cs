namespace BooksLibrary.Formatters
{
    using System;
    using System.Globalization;
    using BookLibrary.Models;

    /// <summary>
    /// Class with custom formatting book <see cref="Book"/>
    /// </summary>
    public class BookFormatter : ICustomFormatter, IFormatProvider
    {
        /// <summary>
        /// Enumeration with available formats.
        /// </summary>
        public enum OutputFormat
        {
            AC,
            TN
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation
        /// </summary>
        /// <param name="format"> A format string containing formatting specifications.</param>
        /// <param name="arg"> An object to format.</param>
        /// <param name="formatProvider"> An object that supplies format information about the current instance.</param>
        /// <returns>
        /// The string representation of the value of arg, formatted as specified by format
        /// and formatProvider.
        /// </returns>
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

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        ///  An instance of the object specified by formatType, if the System.IFormatProvider
        ///  implementation can supply that type of object; otherwise, null.
        /// </returns>
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
