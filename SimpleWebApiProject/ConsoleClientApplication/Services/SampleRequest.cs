using ConsoleClientApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleClientApplication.Services
{
    class SampleRequest
    {
        private readonly UrlService _urlService;
        private readonly BookChapterClientService _client;

        public SampleRequest(
            UrlService urlService, 
            BookChapterClientService client
            )
        {
            _urlService = urlService;
            _client = client;
        }

        public async Task ReadChaptersAsync()
        {
            Console.WriteLine(nameof(ReadChaptersAsync));
            IEnumerable<BookChapter> chapters = await _client.GetAllAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi));
            foreach (BookChapter chapter in chapters)
            {
                Console.WriteLine(chapter.Title);
            }
            Console.WriteLine();
        }

        public async Task ReadChapterAsync()
        {
            Console.WriteLine(nameof(ReadChapterAsync));
            var chapters = await _client.GetAllAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi));
            string id = chapters.First().Id.ToString(); ;
            BookChapter chapter = await _client.GetAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi, id));
            Console.WriteLine($"{chapter.Number} {chapter.Title}");
            Console.WriteLine();
        }

        public async Task ReadNotExistingChapterAsync()
        {
            Console.WriteLine(nameof(ReadNotExistingChapterAsync));
            string requestedIdentifier = Guid.NewGuid().ToString();
            try
            {
                BookChapter chapter = await _client.GetAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi, requestedIdentifier.ToString()));
                Console.WriteLine($"{chapter.Number} {chapter.Title}");
            }
            catch (HttpRequestException ex) when (ex.Message.Contains("404"))
            {
                Console.WriteLine($"book chapter with the identifier {requestedIdentifier} not found");
            }
            Console.WriteLine();
        }

        public async Task ReadXmlAsync()
        {
            Console.WriteLine(nameof(ReadXmlAsync));
            XElement chapters = await _client.GetAllXmlAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi));
            Console.WriteLine(chapters);
            Console.WriteLine();
        }

        public async Task AddChapterAsync()
        {
            Console.WriteLine(nameof(AddChapterAsync));
            BookChapter chapter = new BookChapter
            {
                Number = 34,
                Title = "ASP.NET Core Web API",
                Pages = 35
            };
            chapter = await _client.PostAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi), chapter);
            Console.WriteLine($"added chapter {chapter.Title} with id {chapter.Id}");
            Console.WriteLine();
        }

        public async Task UpdateChapterAsync()
        {
            Console.WriteLine(nameof(UpdateChapterAsync));
            var chapters = await _client.GetAllAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi));
            var chapter = chapters.SingleOrDefault(c => c.Title == ".NET Application Architectures");
            if (chapter != null)
            {
                chapter.Title = ".NET Applications and Tools";
                await _client.PutAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi, chapter.Id.ToString()), chapter);
                Console.WriteLine($"updated chapter {chapter.Title}");
            }
            Console.WriteLine();
        }

        public async Task RemoveChapterAsync()
        {
            Console.WriteLine(nameof(RemoveChapterAsync));
            var chapters = await _client.GetAllAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi));
            var chapter = chapters.SingleOrDefault(c => c.Title == "Windows Communication Foundation");
            if (chapter != null)
            {
                await _client.DeleteAsync(Path.Combine(_urlService.BaseAddress, _urlService.BooksApi, chapter.Id.ToString()));
                Console.WriteLine($"removed chapter {chapter.Title}");
            }
            Console.WriteLine();
        }
    }
}
