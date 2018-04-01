namespace BooksLibrary.BookStorage
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// A data warehouse using binary files.
    /// </summary>
    public class BookBinaryStorage : IBookStorage
    {
        private readonly string _filePath;

        /// <summary>
        /// Creation of a service instance.
        /// </summary>
        /// <param name="filePath">The path to the data file.</param>
        /// <exception cref="ArgumentNullException">
        /// The exception that is thrown when a null argument <paramref name="filePath"/> is passed.
        /// </exception>
        public BookBinaryStorage(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>();
            using (FileStream fs = File.OpenWrite(_filePath))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (reader.PeekChar() > -1)
                {
                    books.Add(ReadBook(reader));
                }
            }

            return books;
        }

        public void SetBooks(IEnumerable<Book> books)
        {
            using (FileStream fs = File.Create(_filePath))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                foreach (var book in books)
                {
                    WriteBook(writer, book);
                }
            }
        }

        private void WriteBook(BinaryWriter writer, Book book)
        {
            writer.Write(book.Isbn);
            writer.Write(book.Author);
            writer.Write(book.Title);
            writer.Write(book.PublishingHouse);
            writer.Write(book.Year);
            writer.Write(book.NumbersOfPage);
            writer.Write(book.Cost);
        }

        private Book ReadBook(BinaryReader reader)
        {
            return new Book(
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadInt32(),
                reader.ReadDecimal());
        }
    }
}
