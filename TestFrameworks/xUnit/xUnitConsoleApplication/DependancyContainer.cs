using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using xUnitConsoleApplication.ApllicationContexts;
using xUnitConsoleApplication.Services;

namespace xUnitConsoleApplication
{
    public static class DependancyContainer
    {
        public static string connectionString = @"Data Source =DESKTOP-KNIMMN0; Initial Catalog = ForPractise; Integrated Security = true; MultipleActiveResultSets=true;";

        public static ServiceProvider RegisterDependancy()
        {
            var container = new ServiceCollection();
            container.AddDbContext<BooksContext>(options => options.UseSqlServer(connectionString));
            container.AddTransient<IBookService, BookService>();
            return container.BuildServiceProvider();
        }
    }
}
