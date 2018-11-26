using CoreService.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Services
{
    public class BookChaptersService : IBookChaptersService
    {
        private readonly ConcurrentDictionary<Guid, BookChapter> _chapters = new ConcurrentDictionary<Guid, BookChapter>();

        public Task AddAsync(BookChapter bookChapter)
        {
            bookChapter.Id = Guid.NewGuid();
            _chapters[bookChapter.Id] = bookChapter;
            return Task.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<BookChapter> bookChapters)
        {
            foreach (var bookChapter in bookChapters)
            {
                bookChapter.Id = Guid.NewGuid();
                _chapters[bookChapter.Id] = bookChapter;
            }
            return Task.CompletedTask;
        }

        public Task<BookChapter> FindAsync(Guid id)
        {
            _chapters.TryGetValue(id, out BookChapter bookChapter);
            return Task.FromResult(bookChapter);
        }

        public Task<IEnumerable<BookChapter>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<BookChapter>>(_chapters.Values);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            BookChapter book;
            var bookChapter = await FindAsync(id);
            var result = _chapters.TryRemove(bookChapter.Id, out book);
            return result;
        }

        public async Task UpdateAsync(Guid id, BookChapter bookChapter)
        {
            var book = await FindAsync(id);
            _chapters[book.Id] = bookChapter;
        }
    }
}
