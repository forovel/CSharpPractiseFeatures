using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web.Context;
using Web.Models;

namespace Web.Controllers
{
    public class BooksController : ODataController
    {
        private readonly ApplicationContext _applicationContext;

        public BooksController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<Book> Get(ODataQueryOptions options)
        {
            ODataValidationSettings settings = new ODataValidationSettings()
            {
                MaxExpansionDepth = 4
            };
            options.Validate(settings);
            return _applicationContext.Books.Include(b => b.Chapters);
        }

        [EnableQuery]
        public SingleResult<Book> Get([FromODataUri] int key) //Id in get odata method must be named "key"
        {
            return SingleResult.Create(_applicationContext.Books.Where(b => b.Id == key));
        }
    }
}
