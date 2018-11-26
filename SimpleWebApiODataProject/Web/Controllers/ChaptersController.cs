using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web.Context;
using Web.Models;

namespace Web.Controllers
{
    public class ChaptersController : ODataController
    {
        private readonly ApplicationContext _applicationContext;

        public ChaptersController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<BookChapter> Get(ODataQueryOptions options)
        {
            ODataValidationSettings settings = new ODataValidationSettings()
            {
                MaxExpansionDepth = 4
            };
            options.Validate(settings);
            return _applicationContext.Chapters.Include(bc => bc.Book);
        }

        [EnableQuery]
        public SingleResult<BookChapter> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_applicationContext.Chapters.Where(bc => bc.Id == key));
        }
    }
}
