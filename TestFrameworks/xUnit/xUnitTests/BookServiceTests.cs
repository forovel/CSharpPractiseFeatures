using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using xUnitConsoleApplication.ApllicationContexts;
using xUnitConsoleApplication.Models;
using xUnitConsoleApplication.Services;

namespace xUnitTests
{
    public class BookServiceTests
    {
        private BooksContext _dbContext;

        public BookServiceTests()
        {
            InitContext();
        }

        private void InitContext()
        {
            var builder = new DbContextOptionsBuilder<BooksContext>().UseInMemoryDatabase("BooksTestDb");
            _dbContext = new BooksContext(builder.Options);
        }

        [Fact]
        public void AddRecord()
        {
            var addBook = _dbContext.Books.Add(new Book
            {
                Publisher = "test1",
                Title = "test2"
            });

            var result = _dbContext.SaveChanges();

            Assert.Equal(1, result);
        }

        [Fact]
        public void FindRecords()
        {
            var bookService = new BookService(_dbContext);
            var result = bookService.GetListBooks().ToList();

            Assert.Single(result);
        }
    }
}
