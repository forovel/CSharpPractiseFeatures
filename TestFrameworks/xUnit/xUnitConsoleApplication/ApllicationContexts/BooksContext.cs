using Microsoft.EntityFrameworkCore;
using xUnitConsoleApplication.Models;

namespace xUnitConsoleApplication.ApllicationContexts
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
