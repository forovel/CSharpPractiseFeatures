using System.Collections.Generic;
using System.Linq;
using xUnitConsoleApplication.Models;

namespace xUnitConsoleApplication.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetTopTenBooks(string publisher);
        IQueryable<Book> GetListBooks();
    }
}
