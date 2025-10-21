using Alexandria.Models;
using Alexandria.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Alexandria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksRepository _repository;
        public BooksController(BooksRepository booksRepository)
        {
            _repository = booksRepository;
        }

        [HttpPost("AddBook")]
        public async Task<string> AddBookAsync(string title, DateTime publishDate, Guid authorId)
        {
            return await _repository.AddBookAsync(title, publishDate, authorId);
        }

        [HttpGet("GetBooks")]
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _repository.GetBooks();
        }

        [HttpGet("GetBook")]
        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _repository.GetBookByIdAsync(id);
        }

        [HttpPut("UpdateBook")]
        public async Task<string> UpdateBookByIdAsync(Guid id, string newTitle, DateTime newPublishDate)
        {
            return await _repository.UpdateBookByIdAsync(id, newTitle, newPublishDate);
        }

        [HttpDelete("DeleteBook")]
        public async Task<string> DeleteBookByIdAsync(Guid id)
        {
            return await _repository.DeleteBookByIdAsync(id);
        }
    }
}
