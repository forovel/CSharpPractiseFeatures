using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Services
{
    public interface IBookChaptersService
    {
        Task AddAsync(BookChapter bookChapter);
        Task AddRangeAsync(IEnumerable<BookChapter> bookChapters);
        Task<IEnumerable<BookChapter>> GetAllAsync();
        Task<BookChapter> FindAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, BookChapter bookChapter);
    }
}
