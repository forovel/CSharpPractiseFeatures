using CoreService.Models;
using CoreService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BooksServiceSample.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class BookChaptersController : Controller
    {
        private readonly IBookChaptersService _bookChaptersService;

        public BookChaptersController(IBookChaptersService bookChaptersService)
        {
            _bookChaptersService = bookChaptersService;
        }

        // GET api/bookchapters
        [HttpGet]
        public async Task<IEnumerable<BookChapter>> GetBookChapters()
        {
            return await _bookChaptersService.GetAllAsync();
        }

        // GET api/bookchapters/guid
        [HttpGet("{id}", Name = nameof(GetBookChapterById))]
        public async Task<IActionResult> GetBookChapterById(Guid id)
        {
            BookChapter chapter = await _bookChaptersService.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(chapter);
            }
        }

        /// <summary>
        /// Create Book Chapter
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     POST api/bookchapters
        ///     {
        ///         Number: 42,
        ///         Title: "Sample Title",
        ///         Pages: 98
        ///     }
        /// </remarks>
        /// <param name="chapter">Model with values for creating new BookChapter</param>
        /// <returns>http status code Created (201)</returns>
        /// <response code="201">Returns the newly created book chapter</response>
        /// <response code="400">If the chapter is null</response>
        [HttpPost]
        [ProducesResponseType(typeof(BookChapter), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostBookChapter([FromBody]BookChapter chapter)
        {
            if (chapter == null)
            {
                return BadRequest();
            }
            await _bookChaptersService.AddAsync(chapter);
            return CreatedAtRoute(nameof(GetBookChapterById), new { id = chapter.Id }, chapter);
        }

        // PUT api/bookchapters/guid
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookChapter(Guid id, [FromBody]BookChapter chapter)
        {
            if (chapter == null || id != chapter.Id)
            {
                return BadRequest();
            }
            if (await _bookChaptersService.FindAsync(id) == null)
            {
                return NotFound();
            }
            await _bookChaptersService.UpdateAsync(id, chapter);
            return new NoContentResult();
        }

        // DELETE api/bookchapters/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _bookChaptersService.RemoveAsync(id);
        }
    }
}
