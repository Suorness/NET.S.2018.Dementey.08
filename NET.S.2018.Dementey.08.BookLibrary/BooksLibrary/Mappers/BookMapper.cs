namespace BookLibrary.Mappers
{
    using BookLibrary.Models;
    using BookStorage;   

    internal static class BookMapper
    {
        public static Book ToBook(this BookDal bookDal)
        {
            return new Book
            {
                Isbn = bookDal.Isbn,
                Author = bookDal.Author,
                Year = bookDal.Year,
                Cost = bookDal.Cost,
                NumbersOfPage = bookDal.NumbersOfPage,
                PublishingHouse = bookDal.PublishingHouse,
                Title = bookDal.Title
            };
        }

        public static BookDal ToDalBook(this Book book)
        {
            return new BookDal
            {
                Isbn = book.Isbn,
                Author = book.Author,
                Year = book.Year,
                Cost = book.Cost,
                NumbersOfPage = book.NumbersOfPage,
                PublishingHouse = book.PublishingHouse,
                Title = book.Title
            };
        }
    }
}
