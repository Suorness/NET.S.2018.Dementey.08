﻿namespace ConsoleBooksLibrary
{
    using System;
    using System.Collections.Generic;
    using BookLibrary;
    using BookLibrary.Models;
    using BookStorage;

    public class Program
    {
        private static readonly string FilePath = @"data.bin";

        public static void Main()
        {
            try
            {
                IBookStorage bookRepository = new BookBinaryStorage(FilePath);
                IBookService bookService = new BookListService(bookRepository);

                Console.WriteLine("AddTest");
                Console.WriteLine(new string('-', 80));
                AddTest(bookService);

                Console.WriteLine("FindTest");
                FindTest(bookService);

                Console.WriteLine("DeleteTest");
                DeleteTest(bookService);

                Console.WriteLine("SortTest");
                SortTest(bookService);

                var books = bookService.GetBooks();
                foreach (var book in books)
                {
                    bookService.RemoveBook(book);
                }

                bookService.AddBook(new Book("ISBN7", "Author1", "Title - 5", "PublishHouse 1", "2020", 140, 5m));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static void ShowBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(string.Format($"ISBN: {book.Isbn,20} Title: {book.Title,15} Author: {book.Author}"), book);
            }

            Console.WriteLine(new string('-', 80));
        }

        private static void ShowBooks(params Book[] books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(string.Format($"ISBN: {book.Isbn,20} Title: {book.Title,15} Author: {book.Author}"), book);
            }

            Console.WriteLine(new string('-', 80));
        }

        private static void AddTest(IBookService service)
        {
            var book1 = new Book("ISBN5", "Author1", "Title - 1", "PublishHouse 1", "2020", 10, 2m);
            var book2 = new Book("ISBN4", "Author2", "Title - 2", "PublishHouse 2", "2021", 12, 1m);
            var book3 = new Book("ISBN3", "Author3", "Title - 3", "PublishHouse 3", "2020", 170, 3m);
            var book4 = new Book("ISBN2", "Author1", "Title - 4", "PublishHouse 5", "2020", 120, 2m);
            var book5 = new Book("ISBN1", "Author1", "Title - 5", "PublishHouse 1", "2020", 140, 5m);

            var bookList = new List<Book>() { book1, book2, book3, book4, book5 };

            foreach (var book in bookList)
            {
                service.AddBook(book);
                ShowBooks(service.GetBooks());
            }
        }

        private static void FindTest(IBookService service)
        {
            string isbn3 = "ISBN3";
            string isbn6 = "ISBN6";

            ShowBooks(service.FindBook(isbn3));
            if (service.FindBook(isbn6) == null)
            {
                Console.WriteLine("The book was not found.");
                Console.WriteLine(new string('-', 80));
            }
        }

        private static void DeleteTest(IBookService service)
        {
            string isbn3 = "ISBN3";

            Console.WriteLine("Before");
            ShowBooks(service.GetBooks());

            service.RemoveBook(service.FindBook(isbn3));

            Console.WriteLine("After");
            ShowBooks(service.GetBooks());
        }

        private static void SortTest(IBookService service)
        {
            ShowBooks(service.SortBooks());
        }
    }
}