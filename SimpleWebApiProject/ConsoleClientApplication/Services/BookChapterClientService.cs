using ConsoleClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientApplication.Services
{
    public class BookChapterClientService : HttpClientService<BookChapter>
    {
        public BookChapterClientService(UrlService urlService) : base(urlService)
        {

        }

        public override async Task<IEnumerable<BookChapter>> GetAllAsync(string requestUri)
        {
            var chapters = await base.GetAllAsync(requestUri);
            return chapters.OrderBy(c => c.Number);
        }
    }
}
