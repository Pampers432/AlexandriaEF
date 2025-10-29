using AlexandriaEF.Contracts;
using AlexandriaEF.Abstraction;
using AlexandriaEF.Models;
using AlexandriaEF.Repositories;
using AlexandriaEF.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlexandriaEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        public BooksController(IBookService bookService)
        {
            _service = bookService;
        }

        [HttpPost("AddBook")]
        public async Task<ActionResult> AddBookAsync([FromBody] AddBookRequest request)
        {
            return Ok(await _service.AddBookAsync(request));
        }

        [HttpGet("GetBooks")]
        public async Task<List<BookResponse>> GetBooksAsync()
        {
            return await _service.GetBooksAsync();
        }

        [HttpGet("GetBook")]
        public async Task<BookResponse> GetBookByTitleAsync([FromQuery] BookByTitleRequest bookByTitleRequest)
        {
            return await _service.GetBookByTitleAsync(bookByTitleRequest);
        }

        [HttpPut("UpdateBook")]
        public async Task<ActionResult> UpdateBookByIdAsync([FromBody] UpdateBookRequest updateBookRequest)
        {
            return Ok(await _service.UpdateBookByIdAsync(updateBookRequest));
        }

        [HttpDelete("DeleteBook")]
        public async Task<ActionResult> DeleteBookByTitleAsync([FromBody] BookByTitleRequest bookByTitleRequest)
        {
            return Ok(await _service.DeleteBookByIdAsync(bookByTitleRequest));
        }
    }
}
