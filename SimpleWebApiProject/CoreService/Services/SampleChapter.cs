using CoreService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Services
{
    public class SampleChapters
    {
        private readonly IBookChaptersService _bookChaptersService;
        public SampleChapters(IBookChaptersService bookChapterService)
        {
            _bookChaptersService = bookChapterService;
        }

        private readonly string[] sampleTitles = new[]
        {
            ".NET Application Architectures",
            "Core C#",
            "Objects and Types",
            "Object-Oriented Programming with C#",
            "Generics",
            "Operators and Casts",
            "Arrays",
            "Delegates, Lambdas, and Events",
            "Windows Communication Foundation"
        };
        private readonly int[] chapterNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 44 };
        private readonly int[] numberPages = { 35, 42, 33, 20, 24, 38, 20, 32, 44 };

        public void CreateSampleChapters()
        {
            var chapters = new List<BookChapter>();
            for (int i = 0; i < 9; i++)
            {
                chapters.Add(new BookChapter
                {
                    Number = chapterNumbers[i],
                    Title = sampleTitles[i],
                    Pages = numberPages[i]
                });
            }
            _bookChaptersService.AddRangeAsync(chapters).GetAwaiter().GetResult();
        }
    }
}
