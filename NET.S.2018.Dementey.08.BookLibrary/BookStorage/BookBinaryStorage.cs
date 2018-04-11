namespace BookStorage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Logger;

    /// <summary>
    /// A data warehouse using binary files.
    /// </summary>
    public class BookBinaryStorage : IBookStorage
    {
        private readonly string _filePath;
        private readonly ILogger _logger;

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
            _logger = LoggerCreater.GetLogger(nameof(BookBinaryStorage));
            _logger.Info("Storage was created");
        }

        public IEnumerable<BookDal> GetBooks()
        {
            var books = new List<BookDal>();
            using (var fs = File.Open(_filePath, FileMode.Open))
            using (var reader = new BinaryReader(fs))
            {
                while (reader.PeekChar() > -1)
                {
                    books.Add(ReadBook(reader));
                }
            }

            return books;
        }

        public void SetBooks(IEnumerable<BookDal> books)
        {
            using (var fs = File.Open(_filePath, FileMode.Create))
            using (var writer = new BinaryWriter(fs))
            {
                foreach (var book in books)
                {
                    WriteBook(writer, book);
                }
            }

            _logger.Info("The books were recorded.");
        }

        private void WriteBook(BinaryWriter writer, BookDal book)
        {
            writer.Write(book.Isbn);
            writer.Write(book.Author);
            writer.Write(book.Title);
            writer.Write(book.PublishingHouse);
            writer.Write(book.Year);
            writer.Write(book.NumbersOfPage);
            writer.Write(book.Cost);
        }

        private BookDal ReadBook(BinaryReader reader)
        {
            return new BookDal
            {
                Isbn = reader.ReadString(),
                Author = reader.ReadString(),
                Title = reader.ReadString(),
                PublishingHouse = reader.ReadString(),
                Year = reader.ReadString(),
                NumbersOfPage = reader.ReadInt32(),
                Cost = reader.ReadDecimal()
            };
        }
    }
}
