using System;
using System.Collections.Generic;
using System.Linq;
using xUnitConsoleApplication.ApllicationContexts;
using xUnitConsoleApplication.Models;

namespace xUnitConsoleApplication.Services
{
    public class BookService : IBookService
    {
        private readonly BooksContext _dbContext;

        public BookService(BooksContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetTopTenBooks(string publisher)
        {
            if (publisher == null) throw new ArgumentNullException(nameof(publisher));

            return _dbContext.Books
                .Where(b => b.Publisher == publisher)
                .Take(10)
                .ToList();
        }

        public IQueryable<Book> GetListBooks()
        {
            return _dbContext.Books;
        }
    }
}
